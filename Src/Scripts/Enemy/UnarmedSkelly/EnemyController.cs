using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EnemyController : Node
{
	private CharacterBody2D _character;
	private CharacterBody2D _player;
	
	public override void _Ready()
	{
		GD.Print("Enemy controller ready");
		_player = PlayerStats.GetPlayer();
	}

	public void SetCharacter(CharacterBody2D character)
	{
		_character = character;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
