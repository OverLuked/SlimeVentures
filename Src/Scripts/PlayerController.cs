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
	private double _angle;

	private CharacterBody2D _player;
	private AnimatedSprite2D _anims;
	private PlayerStats _stats;



	public void SetStats(float health, float speed, float attackSpeed, float bulletSpeed, float damage, 
		int n, int maxDash, CharacterBody2D player, AnimatedSprite2D anims)
	{
		// SET UP PLAYER STATS 
		// TODO: MAKE GLOBAL PLAYER STATS FOR GAME LOGIC
		_health = health;
		_speed = speed;
		_attackSpeed = attackSpeed;
		_bulletSpeed = bulletSpeed;
		_damage = damage;
		_dashN = n;
		_maxDash = maxDash;
		_player = player;
		_anims = anims;
	}

	public PlayerStats GetStats ()
	{
		_stats.SetStats(_health, _damage, _dashN, _maxDash);
		return _stats;
		
	}
	
	public override void _Ready()
	{
		_stats = new PlayerStats();
		GD.Print("Controller Ready");
	}
	
	public override void _Process(double delta)
	{
		// PLAYER MOVEMENT
		_direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
		);

		_velocity = _direction.LimitLength();
		_player.Velocity = _velocity != Vector2.Zero
			? _player.Velocity.Lerp(_velocity * _speed * 2, 0.35f)
			: _player.Velocity.Lerp(Vector2.Zero, 0.5f);
		
		// PLAYER ANIMATIONS
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
		
		_player.MoveAndSlide();
	}
}
