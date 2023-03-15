namespace PersonDbLib;
public class Person
{
  public int Id { get; set; }
  [Required] public string Firstname { get; set; } = null!;
  public string Lastname { get; set; } = null!;
  public Company Company { get; set; } = null!;

  public override string ToString() => $"{Lastname} {Firstname} [{Id}]";
}
