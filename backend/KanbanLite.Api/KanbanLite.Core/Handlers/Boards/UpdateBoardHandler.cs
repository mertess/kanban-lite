using KanbanLite.Core.Common;
using KanbanLite.Core.Db;
using KanbanLite.Core.Db.Repositories;
using MediatR;

namespace KanbanLite.Core.Handlers.Boards
{
    public class UpdateBoardCommand : ICommand<Result<VoidResult>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class UpdateBoardHandler : IRequestHandler<UpdateBoardCommand, Result<VoidResult>>
    {
        private readonly BoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBoardHandler(BoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<VoidResult>> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var existedBoard = _boardRepository.FirstOrDefault(b => b.Id == request.Id);
            if (existedBoard == null)
                return Result<VoidResult>.Fail($"Board by id {request.Id} not found");

            existedBoard.Name = request.Name;

            _boardRepository.Update(existedBoard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<VoidResult>.Success(new VoidResult());
        }
    }
}
