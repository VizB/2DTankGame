using Godot;
using System;


public partial class Player : Tank
{
    protected override void Control(float delta) {
        GetNode<Sprite2D>("Turret").LookAt(GetGlobalMousePosition());

        var rotDir = 0;
        if(Input.IsActionPressed("move_right")) 
        {
            rotDir++;
        }

        if(Input.IsActionPressed("move_left")) 
        {
            rotDir--;   
        }

        if (Input.IsActionJustPressed("Shoot"))
        {
            ShootBullet();
        }
        Rotation += RotationSpeed * rotDir * delta;
        var velocity = new Vector2();

        if(Input.IsActionPressed("forward"))
        {
            velocity = new Vector2(Speed, 0).Rotated(Rotation);
        }

        if (Input.IsActionPressed("backward"))
        {
            velocity = new Vector2(-Speed / 2, 0).Rotated(Rotation);
        }
        Position += velocity * (float) delta;    
    }
}
