using Godot;
using System;

public partial class Copo : Area2D
{
    private Vector2 velocidad;
    public override void _Ready()
    {
        // Posición del copo al azar (entre 0-999 en ancho y 0-499 en alto)
        Position = new Vector2(GD.Randi() % 1000, -GD.Randi() % 500);
        // Velocidad fija en y, aleatoria en x
        velocidad = new Vector2(GD.Randi() % 20, 100);
    }

    public override void _Process(double delta)
    {
        Position += velocidad * (float)delta;

        if (Position.Y > 700)
        {
            // Cuando el copo desaparezca por abajo, volverá a la parte de arriba (en posición aleatoria en x)
            Position = new Vector2(GD.Randi() % 1000, -10);        
        }
    }
}
