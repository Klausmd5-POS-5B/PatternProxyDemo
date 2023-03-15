using DataAccessLib;

namespace ProxyLib;

public class DbAdminProxy: DbContract.IDb
{
    public event Action<string>? Log;
    private Db _db;
    
    public DbAdminProxy(string user, string pwd)
    {
        _db = new Db(user, pwd);
    }
    
    public void Insert(string query) => _db.Insert(query);

    public List<string> Select(string query) => _db.Select(query);

    public void Delete(string query) => _db.Delete(query);
}