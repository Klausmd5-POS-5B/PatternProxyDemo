using DataAccessLib;

namespace ProxyLib;

public class DbFactory
{
    public static DbContract.IDb Create(string user, string pwd)
    {
        return user.ToLower().Trim() switch
        {
            "admin" => new DbAdminProxy(user, pwd),
            "premium" => new DbPremiumProxy(user, pwd),
            _ => new DbStandardProxy(user, pwd)
        };
    }   
}