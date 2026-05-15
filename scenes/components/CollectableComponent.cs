using Godot;
using System;

public partial class CollectableComponent : Area2D
{
	[Export]
	public string CollectableName;
	
	public void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			GD.Print($"Player collected: {CollectableName}");
			GetParent().QueueFree();
		}
	}
}
