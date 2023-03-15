using DataAccessLib;
using DbContract;

namespace ProxyLib;

public class DbStandardProxy: IDb
{
    public event Action<string>? Log;
    private Db _db;
    private string _user;
    
    public DbStandardProxy(string user, string pwd)
    {
        _db = new Db(user, pwd);
        _user = user;
    }
    public void Insert(string query)
    {
        _db.Insert(query);
        Log.Invoke("User is not admin | Anyways insert");
    }

    public List<string> Select(string query) => _db.Select(query);

    public void Delete(string query)
    {
        // shouldn happen anyways bc admin would get a DbAdminProxy
        if (_user == "admin")
        {
            _db.Delete(query);
        }  
        Log.Invoke("User is not admin | Delete failed");
    } 
}