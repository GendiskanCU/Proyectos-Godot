using Godot;
using System;

public partial class Personaje : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		velocity.X = 0;
		if (Input.IsActionPressed("ui_right"))
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play(); // Inicia la animación
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Scale = new Godot.Vector2(1, 1); // Cambia el sentido del sprite
			velocity.X = Speed;			
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play(); // Inicia la animación
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Scale = new Godot.Vector2(-1, 1); // Cambia el sentido del sprite
			velocity.X = -Speed;			
		}
		else
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Stop(); // Detiene la animación cuando no se pulse tecla de movimiento
		}

	/**************************************************************************************
			Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			if (direction != Vector2.Zero)
			{
				velocity.X = direction.X * Speed;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		*/
		Velocity = velocity;
		MoveAndSlide();
	}
}
