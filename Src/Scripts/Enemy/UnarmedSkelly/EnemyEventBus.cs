using Godot;
using System;
using SlimeVentures.Scripts;

public partial class EnemyEventBus : Node
{
	[Export] private EnemyController _controller;

	private CharacterBody2D _entity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Event bus ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_controller.Control(_entity, PlayerStats.GetPlayer());
	}

	public void SetEntity(CharacterBody2D entity)
	{
		_entity = entity;
	}
}
