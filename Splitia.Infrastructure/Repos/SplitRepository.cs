using Splitia.Application.Abstraction.Repositories;
using Splitia.Infrastructure.DbContext;

namespace Splitia.Infrastructure.Repos;

public class SplitRepository(SplitiaContext context) : 
    GenericRepository<Domain.Split>(context), ISplitRepository
{
}