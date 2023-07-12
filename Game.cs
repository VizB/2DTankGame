using Godot;
using System;


public partial class Game : Node2D
{
    public override void _Ready()
    {
        SetCameraLimits();
    }

    public void OnTankShoot(PackedScene bullet, Vector2 position, Vector2 direction)
    {
        var b = bullet.Instantiate<Bullet>();
        GetTree().Root.AddChild(b);
        b.Start(position, direction);
    }
    
    public void SetCameraLimits()
    {
        var playerCamera = GetNode<Camera2D>("Player/Camera2D");
        var ground = GetNode<TileMap>("Ground");
        var mapLimits = ground.GetUsedRect();
        var mapCellSize = ground.CellQuadrantSize;
        playerCamera.LimitLeft = mapLimits.Position.X * mapCellSize;
        playerCamera.LimitRight = mapLimits.End.X * mapCellSize;
        playerCamera.LimitTop = mapLimits.Position.Y * mapCellSize;
        playerCamera.LimitBottom = mapLimits.End.Y * mapCellSize;
    }
}
