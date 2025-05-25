using Godot;
using System;

public partial class Disparo : Area2D
{
    private Vector2 velocidad;

    public override void _Ready()
    {
        velocidad = new Vector2(0, -150);
    }

    public override void _Process(double delta)
    {
        Position += velocidad * (float)delta;

        if (Position.Y < -10)
        {
            QueueFree(); // Destruye el disparo de la cola
        }
    }

    public void _on_area_entered(Area2D otro)
    {

        //if (otro is Enemigo)
        {
            GD.Print("Boom!");

            // Llamada al método que incrementa los puntos del script del nodo EscenaDeJuego
            GetNode("/root/EscenaDeJuego").Call("IncrementarPuntos");

            otro.QueueFree();
            QueueFree();

            // Llamada al método que mostrará la explosión
            GetNode<EscenaDeJuego>("/root/EscenaDeJuego").Explotar(Position.X, Position.Y);
        }
    }
}
