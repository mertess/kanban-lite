using KanbanLite.Core.Common;
using KanbanLite.Core.Db;
using KanbanLite.Core.Db.DbModels;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Handlers.Boards
{
    public class CreateBoardCommand : ICommand<Result<CreateBoardResult>>
    {
        [Required]
        public string Name { get; set; } = null!;
    }

    public class CreateBoardResult
    {
        public int Id { get; set; }
    }

    public class CreateBoardHandler : IRequestHandler<CreateBoardCommand, Result<CreateBoardResult>>
    {
        private readonly BoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBoardHandler(BoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateBoardResult>> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            //TODO: add getting the ID of the current user

            var newBoard = new Board { Name = request.Name, UserId = 1 };

            _boardRepository.Create(newBoard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<CreateBoardResult>.Success(new CreateBoardResult { Id = newBoard.Id });
        }
    }
}
