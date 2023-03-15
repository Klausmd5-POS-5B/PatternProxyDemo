namespace PatternProxyDemo;
public partial class MainWindow : Window
{
  private IDb? _db;
  public MainWindow() => InitializeComponent();

  //queries:
  //insert into Persons(Firstname,Lastname,CompanyId) values('Fritzi','Mair',1)
  //delete from Persons where id=5
  //select * from persons
  private void BtnConnect_Clicked(object sender, RoutedEventArgs e)
  {
    _db = ProxyLib.DbFactory.Create(txtUser.Text, "xxx");
    _db.Log += x => lstLogs.Items.Add(x);
    btnDelete.IsEnabled = true;
    btnInsert.IsEnabled = true;
    btnSelect.IsEnabled = true;
    btnConnect.IsEnabled = false;
    btnDisonnect.IsEnabled = true;
    lstLogs.Items.Add($"connected as {txtUser.Text}");
    lstLogs.Items.Add($"access to DB as {_db.GetType().Name}");
  }

  private void BtnSelect_Clicked(object sender, RoutedEventArgs e)
  {
    try
    {
      ArgumentNullException.ThrowIfNull(_db);
      _db.Select(txtQuery.Text).ForEach(x => lstLogs.Items.Add(x));
    }
    catch (Exception exc)
    {
      lstLogs.Items.Add(exc.Message);
    }
  }

  private void BtnInsert_Clicked(object sender, RoutedEventArgs e)
  {
    try
    {
      ArgumentNullException.ThrowIfNull(_db);
      _db.Insert(txtQuery.Text);
    }
    catch (Exception exc)
    {
      lstLogs.Items.Add(exc.Message);
    }
  }

  private void BtnDelete_Clicked(object sender, RoutedEventArgs e)
  {
    try
    {
      ArgumentNullException.ThrowIfNull(_db);
      _db.Delete(txtQuery.Text);
    }
    catch (Exception exc)
    {
      lstLogs.Items.Add(exc.Message);
    }
  }

  private void BtnDisconnect_Clicked(object sender, RoutedEventArgs e)
  {
    btnDelete.IsEnabled = false;
    btnInsert.IsEnabled = false;
    btnSelect.IsEnabled = false;
    btnConnect.IsEnabled = true;
    btnDisonnect.IsEnabled = false;
    lstLogs.Items.Add($"user {txtUser.Text} disconnected");
  }

  private void BtnClear_Clicked(object sender, RoutedEventArgs e) => lstLogs.Items.Clear();
}
