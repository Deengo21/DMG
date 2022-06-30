namespace dmg.Data;

public class Character : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MeleCombat { get; set; }
    
    public int Shooting { get; set; }

    public int Strength { get; set; }
}