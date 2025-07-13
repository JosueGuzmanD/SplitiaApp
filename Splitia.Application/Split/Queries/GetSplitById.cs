using Splitia.Application.Abstraction.Messaging.Queries;
using Splitia.Application.Split.Dto;

namespace Splitia.Application.Split.Queries;

public class GetSplitByIdQueryHandler : IQueryHandler<GetSplitByIdQuery, SplitDto>
{
    public Task<SplitDto> Handle(GetSplitByIdQuery query)
    {
        var dto = new SplitDto
        {
            Title = "FakeSplitt"
        };
        return Task.FromResult(dto);
    }
}