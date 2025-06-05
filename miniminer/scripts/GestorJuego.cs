using Godot;
using System;

public partial class GestorJuego : Node
{
	public static int Puntos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Puntos = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
