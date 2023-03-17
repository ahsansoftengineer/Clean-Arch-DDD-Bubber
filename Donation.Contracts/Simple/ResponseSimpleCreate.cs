namespace Donation.Contracts.Simple
{
  public record SimpleOption(
    string Id,
    string Title);
  public record ResponseSimpleCreate(
    string Id,
    string Title,
    string Description);
  public record ResponseSimplewithParentId(
    string Id,
    string Title,
    string Description,
    string ParentId
  );
  public record SimpleResponseChildCreate(
    string Id,
    string Title,
    string Description,
    string ParentId
    );
  public record SimpleResponseChildwithParent(
    string Id,
    string Title,
    string Description,
    string ParentId,
    SimpleOption Parent
  );
  public record SimpleResponseParentWithChild(
  string Id,
  string Title,
  string Description,
  List<SimpleOption> Childs
  );

}