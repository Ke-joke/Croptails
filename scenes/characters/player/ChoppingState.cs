using Godot;
using System;

public partial class ChoppingState : NodeState
{
	[Export]
	public Player Player;
	[Export]
	public AnimatedSprite2D AnimatedSprite2D;
	[Export]
	public CollisionShape2D HitComponentCollisionShape;
	
	public override void _Ready()
	{
		HitComponentCollisionShape.Disabled = true;
		HitComponentCollisionShape.Position = new Vector2(0, 0);
	}
	
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
			AnimatedSprite2D.Play("chopping_back");
			HitComponentCollisionShape.Position = new Vector2(0, -18);
		}
		else if (Player.PlayerDirection == Vector2.Down) {
			AnimatedSprite2D.Play("chopping_front");
			HitComponentCollisionShape.Position = new Vector2(0, 3);
		}
		else if (Player.PlayerDirection == Vector2.Left) {
			AnimatedSprite2D.Play("chopping_left");
			HitComponentCollisionShape.Position = new Vector2(-9, 0);
		}
		else if (Player.PlayerDirection == Vector2.Right) {
			AnimatedSprite2D.Play("chopping_right");
			HitComponentCollisionShape.Position = new Vector2(9, 0);
		}
		else {
			AnimatedSprite2D.Play("chopping_front");
			HitComponentCollisionShape.Position = new Vector2(0, 3);
		}
		
		HitComponentCollisionShape.Disabled = false;
	}

	public override void OnExit()
	{
		// 退出状态时的清理
		AnimatedSprite2D.Stop();
		HitComponentCollisionShape.Disabled = true;
	}
}
