using Godot;
using System;

public partial class ChoppingState : NodeState
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
