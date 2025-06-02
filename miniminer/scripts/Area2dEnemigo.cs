using Godot;
using System;
using System.Numerics;

public partial class Area2dEnemigo : Area2D
{
	[Export] private Godot.Vector2 posInicial, posFinal;
	[Export] private float velocidad;
	private Godot.Vector2 destino;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = posInicial;
		destino = posFinal;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = Position.MoveToward(destino, velocidad * (float)delta);

		if (Position.DistanceTo(destino) < 2)
		{
			if (destino == posFinal)
			{
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Scale = new Godot.Vector2(-1, 1); // Gira el sprite
				destino = posInicial;
			}
			else
			{
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Scale = new Godot.Vector2(1, 1);
				destino = posFinal;
			}
		}
	}
}
