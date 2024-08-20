using Godot;
using System;
using SlimeVentures.Scripts;

public partial class SlimeBall : Sprite2D
{
	public Vector2 SpawnLoc;
	public Vector2 Direction;

	private static int _range = 100;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Direction * PlayerStats.BulletSpeed * (float)delta;

		var distanceTravelled = Position.DistanceTo(SpawnLoc);
		if (distanceTravelled >= _range) QueueFree();
	}
}
