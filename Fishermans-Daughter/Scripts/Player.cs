using Godot;
using System;

public partial class Player : Area2D
{

	// MoveAmount set to 32, the size of the tile
    public int moveAmount = 32;
	public float speed;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Vector2 newPosition = Position;

        // Calculate the potential new position based on input
        if (Input.IsActionJustPressed("ui_up"))
        {
            newPosition += new Vector2(0, -moveAmount);
        }
        if (Input.IsActionJustPressed("ui_down"))
        {
            newPosition += new Vector2(0, moveAmount);
        }
        if (Input.IsActionJustPressed("ui_left"))
        {
            newPosition += new Vector2(-moveAmount, 0);
        }
        if (Input.IsActionJustPressed("ui_right"))
        {
            newPosition += new Vector2(moveAmount, 0);
        }

        // Check for collisions at the new position
        var collision = GetNode<TileMapLayer>("../Borders").GetCellTileData((Vector2I)(newPosition / moveAmount));
        
        if (collision == null)
        {
            // No collision, update the player's position
            Position = newPosition;
        }
        else
        {
            GD.Print("Collision detected!");
        }
    }
	
	}