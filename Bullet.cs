using Godot;
using System;
using Godot.Collections;

public partial class Bullet : Area2D
{
    [Export] public int Speed;
    [Export] public int Damage;
    [Export] public double Lifetime;
    [Export] public int Health;

    Vector2 _velocity = new Vector2();

    public void Start(Vector2 _position, Vector2 _direction)
    {
        Position = _position;
        Rotation = _direction.Angle();
        GetNode<Timer>("Lifetime").WaitTime = Lifetime;
        GetNode<Timer>("Lifetime").Start();
        _velocity = _direction * Speed;
    }

    public override void _Process(double delta)
    {
        Position += _velocity * (float)delta;
    }

    public void Explode()
    {
        QueueFree();
    }
    
    public void OnBulletBodyEntered(Tank body) 
    {
        Explode();
        if(body.TakesDamage)
        {
            body.TakeDamage(Damage);  
        }
    }

    public void OnLifetimeTimeout()
    {
        Explode();
    }
}