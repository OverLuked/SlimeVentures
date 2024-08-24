using Godot;

public partial class UnarmedSkelly : CharacterBody2D
{
	//TODO: GROUP
	[Export] private EnemyEventBus _controller;
	private const float Health = 4.0f;
	private const float Speed = 25.0f;
	private const float Damage = 1.0f;

	public override void _Ready()
	{
		EnemyStats.SetStats(Health, Speed, Damage);
		_controller.SetEntity(this);
	}
}
