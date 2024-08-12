using Godot;
using System;

public partial class LinearProjectileMarker : Marker2D
{
	[Export] private alexander_slime _player;

	private float _direction;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        GD.Print("Linear Marker Ready!");
	}

	public override void _Draw()
	{
		DrawCircle(Position, 1, Colors.Black);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_direction = _player.Position.AngleToPoint(GetGlobalMousePosition());
		this.Position =  new Vector2(4 * MathF.Cos(_direction), (3 * MathF.Sin(_direction)) + 1);;
		QueueRedraw();
	}
	
}
