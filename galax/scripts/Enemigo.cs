using Godot;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Enemigo : Area2D
{
    private Vector2 velocidad = new Vector2(150, 0);

    private float xMax, xMin;

    // Referencia al sprite
    private AnimatedSprite2D animacion;

    public override void _Ready()
    {
        xMin = Position.X - 200;
        xMax = Position.X + 200;

        animacion = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animacion.Play(); // Inicia la animación
    }


    public override void _Process(double delta)
    {
        Position += velocidad * (float)delta;

        if (Position.X > xMax)
        {
            velocidad = new Vector2(-150, 0);
        }
        if (Position.X < xMin)
        {
            velocidad = new Vector2(150, 0);
        }
    }


}
