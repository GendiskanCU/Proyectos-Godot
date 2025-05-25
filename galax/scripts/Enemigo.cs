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

    private PackedScene disparo;

    private Vector2 posicionInicial;



    public override void _Ready()
    {
        posicionInicial = Position;

        xMin = Position.X - 200;
        xMax = Position.X + 200;

        animacion = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animacion.Play(); // Inicia la animación

        disparo = GD.Load<PackedScene>("res://disparo_enemigo.tscn");
    }


    public override void _Process(double delta)
    {
        Position += velocidad * (float)delta;

        if (Position.X > xMax)
        {
            velocidad = new Vector2(-GameManager.VelocidadEnemigo, 0);
        }
        if (Position.X < xMin)
        {
            velocidad = new Vector2(GameManager.VelocidadEnemigo, 0);
        }
    }


    public void Disparar()
    {
        var nuevoDisparo = disparo.Instantiate();

        // Añade el nuevo disparo a la escena padre
        GetParent().GetParent().AddChild(nuevoDisparo);
        // Lo sitúa en la posición del enemigo
        ((Area2D)nuevoDisparo).Position = Position;
    }

    public void Recolocar()
    {
        Position = posicionInicial;
    }

}
