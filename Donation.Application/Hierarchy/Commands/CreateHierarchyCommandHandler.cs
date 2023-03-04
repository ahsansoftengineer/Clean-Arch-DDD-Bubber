using Donation.Application.Common.Commands;
using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOrgCommandHandler : CreateSimpleCommandHandler<IOrgRepo, Org>
  {
    public CreateOrgCommandHandler(IOrgRepo repo) : base(repo)
    {
    }
  }
  //public class CreateSimpleChildCommandHandler : CreateSimpleChildCommandHandler<ISystemzRepo, Systemz>
  //{
  //  public CreateSimpleChildCommandHandler(ISystemzRepo repo) : base(repo)
  //  {
  //  }
  //}
  //public class CreateBGCommandHandler : CreateSimpleCommandHandler<IBGRepo, BG>
  //{
  //  public CreateBGCommandHandler(IBGRepo repo) : base(repo)
  //  {
  //  }
  //}
  //public class CreateLECommandHandler : CreateSimpleChildCommandHandler<ILERepo, LE>
  //{
  //  public CreateLECommandHandler(ILERepo repo) : base(repo)
  //  {
  //  }
  //}
  //public class CreateOUCommandHandler : CreateSimpleChildCommandHandler<IOURepo, OU>
  //{
  //  public CreateOUCommandHandler(IOURepo repo) : base(repo)
  //  {
  //  }
  //}
  //public class CreateSUCommandHandler : CreateSimpleChildCommandHandler<ISURepo, SU>
  //{
  //  public CreateSUCommandHandler(ISURepo repo) : base(repo)
  //  {
  //  }
  //}
}
