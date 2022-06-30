namespace dmg.Data;
public enum WeaponType{
    OneHanded, TwoHanded, OneAndHalfHanded,
}
public class Weapon : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public WeaponType Type { get; set; }
    
}