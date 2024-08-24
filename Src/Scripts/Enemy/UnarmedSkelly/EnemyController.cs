using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EnemyController : Node
{
	public CharacterBody2D Character;
	private CharacterBody2D _player;
	
	public override void _Ready()
	{
		GD.Print("Enemy controller ready");
		_player = PlayerStats.GetPlayer();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Character.MoveAndSlide();
	}
}
