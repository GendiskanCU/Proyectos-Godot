using Godot;
using System;

public partial class Area2dPuerta : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_body_entered(CharacterBody2D otro)
	{
		// Cuando el personaje toque la puerta se llamará al método correspondiente del script en el padre (nodo "Nivel")
		GetParent().Call("ComprobarPuerta");
	}
}
