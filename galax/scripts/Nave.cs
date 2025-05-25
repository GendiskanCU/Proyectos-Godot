using Godot;
using System;

public partial class Nave : Area2D
{
	// Velocidad de la nave (píxeles por segundo)
	private int velocidad_nave = 100;

	private PackedScene disparo;

	private Vector2 posicionInicial;

	public override void _Ready()
	{
		disparo = GD.Load<PackedScene>("res://disparo.tscn");

		posicionInicial = Position;
	}

	public override void _Process(double delta)
	{
		//GD.Print(delta);
		if (Input.IsActionPressed("ui_right"))
		{
			Position += new Vector2(velocidad_nave * (float)delta, 0);
		}
		if (Input.IsActionPressed("ui_left"))
		{
			Position -= new Vector2(velocidad_nave * (float)delta, 0);
		}

		if (Input.IsActionJustPressed("ui_accept"))
		{
			var nuevoDisparo = disparo.Instantiate();
			GameManager.SonidoDisparoNave.Play();

			// Añade el nuevo disparo a la escena padre
			GetParent().AddChild(nuevoDisparo);
			// Lo sitúa en la posición de la nave
			((Area2D)nuevoDisparo).Position = Position;
		}

	}


	public void Recolocar()
	{
		Position = posicionInicial;
	}
}
