using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EventBus : Node
{
	[Export] private PlayerController _controller;
	private Boolean _isDashAvailable;
	private double _bulletCD = 1;
	private double _bulletTime;
	
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Dash"))
		{
			_isDashAvailable = PlayerStats.DashCount != 0;
			if (_isDashAvailable)
			{
				_controller.Dash();
			} else GD.Print("Dash on cooldown");
		}
	}
	
	// Bullet Cooldown
	public Boolean BulletReady(double delta)
	{
		_bulletTime += delta * PlayerStats.AttackSpeed;
		if (_bulletCD > _bulletTime) return false;
		else
		{
			_bulletTime = 0;
			return true;
		}
	}
	
}
