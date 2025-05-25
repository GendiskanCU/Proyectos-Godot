using Godot;
using System;

public partial class ParallaxLayer : Godot.ParallaxLayer
{
    public override void _Process(double delta)
    {
        MotionOffset += new Vector2(0, 50) * (float)delta;
    }

}
