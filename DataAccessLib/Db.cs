using PersonDbLib;

using System.Data;

namespace DataAccessLib;

internal sealed class Db : IDb
{
  public event Action<string>? Log;

  private readonly PersonContext _db = null!;
  private readonly string _user;
  private readonly string _pwd;

  public Db(string user, string pwd)
  {
    _user = user;
    _pwd = pwd;
    _db = new PersonContext();
    //_db.Database.EnsureDeleted();
    _db.Database.EnsureCreated();
  }
  public void Insert(string query)
  {
    Log?.Invoke("---- Db::Insert ----");
    //TODO: insert data
  }

  public List<string> Select(string query)
  {
    Log?.Invoke("---- Db::Select ----");
    Log?.Invoke("  Takes a loooong time...");
    ArgumentException.ThrowIfNullOrEmpty(query.Trim());
    Thread.Sleep(1500);

    return Enumerable.Range(0, Random.Shared.Next(5, 10))
      .Select(x => $"Dummy_{x + 1}")
      .ToList();
  }

  public void Delete(string query)
  {
    Log?.Invoke("---- Db::Delete ----");
    //TODO: insert data
  }

}
