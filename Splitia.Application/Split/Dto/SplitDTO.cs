using Splitia.Application.Abstraction.Messaging.Queries;

namespace Splitia.Application.Split.Dto;

public class SplitDto
{
    public string Title { get; set; }
}

public record GetSplitByIdQuery : IQuery<SplitDto>
{
    public Guid Id { get; set; }
}