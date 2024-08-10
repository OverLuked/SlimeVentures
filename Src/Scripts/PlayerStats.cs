using Godot;
using System;

public partial class PlayerStats : Node
{
    // REQUIRED FOR LOGIC
    private float _health;
    private float _damage;
    
    // DEBUG REFERENCES
    private int _dashCount;
    private int _maxDash;

    public void SetStats(float health, float damage, int dashN, int dashJ)
    {
        _health = health;
        _damage = damage;
        _dashCount = dashN;
        _maxDash = dashJ;
    }

    public override void _Ready()
    {
        GD.Print("PLAYER STATS READY");
    }
}
