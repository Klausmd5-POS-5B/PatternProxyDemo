namespace PersonDbLib;

public class Company
{
  public int Id { get; set; }
  [Required] public string Name { get; set; } = null!;

  public override string ToString() => $"{Name} [{Id}]";
}
