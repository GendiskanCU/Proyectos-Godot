using Godot;
using System;

public partial class Copo : Area2D
{
    private Vector2 velocidad;

    public Vector2 Velocidad { get => velocidad; set => velocidad = value; }


    public override void _Ready()
    {

        Velocidad = new Vector2(GD.Randi() % 20, 100);
    }

    public override void _Process(double delta)
    {
        Position += Velocidad * (float)delta;
    }

    public void _on_body_entered(Node otro)
    {
        // Cuando el copo colisione con el texto u otro "body", se detendrá
        Velocidad = new Vector2(0, 0);
    }

    public void _on_area_entered(Node otro)
    {
        // Cuando el copo colisione con otro copo que ya está detenido, éste también se detendrá

        if (((Copo)otro).Velocidad.Y <= 0)
        {
            Velocidad = new Vector2(0, 0);
        }
            
    }
}
