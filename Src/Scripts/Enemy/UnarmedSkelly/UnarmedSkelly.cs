using Godot;

public partial class UnarmedSkelly : CharacterBody2D
{
	[Export] private EnemyEventBus _controller;
	private const float Health = 4.0f;
	private const float Damage = 1.0f;
	private const float Speed = 300.0f;

	public override void _Ready()
	{
		EnemyStats.SetStats(Health, Damage, Speed);
		_controller.SetCharacter(this);
	}
}
