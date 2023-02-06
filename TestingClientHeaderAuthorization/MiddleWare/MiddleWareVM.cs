namespace TestingClientHeaderAuthorization.MiddleWare
{
  public class MiddleWareVM
  {
    public string ApiKey { get; private set; } = null!;
  }

  public class CreateUser
  {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
  }
}
