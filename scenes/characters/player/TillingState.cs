using Godot;
using System;

public partial class TillingState : NodeState
{
	[Export]
	public Player Player;
	[Export]
	public AnimatedSprite2D AnimatedSprite2D;
	
	// 可由子类重写的保护方法
	public override void OnProcess(double delta)
	{
		// 默认不做任何处理
	}

	public override void OnPhysicsProcess(double delta)
	{
		// 默认不做任何处理
	}

	// 与 GDScript 示例中对应的方法
	public override void OnNextTransitions()
	{
		// 由子类实现状态转换判定
		if (!AnimatedSprite2D.IsPlaying()) {
			EmitSignal(nameof(Transition), "Idle");
		}
	}

	public override void OnEnter()
	{
		// 进入状态时的初始化
		if (Player.PlayerDirection == Vector2.Up) {
			AnimatedSprite2D.Play("tilling_back");
		}
		else if (Player.PlayerDirection == Vector2.Down) {
			AnimatedSprite2D.Play("tilling_front");
		}
		else if (Player.PlayerDirection == Vector2.Left) {
			AnimatedSprite2D.Play("tilling_left");
		}
		else if (Player.PlayerDirection == Vector2.Right) {
			AnimatedSprite2D.Play("tilling_right");
		}
		else {
			AnimatedSprite2D.Play("tilling_front");
		}
	}

	public override void OnExit()
	{
		// 退出状态时的清理
		AnimatedSprite2D.Stop();
	}
}
