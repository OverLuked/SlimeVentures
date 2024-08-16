using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EventBus : Node
{
	[Export] private PlayerController _controller;
	private float _dashCoolTime;
	private double _dashFrame;
	private double _time;
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}

	public override void _Process(double delta)
	{
		_time = delta;
	}


	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Dash"))
		{
			if (_controller.DashReady())
			{
				PlayerStats.Speed = 750;
				PlayerStats.DashCount -= 1;
				_controller.Dashed = true;
			}
		}
	}
}
