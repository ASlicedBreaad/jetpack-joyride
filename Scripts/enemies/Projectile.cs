using System;
using Godot;

namespace JetpackJoyride.Scripts.enemies;

public partial class Projectile : Enemy
{
	private Vector2 _velocityStep = new Vector2();
	private Vector2 _newVelocity = new Vector2();

	public Projectile() : base()
	{
	}

	public override void _EnterTree()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
	}


}
