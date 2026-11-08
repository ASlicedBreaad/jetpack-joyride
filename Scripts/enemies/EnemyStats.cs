using System;
using Godot;

namespace JetpackJoyride.Scripts.enemies;

[GlobalClass]
public partial class EnemyStats : Resource
{
    [Export] public string Name {get;set;} = "Undefined Enemy";
    [Export] public PackedScene Scene {get;set;}
    [Export] public float HorSpeed {get;set;}
    [Export] public float VerSpeed {get;set;}
    [Export] public Texture2D Texture {get;set;}
    [Export] public int Health {get;set;}
}
