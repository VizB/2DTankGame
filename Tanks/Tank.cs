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

    private bool _canShoot = false;
    private bool _alive = true;
 

    public override void _Ready()
    {
        var gunTimer = GetNode<Timer>("GunTimer");
        gunTimer.WaitTime = GunCooldown;
    }

    protected virtual void Control(float delta) {}

    public override void _PhysicsProcess(double delta)
    {
        if(!_alive)
        {
            return;
        }
        Control((float)delta);
        MoveAndSlide();
    }


}
