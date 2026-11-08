using System;
using System.Runtime.CompilerServices;
using Godot;

namespace JetpackJoyride.Scripts.enemies;

public abstract partial class Enemy : RigidBody2D
{
    [Signal] public delegate void GetOutEventHandler(Enemy enemy);
    public string EnemyName { get; set; }
    public PackedScene Scene { get; set; }
    public Vector2 Speed { get; set; }
    
    // Set Export later
    public EnemyStats Stats { get;  set; }

    public Sprite2D Sprite {get;protected set;}
    // Is it out of the screen or simply destroyed. Only Enemy class can handle Out status
    public bool IsOut { get; private set; }

    
    public int Health { get; set; }

    public virtual void Initialize(EnemyStats stats)
    {
        Stats = stats;
        EnemyName = Stats.Name;
        Scene = Stats.Scene;
        Speed = new Vector2(Stats.HorSpeed, Stats.VerSpeed);
        Sprite = GetNode<Sprite2D>("Sprite2D");
        Sprite.Texture = Stats.Texture;
        Health = Stats.Health;
        GravityScale = 0.0f;
        Mass = 1;
        GetNode<CollisionPolygon2D>("CollisionPolygon2D").Disabled = true;
        OnSpawn();
    }

    // Class used to define sub-class specific actions. Especially useful in sub-classes so that we only need to modify OnSpawn for changes to occur (like resetting a sub-class specific counter or something)
    public virtual void OnSpawn()
    {
        IsOut = false;
        AddConstantCentralForce(Speed);
    }

    public virtual void OnOut()
    {
        // Avoid double outing 
        if (IsOut) return;
        IsOut = false;

        // Signal to Enemy Director that this enemy is out and to handle object pooling then
        EmitSignal(SignalName.GetOut, this);
    }

    public virtual void SetHorVelocityStep(float velocity)
    {
        
        Vector2 newVelocity = new Vector2(velocity, ConstantForce.Y);
        ConstantForce = new Vector2(0, 0);
        ConstantForce = new Vector2(0, 0);
        AddConstantCentralForce(Speed);
    }

    public virtual void SetVerVelocityStep(float velocity)
    {
        Speed = new Vector2(Speed.X,velocity);
        ConstantForce = new Vector2(0, 0);
        AddConstantCentralForce(Speed);

    }

    public override void _EnterTree()
    {
        AddConstantCentralForce(Speed);
    }

}
