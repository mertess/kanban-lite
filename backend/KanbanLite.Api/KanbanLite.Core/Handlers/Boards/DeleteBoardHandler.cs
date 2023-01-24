using KanbanLite.Core.Common;
using KanbanLite.Core.Db;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Handlers.Boards
{
    public class DeleteBoardCommand : ICommand<Result<VoidResult>>
    {
        public int Id { get; set; }
    }

    public class DeleteBoardHandler : IRequestHandler<DeleteBoardCommand, Result<VoidResult>>
    {
        private readonly BoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBoardHandler(BoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<VoidResult>> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var existedBoard = _boardRepository.FirstOrDefault(b => b.Id == request.Id);
            if (existedBoard == null)
                return Result<VoidResult>.Fail($"Board by id {request.Id} not found ");

            _boardRepository.Delete(existedBoard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<VoidResult>.Success(new VoidResult());
        }
    }
}
