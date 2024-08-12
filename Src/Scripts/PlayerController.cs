using Godot;
using System;
using SlimeVentures.Scripts;

public partial class PlayerController : Node
{
	[Export] private EventBus _event;
	private CharacterBody2D _player;
	private AnimatedSprite2D _anims;
	private Marker2D _linearMarker;

	private Vector2 _direction;
	private Vector2 _velocity;
	private double _angle;


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

		if (_event.BulletReady(delta))
		{
			GD.Print("SHOOTING");
		}
		
		_player.MoveAndSlide();
	}
	
	// TODO: DASHES
	public void Dash()
	{
		GD.Print("Player Dashed");
		PlayerStats.DashCount -= 1;
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
