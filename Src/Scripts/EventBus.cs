using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EventBus : Node
{
	[Export] private PlayerController _controller;
	private float _dashCoolTime;
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}


	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Dash"))
		{
			_controller.Dashed = true;
		}
	}
}
