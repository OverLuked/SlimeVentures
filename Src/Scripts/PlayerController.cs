using Godot;
using System;

public partial class PlayerController : Node
{
	private float _health;
	private float _speed;
	private float _attackSpeed;
	private float _bulletSpeed;
	private float _damage;
	private int _dashN;
	private int _maxDash;

	private Vector2 _direction;
	private Vector2 _velocity;
	private CharacterBody2D _player;

	public void setStats(float health, float speed, float attackSpeed, float bulletSpeed, float damage, int n, int maxDash, CharacterBody2D player)
	{
		_health = health;
		_speed = speed;
		_attackSpeed = attackSpeed;
		_bulletSpeed = bulletSpeed;
		_damage = damage;
		_dashN = n;
		_maxDash = maxDash;
		_player = player;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Player Controller is Ready!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
		);

		_velocity = _direction.LimitLength();
		_player.Velocity = _velocity != Vector2.Zero
			? _player.Velocity.Lerp(_velocity * _speed * 2, 0.35f)
			: _player.Velocity.Lerp(Vector2.Zero, 0.5f);

		_player.MoveAndSlide();
	}
}
