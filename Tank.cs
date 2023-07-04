using Godot;
using System;

public partial class Tank : CharacterBody2D
{
    Signal _healthChanged;
    Signal _destroyed;

    [Export]
    public PackedScene Bullet;
    [Export]
    public int Speed;
    [Export]
    public float RotationSpeed;
    [Export]
    public float GunCooldown;
    [Export]
    public int Health;
    public Boolean CanShoot = false;
    public Boolean Alive = true;

    public override void _Ready()
    {
        var gunTimer = GetNode<Timer>("GunTimer");
        gunTimer.WaitTime = GunCooldown;
    }

    public void Control(double delta) {}
    public override void _PhysicsProcess(double delta)
    {
        if(!Alive)
        {
            return;
        }
        Control(delta);
        MoveAndSlide();
    }


}
