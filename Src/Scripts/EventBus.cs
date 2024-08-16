using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EventBus : Node
{
	[Export] private PlayerController _controller;
	private float _dashCoolTime;
	private double _bulletCD = 1;
	private double _bulletCoolTime;

	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}


	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Dash"))
		{
			if (_controller.IsDashAvailable)
			{
				_controller.Dash();
			} else GD.Print("Dash on cooldown");
		}
	}
	
	// Bullet Cooldown
	public Boolean BulletReady(double delta)
	{
		_bulletCoolTime += delta * PlayerStats.AttackSpeed;
		if (_bulletCD >= _bulletCoolTime) return false;
		_bulletCoolTime = 0;
		return true;
	}
	
}
