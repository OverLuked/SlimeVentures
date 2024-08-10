using Godot;

namespace SlimeVentures.Scripts;

public partial class PlayerStats : Node
{
    // REQUIRED FOR LOGIC
    public float Health;
    public float Damage;
    
    // DEBUG REFERENCES
    public int DashCount;
    public int MaxDash;

    public void SetStats(float health, float damage, int dashN, int dashJ)
    {
        Health = health;
        Damage = damage;
        DashCount = dashN;
        MaxDash = dashJ;
    }

    public override void _Ready()
    {
        GD.Print("PLAYER STATS READY");
    }
}