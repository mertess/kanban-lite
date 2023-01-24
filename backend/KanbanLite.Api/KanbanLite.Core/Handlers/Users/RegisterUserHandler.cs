using KanbanLite.Core.Common;
using KanbanLite.Core.Db;
using KanbanLite.Core.Db.DbModels;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KanbanLite.Core.Handlers.Users
{
    public class RegisterUserCommand : ICommand<VoidResult>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, VoidResult>
    {
        private readonly UserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(UserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Create(new User
            {
                Name = request.Name,
                Login = request.Login,
                PasswordHash = HashGenerator.GetMd5Hash(request.Password),
            });

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new VoidResult();
        }
    }
}
