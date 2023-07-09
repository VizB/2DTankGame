using Godot;
using System;

public partial class TileSetMaker : Node
{
    private Vector2 _tileSize = new Vector2(128, 128);

    public override void _Ready()
    {
        var texture = GetNode<Sprite2D>("Sprite");
    }
}
