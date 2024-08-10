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
	private AnimatedSprite2D _anims;
	private double _angle;
	

	public void SetStats(float health, float speed, float attackSpeed, float bulletSpeed, float damage, 
		int n, int maxDash, CharacterBody2D player, AnimatedSprite2D anims)
	{
		_speed = speed;
		_attackSpeed = attackSpeed;
		_bulletSpeed = bulletSpeed;
		_damage = damage;
		_dashN = n;
		_maxDash = maxDash;
		_player = player;
		_anims = anims;
	}
	private void _Animations()
	{
		_angle = _player.GetGlobalMousePosition().AngleToPoint(_player.Position);
		
		switch (_angle)
		{
			case > -0.8 and < 0.6:
				_anims.Play("WalkLeft");
				break;
			case >= 0.6 and < 2.6:
				_anims.Play("WalkUp");
				break;
			case >= 2.6 and <= 3.14:
			case <= -2.14 and >= -3.14:
				_anims.Play("WalkRight");
				break;
			default:
				_anims.Play("WalkDown");
				break;
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Player Controller is Ready!");
		GD.Print("Player Animations Ready");
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
		_Animations();

		_player.MoveAndSlide();
	}
}
