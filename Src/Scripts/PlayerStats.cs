using Godot;

namespace SlimeVentures.Scripts;

public partial class PlayerStats : Node
{
    // REQUIRED FOR LOGIC
    public static float Health ;
    public static float Speed;
    public static float AttackSpeed ;
    public static float BulletSpeed;
    public static float Damage;
    public static float DashCD;
    public static int DashCount;
    public static int MaxDash;

    public static void SetStats(float health, float speed, float attackSpeed, float bulletSpeed, float damage, 
        float dashCD, int n, int maxDash)
    {
        Health = health;
        Speed = speed;
        AttackSpeed = attackSpeed;
        BulletSpeed = bulletSpeed;
        Damage = damage;
        DashCD = dashCD;
        DashCount = n;
        MaxDash = maxDash;
    }

    public override void _Ready()
    {
        GD.Print("Player ready");
    }
}