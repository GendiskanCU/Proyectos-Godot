using Godot;
using System;

public partial class Area2dLlave : Area2D
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
		// La llave desaparecerá
		QueueFree();
	}
}
