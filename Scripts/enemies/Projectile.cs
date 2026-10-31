using System;
using Godot;

namespace JetpackJoyride.Scripts.enemies;

public partial class Projectile : RigidBody2D
{
    private Vector2 _velocityStep = new Vector2();

    public override void _EnterTree()
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        
    }

    public void SetHorVelocityStep(float velocity)
    {
        _velocityStep.X = velocity;
    }

    public void SetVerVelocityStep(float velocity)
    {
        _velocityStep.Y = velocity;
    }
}
