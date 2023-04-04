namespace Donation.Contracts.Simple
{
  public record QueryRequestGetAllSimple();
  public record QueryRequestGetByIdSimple(
    Guid Id);
  public record QueryRequestSearch(
    Guid ParentId,
    Guid Id,
    string Title,
    string Description
  );
  //public record SimpleRequestQueryPagination(

  //);
}
