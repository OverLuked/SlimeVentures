using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EventBus : Node
{
	[Export] private PlayerController _controller;
	private Boolean _isDashAvailable;
	
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GD.Print("EVENT BUS READY");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Dash"))
		{
			_isDashAvailable = PlayerStats.DashCount != 0;
			if (_isDashAvailable)
			{
				_controller.Dash();
			} else GD.Print("DASH ON COOLDOWN");
		}
	}
}
