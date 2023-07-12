using Godot;
//using System;
using Signal = Godot.Signal;

public partial class Tank : CharacterBody2D
{
    [Signal]
    public delegate void HealthChangedEventHandler();

    [Signal]
    public delegate void DestroyedEventHandler();
    
    [Signal]
    public delegate void ShootEventHandler(PackedScene bullet, Vector2 position, Vector2 direction);
    
    [Export] public PackedScene Bullet;
    [Export] public int Speed;
    [Export] public float RotationSpeed;
    [Export] public float GunCooldown;
    [Export] public int Health;
    [Export] public bool TakesDamage;

    private bool _canShoot = true;
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
    
    protected void ShootBullet()
    {
        if (!_canShoot) return;
        _canShoot = false;
        var turret = GetNode<Sprite2D>("Turret");
        var muzzle = GetNode<Marker2D>("Turret/Marker2D");
        GetNode<Timer>("GunTimer").Start();
        var dir = new Vector2(1, 0).Rotated(turret.GlobalRotation);
        EmitSignal(nameof(Shoot), Bullet, muzzle.GlobalPosition, dir);
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            GD.Print("Dead");
            GD.Print("Somehow go back to the start i guess");
        }
    }
    
    public void OnGunTimerTimeout()
    {
        _canShoot = true;
    }   
}
