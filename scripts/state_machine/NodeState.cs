using Godot;
using System;

public partial class NodeState : Node
{
	[Signal]
	public delegate void TransitionEventHandler(string nodeStateName);

	// 将 Godot 的回调转发到可重写的方法，便于派生类实现逻辑
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
	}

	// 可由子类重写的保护方法
	public virtual void OnProcess(double delta)
	{
		// 默认不做任何处理
	}

	public virtual void OnPhysicsProcess(double delta)
	{
		// 默认不做任何处理
	}

	// 与 GDScript 示例中对应的方法
	public virtual void OnNextTransitions()
	{
		// 由子类实现状态转换判定
	}

	public virtual void OnEnter()
	{
		// 进入状态时的初始化
	}

	public virtual void OnExit()
	{
		// 退出状态时的清理
	}
}
