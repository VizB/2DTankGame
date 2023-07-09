using Godot;
using System;


public partial class Player : Tank
{
    protected override void Control(float delta) {
        GD.Print("In derived class");
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

        Rotation += RotationSpeed * rotDir * delta;
        GD.Print("Rotation Direction: "+ rotDir);
        GD.Print("delta: "+ delta);
        GD.Print("Rotation: "+ Rotation);
        var velocity = new Vector2();

        if(Input.IsActionPressed("forward")) 
        {
            GD.Print("Forward");
            velocity = new Vector2(Speed, 0).Rotated(Rotation);
        }

        if (Input.IsActionPressed("backward"))
        {
            GD.Print("Backward");
            velocity = new Vector2(-Speed / 2, 0).Rotated(Rotation);
        }
        Position += velocity * (float) delta;    
    }
}
