using Godot;
using System;

public partial class EnemyStats : Node
{
	public static float Health;
	public static float Speed;
	public static float Damage;

	public static void SetStats(float health, float speed, float damage)
	{
		Health = health;
		Speed = speed;
		Damage = damage;
	}
}
