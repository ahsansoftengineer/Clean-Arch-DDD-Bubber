namespace Donation.Contracts.Simple
{
  public record SimpleRequestQueryGetById(
    Guid Id);

  public record SimpleRequestQuerySearch(
    Guid ParentId,
    Guid Id,
    string Title,
    string Description
  );
  //public record SimpleRequestQueryPagination(

  //);
}
