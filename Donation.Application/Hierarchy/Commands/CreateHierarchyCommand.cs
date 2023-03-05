
using Donation.Application.Menus.Commands.CreateMenu;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public record CreateOrgCommand(
    string Title,
    string Description) : IRequest<ErrorOr<Org>>;

  public record CreateSystemzCommand(
    string Title,
    string Description,
    string ParentId
    ) : IRequest<ErrorOr<Systemz>>;

  public record CreateBGCommand(
    string Title,
    string Description) : IRequest<ErrorOr<BG>>;

  public record CreateLECommand(
    string Title,
    string Description,
    string ParentId) : IRequest<ErrorOr<LE>>;

  public record CreateOUCommand(
    string Title,
    string Description,
    string ParentId) : IRequest<ErrorOr<OU>>;

  public record CreateSUCommand(
    string Title,
    string Description,
    string ParentId) : IRequest<ErrorOr<SU>>;

}
