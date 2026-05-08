using Godot;
using System;

public partial class Door : StaticBody2D
{
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private InteractableComponent interactableComponent;
	
	public override void _Ready()
	{
		//初始化
		animatedSprite2D = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
		collisionShape2D = GetNodeOrNull<CollisionShape2D>("CollisionShape2D");
		interactableComponent = GetNodeOrNull<InteractableComponent>("InteractableComponent");
		
		interactableComponent.Connect(nameof(interactableComponent.InteractableActivated), new Callable(this, nameof(OnInteractableActivated)));
		interactableComponent.Connect(nameof(interactableComponent.InteractableDeactivated), new Callable(this, nameof(OnInteractableDeactivated)));
		
		//初始碰撞层
		CollisionLayer = 1;
	}
	
	private void OnInteractableActivated()
	{
		animatedSprite2D?.Play("open_door");
		//临时修改mask来避免碰撞
		CollisionLayer = 2;
		GD.Print("actived");
	}
	
	private void OnInteractableDeactivated()
	{
		animatedSprite2D?.Play("close_door");
		CollisionLayer = 1;
		GD.Print("deactived");
	}
}
