using Godot;
using System;

public partial class WalkState : NodeState
{
	[Export]
	public Player Player;
	[Export]
	public AnimatedSprite2D AnimatedSprite2D;

	[Export]
	private  float Speed = 50.0f;
	
	// 可由子类重写的保护方法
	public override void OnProcess(double delta)
	{
		// 默认不做任何处理
	}

	public override void OnPhysicsProcess(double delta)
	{
		// 默认不做任何处理
		var direction = GameInputEvents.MovementInput();
		Player.Velocity = direction * Speed;
		Player.MoveAndSlide();
		if (direction == Player.PlayerDirection && AnimatedSprite2D.IsPlaying())
		{
			return;
		}

		if (direction == Vector2.Up)
		{
			AnimatedSprite2D.Play("walk_back");
		}
		else if (direction == Vector2.Down)
		{
			AnimatedSprite2D.Play("walk_front");
		}
		else if (direction == Vector2.Left)
		{
			AnimatedSprite2D.Play("walk_left");
		}
		else if (direction == Vector2.Right)
		{
			AnimatedSprite2D.Play("walk_right");
		}
		if (direction != Vector2.Zero)
		{
			Player.PlayerDirection = direction;
		}
		
	}

	// 与 GDScript 示例中对应的方法
	public override void OnNextTransitions()
	{
		// 由子类实现状态转换判定
		GameInputEvents.MovementInput();
		if (!GameInputEvents.IsMovementInput())
		{
			EmitSignal(nameof(Transition), "Idle");
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
