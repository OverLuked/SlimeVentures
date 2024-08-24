using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EnemyController : Node
{
	private Vector2 _targetPos;
	private Vector2 _direction;


	public override void _Ready()
	{
		GD.Print("Enemy controller ready");
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Control(CharacterBody2D entity, CharacterBody2D player)
	{
		_targetPos = player.Position;
		_direction = (_targetPos - entity.Position).Normalized();
		entity.Velocity = _direction * EnemyStats.Speed;
		
		entity.MoveAndSlide();
	}
	
	// TODO: DAMAGE LOGIC 
}
