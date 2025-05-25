using Godot;
using System;
using System.Threading.Tasks;

public partial class EscenaDeJuego : Node2D
{
    private int puntos;

    private int vidas;

    // Para mostrar las explosiones
    private PackedScene explosion;

    // Para controlar el número de enemigos en la escena
    private Node contenedorEnemigos;

    // Para controlar cuándo el juego está en marcha
    private bool juegoActivo = true;

    // Tiempo entre disparos (milisegundos)
    private int tiempoHastaDisparo = 3000;

    public override void _Ready()
    {
        puntos = GameManager.Puntos;
        GetNode<Label>("TextoPuntos").Text = "Puntos: " + puntos;

        vidas = GameManager.Vidas;
        GetNode<Label>("TextoVidas").Text = "Vidas: " + vidas;

        explosion = GD.Load<PackedScene>("res://explosion.tscn");

        contenedorEnemigos = GetNode("ContenedorEnemigos");

        PrepararDisparo();
    }



    public void IncrementarPuntos()
    {
        puntos += 10;
        GameManager.Puntos = puntos;

        GD.Print("Puntos: " + puntos);

        GetNode<Label>("TextoPuntos").Text = "Puntos: " + puntos;
    }


    public async Task Explotar(float x, float y)
    {
        
        var nuevaExplosion = explosion.Instantiate();
        // Añade la nueva explosión a la escena
        AddChild(nuevaExplosion);
        // Reproduce el sonido
        GameManager.SonidoExplosion.Play();
        // La sitúa en la posición recibida
        ((CpuParticles2D)nuevaExplosion).Position = new Vector2(x, y);
        // La activa
        ((CpuParticles2D)nuevaExplosion).Emitting = true;

        // Comprueba cuántos enemigos quedan en la escena
        GD.Print("Explotando. Quedan: " +
        contenedorEnemigos.GetChildCount());
        if (contenedorEnemigos.GetChildCount() <= 1)
        {
            if (GameManager.Nivel == 1)
            {
                GameManager.VelocidadEnemigo += 50;
                GameManager.Nivel = 2;
                GetTree().ChangeSceneToFile("res://escena_de_juego2.tscn");                
            }
            else
            {
                GetNode<Label>("TextoPartidaGanada").Visible = true;
                // Pause
                await Task.Delay(2000);

                GetTree().ChangeSceneToFile("res://bienvenida.tscn");
            }
        }
    }




    public async Task PrepararDisparo()
    {
        while (juegoActivo)
        {
            await Task.Delay(tiempoHastaDisparo);
            tiempoHastaDisparo = GD.RandRange(1000, 3000);
            Disparar();
        }
    }


    public void Disparar()
    {
        // Escoge qué enemigo va a disparar
        int numEnemigo = GD.RandRange(0, contenedorEnemigos.GetChildCount() - 1);
        GD.Print("Enemigo disparando: " + numEnemigo);
        GetNode("ContenedorEnemigos").GetChild<Enemigo>(numEnemigo).Disparar();
        GameManager.SonidoDisparoEnemigo.Play();
    }


    public async Task PerderVida()
    {
        vidas--;
        GameManager.Vidas = vidas;
        GetNode<Label>("TextoVidas").Text = "Vidas: " + vidas;

        // Obtiene la posición de la nave para mostrar ahí la explosión
        float x = GetNode<Nave>("Nave").Position.X;
        float y = GetNode<Nave>("Nave").Position.Y;
        Explotar(x, y);

        // Recoloca la nave y los enemigos
        GetNode<Nave>("Nave").Recolocar();
        for (int i = 0; i < contenedorEnemigos.GetChildCount(); i++)
        {
            contenedorEnemigos.GetChild<Enemigo>(i).Recolocar();
        }

        // Comprueba derrota
        if (vidas <= 0)
        {
            await Task.Delay(2000);
            GetTree().ChangeSceneToFile("res://bienvenida.tscn");
        }
    }
}
