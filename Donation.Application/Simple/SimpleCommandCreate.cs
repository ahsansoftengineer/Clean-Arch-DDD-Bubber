using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Simple
{
  public record SimpleCommandCreate(
    string Title,
    string Description) : IRequest<ErrorOr<SimpleAggregate>>;

  public record SimpleCommandChildCreate(
    Guid ParentId,
    string Title,
    string Description) : IRequest<ErrorOr<SimpleAggregate>>;
}
