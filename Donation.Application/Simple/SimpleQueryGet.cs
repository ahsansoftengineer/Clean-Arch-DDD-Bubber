using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

public record SimpleQueryGetAll<TEntity>(): IRequest<ErrorOr<List<TEntity>>>;
public record SimpleQueryGetAllwithChild<TEntity>(): IRequest<ErrorOr<List<TEntity>>>;
public record SimpleQueryGetById<TEntity>(
  SimpleValueObject Id) : IRequest<ErrorOr<TEntity>>;

public record SimpleQuerySearch<TEntity>(
  string Title,
  string Description) : IRequest<ErrorOr<TEntity>>;

//List => Pagination Sorting Search
//public record SimpleQueryListing<TEntity>(
//  string Title,
//  string Description) : IRequest<ErrorOr<TEntity>>;

