using Godot;
using System;

public partial class GameManager : Node
{
    public static int Puntos = 0;

    public static int Vidas = 3;

    public static int Nivel = 1;

    public static int VelocidadEnemigo = 150;

    public static AudioStreamPlayer2D SonidoDisparoNave;
    public static AudioStreamPlayer2D SonidoDisparoEnemigo;
    public static AudioStreamPlayer2D SonidoExplosion;


    public override void _Ready()
    {
        SonidoDisparoEnemigo = GetNode<AudioStreamPlayer2D>("SonidoDisparoEnemigo");
        SonidoDisparoNave = GetNode<AudioStreamPlayer2D>("SonidoDisparoNave");        
        SonidoExplosion = GetNode<AudioStreamPlayer2D>("SonidoExplosion");

    }

}
