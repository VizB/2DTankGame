using Godot;
using System;


public partial class Game : Node2D
{
    public override void _Ready()
    {
        CharacterBody2D player = GetNode<CharacterBody2D>("Player");
    }
       
}
