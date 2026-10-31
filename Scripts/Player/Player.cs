using Godot;
using JetpackJoyride.Scripts.Common;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 300.0f;
	private const float JumpVelocity = -600.0f;

	private float Acceleration = -500f;

	private float EarthGravity = 0;

	private float AccelerationStep;

	private float NewAcceleration;

	private readonly InputKeyMap IK = InputKeyMap.GetInstance;


    public override void _Ready()
	{
		EarthGravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle()*3f;
		AccelerationStep = -EarthGravity*1.2f;
	}



	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionPressed(IK.Jump))
		{
			NewAcceleration = (float)(AccelerationStep*delta);
			velocity.Y += (float)Mathf.Clamp(NewAcceleration,-EarthGravity*delta*2,-EarthGravity*delta);

			GD.Print($"Curent:{NewAcceleration} min:{-EarthGravity*delta*2} max:{-EarthGravity*delta}");
		}

		// // Get the input direction and handle the movement/deceleration.
		// // As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		// if (direction != Vector2.Zero)
		// {
		// 	velocity.X = direction.X * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// }

		Velocity = velocity;
		MoveAndSlide();
	}
}
