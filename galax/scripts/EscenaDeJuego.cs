using Godot;
using System;
using System.Threading.Tasks;

public partial class EscenaDeJuego : Node2D
{
    private int puntos;

    // Para mostrar las explosiones
    private PackedScene explosion;

    // Para controlar el número de enemigos en la escena
    private Node contenedorEnemigos;

    public override void _Ready()
    {
        puntos = 0;

        explosion = GD.Load<PackedScene>("res://explosion.tscn");

        contenedorEnemigos = GetNode("ContenedorEnemigos");
    }



    public void IncrementarPuntos()
    {
        puntos += 10;
        GD.Print("Puntos: " + puntos);

        GetNode<Label>("TextoPuntos").Text = "Puntos: " + puntos;
    }


    public async Task Explotar(float x, float y)
    {
        var nuevaExplosion = explosion.Instantiate();
        // Añade la nueva explosión a la escena
        AddChild(nuevaExplosion);
        // La sitúa en la posición recibida
        ((CpuParticles2D)nuevaExplosion).Position = new Vector2(x, y);
        // La activa
        ((CpuParticles2D)nuevaExplosion).Emitting = true;

        // Comprueba cuántos enemigos quedan en la escena
        GD.Print("Explotando. Quedan: " +
        contenedorEnemigos.GetChildCount());
        if (contenedorEnemigos.GetChildCount() <= 1)
        {
            GetNode<Label>("TextoPartidaGanada").Visible = true;
            // Pause
            await Task.Delay(2000);
            
            GetTree().ChangeSceneToFile("res://bienvenida.tscn");
        }
    }
}
