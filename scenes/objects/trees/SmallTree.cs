using Godot;
using System;

public partial class SmallTree : Sprite2D
{
	private HurtComponent hurtComponent;
	private DamageComponent damageComponent;
	
	private PackedScene LogScene = GD.Load<PackedScene>("res://scenes/objects/trees/log.tscn");
	
	public override void _Ready()
	{
		hurtComponent = GetNodeOrNull<HurtComponent>("HurtComponent");
		if (hurtComponent != null)
		{
			 hurtComponent.Connect(nameof(hurtComponent.Hurt), new Callable(this, nameof(OnHurt)));
		}
		damageComponent = GetNodeOrNull<DamageComponent>("DamageComponent");
	   	damageComponent?.Connect(nameof(damageComponent.MaxDamagedReached), new Callable(this, nameof(OnMaxDamageReached)));
	}
	
	public async void OnHurt(int damage)
	{
		damageComponent?.ApplyDamage(damage);
	}
	
	public void OnMaxDamageReached()
	{
		CallDeferred(nameof(AddLogScene));
		GD.Print("SmallTree: Max damage reached, tree will be removed.");
		QueueFree();
	}
	
	public void AddLogScene()
	{
		// if(LogScene == null) return;
		var LogInstance = LogScene.Instantiate<Node2D>();
		LogInstance.GlobalPosition = this.GlobalPosition;
		GetParent().AddChild(LogInstance);
	}
}
