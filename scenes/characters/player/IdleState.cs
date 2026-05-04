using Godot;
using System;

public partial class IdleState : NodeState
{
	[Export]
	public Player Player;
	[Export]
	public AnimatedSprite2D AnimatedSprite2D;
	
	public override void _Ready()
	{
		// Player = GetNodeOrNull<Player>("../..");
		// AnimatedSprite2D = Player?.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		// if (Player == null || AnimatedSprite2D == null)
		// {
		// 	GD.PrintErr("IdleState: Failed to get Player or AnimatedSprite2D node.");
		// }
	}


	public override void OnPhysicsProcess(double delta)
	{
		
		if (AnimatedSprite2D.IsPlaying())
		{
			return;
		}
		if (Player.PlayerDirection == Vector2.Up)
		{
			AnimatedSprite2D.Play("idle_back");
		}
		else if (Player.PlayerDirection == Vector2.Down)
		{
			AnimatedSprite2D.Play("idle_front");
		}
		else if (Player.PlayerDirection == Vector2.Left)
		{
			AnimatedSprite2D.Play("idle_left");
		}
		else if (Player.PlayerDirection == Vector2.Right)
		{
			AnimatedSprite2D.Play("idle_right");
		}
		else
		{
			AnimatedSprite2D.Play("idle_front");
		}
		
	}

	public override void OnNextTransitions()
	{
		GameInputEvents.MovementInput();
		if (GameInputEvents.IsMovementInput())
		{
			EmitSignal(nameof(Transition), "Walk");
		}
	}

	public override void OnEnter()
	{
		// 进入状态时的初始化
	}

	public override void OnExit()
	{
		// 退出状态时的清理
		AnimatedSprite2D.Stop();
	}
}
