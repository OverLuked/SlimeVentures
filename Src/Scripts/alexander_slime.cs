using Godot;
using System;

public partial class alexander_slime : CharacterBody2D
{
    [Export] private PlayerController _controller;
    [Export] private AnimatedSprite2D _anims;
    [Export] private Logs _logs;
    [Export] private float _health = 3.5f;
    [Export] private float _speed = 25.0f;
    [Export] private float _attackSpeed = 1.0f;
    [Export] private float _bulletSpeed = 100.0f;
    [Export] private float _damage = 1.0f;
    [Export] private int _dashN = 1;
    [Export] private int _maxDash = 3;

    private double _direction;

    
    public override void _Ready()
    {
        GD.Print("PLAYER READY");
        _controller.SetStats(_health, _speed, _attackSpeed, _bulletSpeed, _damage, _dashN, _maxDash, this, _anims);
    }

    public override void _Process(double delta)
    {
        _direction = GetGlobalMousePosition().AngleToPoint(Position);
    }
}
