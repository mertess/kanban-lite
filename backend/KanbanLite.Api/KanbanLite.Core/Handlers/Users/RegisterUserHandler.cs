using KanbanLite.Core.Common;
using KanbanLite.Core.Db;
using KanbanLite.Core.Db.DbModels;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KanbanLite.Core.Handlers.Users
{
    public class RegisterUserCommand : ICommand<RegisterUserResult>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }

    public class RegisterUserResult { }

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
    {
        private readonly UserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(UserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Create(new User
            {
                Name = request.Name,
                Login = request.Login,
                PasswordHash = HashGenerator.GetMd5Hash(request.Password),
            });

            await _unitOfWork.SaveChangesAsync();

            return new RegisterUserResult();
        }
    }
}
