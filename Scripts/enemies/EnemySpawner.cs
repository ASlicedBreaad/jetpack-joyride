using System;
using System.Collections.Generic;
using Godot;

namespace JetpackJoyride.Scripts.enemies;

public partial class EnemySpawner : Node
{
    // Uses the 
    [Export] public Godot.Collections.Array<EnemyStats> EnemyTypes { get; set; } = new();
    private readonly Dictionary<string, EnemyStats> _lookup = new();


}
