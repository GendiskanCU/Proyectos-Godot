using Godot;
using System;

public partial class DisparoEnemigo : Area2D
{
    private Vector2 velocidad;

    public override void _Ready()
    {
        velocidad = new Vector2(0, 150);
    }

    public override void _Process(double delta)
    {
        Position += velocidad * (float)delta;

        if (Position.Y > 1000)
        {
            QueueFree(); // Destruye el disparo de la cola
        }
    }

    public void _on_area_entered(Area2D otro)
    {

        //if (otro is Nave)   // Ya se comprueba automáticamente definiendo las capas de colisiones
        //{
        GD.Print("Jugador alcanzado!");

        GetNode<EscenaDeJuego>("/root/EscenaDeJuego").PerderVida();

        // Elimina el disparo
        this.QueueFree();

        //}
    }
}
