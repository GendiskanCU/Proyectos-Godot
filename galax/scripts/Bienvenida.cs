using Godot;
using System;

public partial class Bienvenida : Control
{
    public void _on_boton_comenzar_pressed()
    {
        // Abrirá la escena del juego
        GetTree().ChangeSceneToFile("res://escena_de_juego.tscn");
    }
}
