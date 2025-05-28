using Godot;
using System;

public partial class Nieve2 : Node2D
{
    private PackedScene escenaCopo;

     private float factorGeneracion = 0.1f;
    public override void _Ready()
    {
        escenaCopo = GD.Load<PackedScene>("res://copo.tscn");
    }

    public override void _Process(double delta)
    {
        // Se obtiene un número al azar, y en función de si está por encima o no del factor de generación se genera un nuevo copo
        if (GD.Randf() < factorGeneracion)
        {
            // Se instancia el copo
            var copo = escenaCopo.Instantiate<Area2D>();
            // Se establece su posición x al azar, dentro del ancho de la ventana
            copo.Position = new Vector2(GD.Randi() % 1000, -10);
            // Se añade el copo a la escena
            AddChild(copo);
        }
    }
}
