using Godot;
using System;

public partial class ParallaxBackground : Parallax2D
{
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Autoscroll = new Vector2(-350,0);
		ScrollScale = new Vector2((float)0.6,0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// ScrollBaseOffset += new Vector2((float)(-350*delta),0);
		// Autoscroll-= new Vector2((float)delta*350,0);
	}
	
	
}
