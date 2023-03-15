namespace DbContract;

public interface IDb
{
  event Action<string>? Log;
  void Insert(string query);
  List<string> Select(string query);
  void Delete(string query);
}
