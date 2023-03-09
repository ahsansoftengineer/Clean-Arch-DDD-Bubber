using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Simple
{
  public record SimpleCommandCreate<TEntity>(
    string Title,
    string Description) : IRequest<ErrorOr<TEntity>>;

  public record SimpleCommandChildCreate<TEntity>(
    Guid ParentId,
    string Title,
    string Description) : IRequest<ErrorOr<TEntity>>;
}
