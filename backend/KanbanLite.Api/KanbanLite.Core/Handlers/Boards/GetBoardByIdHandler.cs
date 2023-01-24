using KanbanLite.Core.Common;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Handlers.Boards
{
    public class GetBoardByIdQuery : IQuery<Result<GetBoardByIdResult>>
    {
        public int Id { get; set; }
    }

    public class GetBoardByIdResult
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset? UpdatedAtUtc { get; set; }
        public string Name { get; set; } = null!;

        //TODO: add additional info
    }

    public class GetBoardByIdHandler : IRequestHandler<GetBoardByIdQuery, Result<GetBoardByIdResult>>
    {
        private readonly BoardRepository _boardRepository;
        
        public GetBoardByIdHandler(BoardRepository boardRepository) =>
            _boardRepository = boardRepository;

        public Task<Result<GetBoardByIdResult>> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var existedBoard = _boardRepository.FirstOrDefault(b => b.Id == request.Id);
            if (existedBoard == null)
                return Task.FromResult(Result<GetBoardByIdResult>.Fail($"Board by id {request.Id} not found"));

            return Task.FromResult(
                Result<GetBoardByIdResult>.Success(new GetBoardByIdResult
                { 
                    Id = existedBoard.Id,
                    CreatedAtUtc = existedBoard.CreatedAtUtc,
                    UpdatedAtUtc = existedBoard.UpdatedAtUtc,
                    Name = existedBoard.Name
                })
            );
        }
    }
}
