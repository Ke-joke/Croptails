using Godot;
using System;

public partial class DamageComponent : Node2D
{
	[Signal]
	public delegate void MaxDamagedReachedEventHandler();
	[Export]
	public int MaxDamage = 1;
	[Export]
	public int CurrentDamage = 0;
	
	public void ApplyDamage(int damage)
	{
		CurrentDamage += damage;
		if (CurrentDamage >= MaxDamage)
		{
			CurrentDamage = MaxDamage;
			EmitSignal(nameof(MaxDamagedReached));
		}
	}
}
