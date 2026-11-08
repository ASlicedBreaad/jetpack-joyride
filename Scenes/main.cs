using Godot;
using JetpackJoyride.Scripts.enemies;
using System;

public partial class main : Node2D
{
	private Timer _enemyTimerSpawn;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		_enemyTimerSpawn = new Timer() { WaitTime = 1, OneShot = false };
		EnemyStats spitStats = GD.Load<EnemyStats>("res://Resources/EnemyStats/Spit.tres");
		Camera2D levelCamera = GetNode<Camera2D>("Camera2D");


		Vector2 center = levelCamera.GetScreenCenterPosition();

		Vector2 halfSize = (GetViewport().GetVisibleRect().Size / levelCamera.Zoom) * 0.5f;

		float leftEdge = center.X - halfSize.X;
		float rightEdge = center.X + halfSize.X;
		float topEdge = center.Y - halfSize.Y;
		float bottomEdge = center.Y + halfSize.Y;
		Enemy newEnemy;

		_enemyTimerSpawn.Timeout += () =>
		{
			newEnemy = spitStats.Scene.Instantiate<Projectile>();
			newEnemy.Stats = spitStats;
			newEnemy.Position = new Vector2(rightEdge - 200, bottomEdge - 300);
			AddChild(newEnemy);
			newEnemy.Initialize(spitStats);
		};
		AddChild(_enemyTimerSpawn);
		_enemyTimerSpawn.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
