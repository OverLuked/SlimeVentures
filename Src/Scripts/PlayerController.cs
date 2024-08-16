using Godot;
using System;
using SlimeVentures.Scripts;

public partial class PlayerController : Node
{
	[Export] private EventBus _event;
	private CharacterBody2D _player;
	private AnimatedSprite2D _anims;
	private Marker2D _linearMarker;
	private PackedScene _linearBullet;

	private Vector2 _direction;
	private Vector2 _velocity;
	private float _initSpeed;
	private double _dashTime;
	private double _angle;
	private double _time;
	private double _bulletCD = 1;
	private double _bulletCoolTime;

	//DEBUG REFERENCES
	public Boolean Dashed;
	public float DashCoolTime;
	public Boolean IsBulletReady;


	public void SetPlayer(CharacterBody2D player, AnimatedSprite2D anims, Marker2D marker, float initSpeed)
	{
		// SET UP PLAYER STATS 
		// TODO: MAKE GLOBAL PLAYER STATS FOR GAME LOGIC
		_player = player;
		_anims = anims;
		_linearMarker = marker;
		_initSpeed = initSpeed;
	}
	
	public override void _Ready()
	{
		_linearBullet = GD.Load<PackedScene>("res://Src/Scenes/slime_ball.tscn");
		GD.Print("Controller Ready");
	}
	
	public override void _Process(double delta)
	{
		// Dash Logic
		_time = delta;
		if (Dashed && DashReady())
		{
			PlayerStats.DashCount -= 1;
			_dashTime += _time;
			Dash();
		}
		if ( Dashed && _dashTime > 0.0167) ReturnFromDash();
		if (PlayerStats.DashCount >= 0 && PlayerStats.DashCount < PlayerStats.MaxDash) DashCooldown();
		// PLAYER MOVEMENT
		_direction = new Vector2(
			Input.GetActionStrength("Right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
		);

		_velocity = _direction.LimitLength();
		_player.Velocity = _velocity != Vector2.Zero
			? _player.Velocity.Lerp(_velocity * PlayerStats.Speed * 2, 0.35f)
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
		// BULLET
		if (BulletReady(delta))
		{
			var bullet = (SlimeBall)_linearBullet.Instantiate();
			_player.AddChild(bullet);
			bullet.Direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(_player.GetGlobalMousePosition()));
			bullet.LookAt(_player.GetGlobalMousePosition());
			bullet.SpawnLoc = _linearMarker.Position;
			IsBulletReady = true;
		}
		else IsBulletReady = false;
		
		_player.MoveAndSlide();
	}
	// Bullet Cooldown
	private Boolean BulletReady(double delta)
	{
		_bulletCoolTime += delta * PlayerStats.AttackSpeed;
		if (_bulletCD >= _bulletCoolTime) return false;
		_bulletCoolTime = 0;
		return true;
	}
	// DASH
	private void Dash()
	{
		GD.Print("Player Dashed");
		PlayerStats.Speed = 1300;
		GD.Print("Dashed Speed: " + PlayerStats.Speed);
		GD.Print("Init Speed:" + _initSpeed);
	}
	private void ReturnFromDash()
	{
		GD.Print("Dash Done");
		PlayerStats.Speed = _initSpeed;
		GD.Print("Init Speed: " + _initSpeed);
		GD.Print("Current Speed: " + PlayerStats.Speed);
		Dashed = false;
		_dashTime = 0;
	}
	private Boolean DashReady()
	{
		return PlayerStats.DashCount > 0;
	}
	private void DashCooldown()
	{
		DashCoolTime += (float) _time;
		if (!(DashCoolTime > PlayerStats.DashCD)) return;
		PlayerStats.DashCount += 1;
		DashCoolTime = 0;
	}
}
