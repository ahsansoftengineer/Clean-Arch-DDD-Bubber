using ErrorOr;
using MediatR;

namespace Donation.Application.Simple
{
    public record SimpleCommandCreate<Entity>(
      string Title,
      string Description) : IRequest<ErrorOr<Entity>>;

    public record SimpleCommandChildCreate<Entity>(
      Guid ParentId,
      string Title,
      string Description) : IRequest<ErrorOr<Entity>>;
}
