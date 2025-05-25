using Godot;
using System;

public partial class Bienvenida : Control
{
    private Sprite2D fondo;

    public override void _Ready()
    {
        GameManager.Puntos = 0;
        GameManager.Vidas = 3;
        GameManager.Nivel = 1;
        GameManager.VelocidadEnemigo = 150;

        fondo = GetNode<Sprite2D>("Fondo");
    }

    public override void _Process(double delta)
    {
        fondo.Position += new Vector2(0, -100) * (float)delta;

        if (fondo.Position.Y < -512)
        {
            fondo.Position = new Vector2(0, 0);
        }
    }



    public void _on_boton_comenzar_pressed()
    {
        // Abrirá la escena del juego
        GetTree().ChangeSceneToFile("res://escena_de_juego.tscn");
    }
}
