using Godot;
using System;

public partial class AnimatableBody2dSueloFragil : AnimatableBody2D
{

	private RayCast2D rayo1, rayo2;

	private float velocidadCaida = 10;

	private float desplazamiento;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayo1 = GetNode<RayCast2D>("RayCast2D1");
		rayo2 = GetNode<RayCast2D>("RayCast2D2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Si el rayo está colisionando con algo (que solo puede ser el personaje en este caso)
		if (rayo1.IsColliding() || rayo2.IsColliding())
		{
			// La plataforma irá descendiendo
			Position += new Vector2(0, velocidadCaida * (float)delta);
			// Calcula cuánto se ha desplazado hasta ahora
			desplazamiento += velocidadCaida * (float)delta;
			// Cuando se haya desplazado tanto como es de alto el sprite (32 píxeles) la plataforma desaparecerá
			if (desplazamiento >= 32)
			{
				QueueFree();
			}
		}
	}
}
