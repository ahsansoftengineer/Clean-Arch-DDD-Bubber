using ErrorOr;
using MediatR;

namespace Donation.Application.Common.Commands
{
  public record CreateSimpleCommand<Entityz>(
    string Title,
    string Description
  ) : IRequest<ErrorOr<Entityz>>;

  public record CreateSimpleChildCommand<Entityz>(
    string Title,
    string Description,
    Guid ParentId
  ) : IRequest<ErrorOr<Entityz>>;


}
