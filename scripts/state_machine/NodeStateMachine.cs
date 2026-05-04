using Godot;
using System;
using System.Collections.Generic;

public partial class NodeStateMachine : Node
{
	[Export] public NodeState InitialNodeState;
	
	private Dictionary<string, NodeState> nodeStates = new Dictionary<string, NodeState>(StringComparer.OrdinalIgnoreCase);
	private NodeState currentNodeState;
	private string currentNodeStateName;
	private string parentNodeName;
	
	public override void _Ready()
	{
		foreach (Node child in GetChildren()) 
		{
			if (child is NodeState ns)
			{
				nodeStates[ns.Name.ToString().ToLowerInvariant()] = ns;
				ns.Connect(nameof(ns.Transition), new Callable(this, nameof(TransitionTo)));
			}
		}
		
		if (InitialNodeState != null)
		{
			InitialNodeState.OnEnter();
			currentNodeState = InitialNodeState;
			currentNodeStateName = currentNodeState.Name.ToString().ToLowerInvariant();
		}
		parentNodeName = GetParent().Name.ToString().ToLowerInvariant();
	}
	
	public override void _Process(double delta)
	{
		currentNodeState?.OnProcess(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (currentNodeState != null)
		{
			currentNodeState.OnPhysicsProcess(delta);
			currentNodeState.OnNextTransitions();
		}
	}
	
	public void TransitionTo(string nodeStateName)
	{
		if (currentNodeState != null && nodeStateName == currentNodeState.Name.ToString().ToLowerInvariant())
			return;

		nodeStates.TryGetValue(nodeStateName.ToLowerInvariant(), out var newNodeState);

		if (newNodeState == null)
			return;

		currentNodeState?.OnExit();

		newNodeState.OnEnter();

		currentNodeState = newNodeState;
		currentNodeStateName = currentNodeState.Name.ToString().ToLowerInvariant();
		GD.Print(parentNodeName, " transitioned to state: ", currentNodeStateName);
		GD.Print("Current State: ", currentNodeStateName);
	}
}
