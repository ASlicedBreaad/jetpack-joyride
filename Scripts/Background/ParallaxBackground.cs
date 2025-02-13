using Godot;
using System;

public partial class ParallaxBackground : Godot.ParallaxBackground
{
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ScrollBaseOffset += new Vector2((float)(-350*delta),0);
	}
}
