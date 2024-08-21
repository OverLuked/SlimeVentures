using Godot;
using System;

public partial class EnemyEventBus : Node
{
	[Export] private EnemyController _controller;
	private CharacterBody2D _character;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetCharacter(CharacterBody2D character)
	{
		_character = character;
	}
}
