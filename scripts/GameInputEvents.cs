using Godot;

public partial class GameInputEvents 
{
	// Called when the node enters the scene tree for the first time.
	private static Vector2 direction;

	public static Vector2 MovementInput()
	{
		if (Input.IsActionPressed("walk_right"))
		{
			direction = Vector2.Right;
		} else if (Input.IsActionPressed("walk_left"))
		{
			direction = Vector2.Left;
		}
		else if (Input.IsActionPressed("walk_down"))
		{
			direction = Vector2.Down;
		}
		else if (Input.IsActionPressed("walk_up"))
		{
			direction = Vector2.Up;
		}
		else
		{
			direction = Vector2.Zero;
		}
		return direction;
	}

	public static bool IsMovementInput()
	{
		return direction != Vector2.Zero;
	}
	
	public static bool UseTool()
	{
		bool UseToolValue = Input.IsActionJustPressed("hit");
		return UseToolValue;
	}
}
