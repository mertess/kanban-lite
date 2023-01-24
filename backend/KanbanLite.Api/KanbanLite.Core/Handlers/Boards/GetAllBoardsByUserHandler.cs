using KanbanLite.Core.Common;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Handlers.Boards
{
    public class GetAllBoardsByUserQuery : IQuery<Result<GetAllBoardsByUserResult>>
    {

    }

    public class GetAllBoardsByUserResult
    {
        public BoardModel[] Boards { get; set; } = null!;
    }

    public class BoardModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset? UpdatedAtUtc { get; set; }
        public string Name { get; set; } = null!;
    }

    public class GetAllBoardsByUserHandler : IRequestHandler<GetAllBoardsByUserQuery, Result<GetAllBoardsByUserResult>>
    {
        private readonly BoardRepository _boardRepository;

        public GetAllBoardsByUserHandler(BoardRepository boardRepository) => _boardRepository = boardRepository;

        public async Task<Result<GetAllBoardsByUserResult>> Handle(GetAllBoardsByUserQuery request, CancellationToken cancellationToken)
        {
            //TODO: add getting the ID of the current user

            var boards = await _boardRepository.GetMany(b => b.UserId == 1)
                                               .AsNoTracking()
                                               .ToArrayAsync();

            return Result<GetAllBoardsByUserResult>.Success(new GetAllBoardsByUserResult
            {
                Boards = boards.Select(b => new BoardModel
                {
                    Id = b.Id,
                    CreatedAtUtc = b.CreatedAtUtc,
                    UpdatedAtUtc = b.UpdatedAtUtc,
                    Name = b.Name
                }).ToArray()
            });
        }
    }
}
