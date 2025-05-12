using UnityEngine;
using static UnityEditor.Progress;

public class Enemy : Personaje
{
    public Enemy()
    {
        vida = 80;
        ataque = 15;
        defensa = 3;
        durabilidad = 25;
    }
}

