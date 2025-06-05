using Godot;
using System;

public partial class Nivel : Node2D
{

	[Export] public int llavesPendientes;

	[Export] public int numeroNivel;

	public const int MAXIMO_NIVEL = 2;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Label>("Label_TextoPuntos").Text = "Puntos: " + GestorJuego.Puntos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void ComprobarPuerta()
	{
		GD.Print("Puerta tocada");

		if (llavesPendientes <= 0)
		{
			numeroNivel++;
			if (numeroNivel > MAXIMO_NIVEL)
			{
				numeroNivel = 1; // Vuelve al primer nivel
			}
			// Cambia de nivel
			GetTree().ChangeSceneToFile("res://escenas/nivel_" + numeroNivel.ToString("00") + ".tscn");
		}
	}

	public void RecogerUnaLlave()
	{
		llavesPendientes--;
		GD.Print("Llaves pendientes: " + llavesPendientes);

		GestorJuego.Puntos += 10;
		GetNode<Label>("Label_TextoPuntos").Text = "Puntos: " + GestorJuego.Puntos;
	}
}
