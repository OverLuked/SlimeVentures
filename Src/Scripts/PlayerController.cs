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
	private double _angle;
	private double _time;

	public Boolean IsDashAvailable;

	//DEBUG REFERENCES
	public float DashCoolTime;
	public Boolean BulletReady;


	public void SetPlayer(CharacterBody2D player, AnimatedSprite2D anims, Marker2D marker)
	{
		// SET UP PLAYER STATS 
		// TODO: MAKE GLOBAL PLAYER STATS FOR GAME LOGIC
		_player = player;
		_anims = anims;
		_linearMarker = marker;
	}
	
	public override void _Ready()
	{
		_linearBullet = GD.Load<PackedScene>("res://Src/Scenes/slime_ball.tscn");
		GD.Print("Controller Ready");
	}
	
	public override void _Process(double delta)
	{
		// COOLDOWN TIMER
		_time = delta;
		IsDashAvailable = DashReady(delta);
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
		if (_event.BulletReady(delta))
		{
			var bullet = (SlimeBall)_linearBullet.Instantiate();
			_player.AddChild(bullet);
			bullet.Direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(_player.GetGlobalMousePosition()));
			bullet.LookAt(_player.GetGlobalMousePosition());
			bullet.SpawnLoc = _linearMarker.Position;
			BulletReady = true;
		}
		else BulletReady = false;
		
		_player.MoveAndSlide();
	}
	
	// TODO: DASHES
	public void Dash()
	{
		GD.Print("Player Dashed");
		PlayerStats.DashCount -= 1;

	}
	// DASH
	public Boolean DashReady(double delta)
	{
		IsDashAvailable = PlayerStats.DashCount > 0;
		if (!IsDashAvailable)
		{
			DashCooldown(delta);
			return false;
		}

		if (IsDashAvailable && PlayerStats.DashCount != PlayerStats.MaxDash)
		{
			DashCooldown(delta);
			return true;
		}

		DashCoolTime = 0;
		return true;
	}

	private void DashCooldown(double delta)
	{
		DashCoolTime += (float) delta;
		if (DashCoolTime > PlayerStats.DashCD)
		{
			PlayerStats.DashCount += 1;
			DashCoolTime = 0;
		}
	}

	public String UpdateLogs()
	{
		String log = "Health: " + PlayerStats.Health
		                        + "\nDamage: " + PlayerStats.Damage
		                        + "\nDashes: " + PlayerStats.DashCount
		                        + "\nMax Dash: " + PlayerStats.MaxDash;
		return log;
	}
	
}
