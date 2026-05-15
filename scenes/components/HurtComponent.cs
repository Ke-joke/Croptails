using Godot;
using System;

public partial class HurtComponent : Area2D
{
	[Signal]
	public delegate void HurtEventHandler();
	[Export]
	public DataTypes.Tools Tool = DataTypes.Tools.None;
	
	public void OnAreaEntered(Area2D body)
	{
		if(body is HitComponent hitComponent)
		{
			GD.Print($"HurtComponent: Detected hit with tool {hitComponent.CurrentTool}. Required tool: {Tool}");
			if(Tool == hitComponent.CurrentTool)
			{
				EmitSignal(nameof(Hurt), hitComponent.HitDamage);
			}
		}
	}
}
