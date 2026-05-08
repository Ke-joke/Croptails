using Godot;
using System;

public partial class InteractableComponent : Area2D
{
	[Signal]
	public delegate void InteractableActivatedEventHandler();
	[Signal]
	public delegate void InteractableDeactivatedEventHandler();
	
	public void OnBodyEnetered(Node2D body)
	{
		EmitSignal(nameof(InteractableActivated));
	}
	
	public void OnBodyExited(Node2D body)
	{
		EmitSignal(nameof(InteractableDeactivated));
	}
}
