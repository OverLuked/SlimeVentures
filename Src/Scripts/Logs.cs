using Godot;
using System;

public partial class Logs : Label
{
	[Export] private PlayerController _controller;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("LOGS READY");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var stats = _controller.GetStats();

		Text = "Health: " + stats.Health
			+ "\nDamage: " + stats.Damage
			+ "\nDashes: " + stats.DashCount
			+ "\nMax Dash: " + stats.MaxDash;
	}
}
