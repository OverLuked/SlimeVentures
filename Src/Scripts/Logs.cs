using Godot;
using System;
using SlimeVentures.Scripts;

public partial class Logs : Label
{
	public Boolean BulletReady;
	public double Cooldown;
	 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Logs ready");
	}

	public override void _Process(double delta)
	{
		Text = "Health: " + PlayerStats.Health
		                  + "\nDamage: " + PlayerStats.Damage
		                  + "\nDashes: " + PlayerStats.DashCount
		                  + "\nDash Cooldown: " + Cooldown
		                  + "\nMax Dash: " + PlayerStats.MaxDash
		                  + "\nBullet Ready:" + BulletReady;
	}
}
