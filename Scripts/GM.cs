using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    private bool combateActivo = true;

    void Start()
    {
        player = new Player();
        enemy = new Enemy();

        Debug.Log("Combate iniciado. Presiona la tecla A para atacar.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && combateActivo)
        {
            Turnos();
        }
    }

    void Turnos()
    {
        try
        {
            player.Attack(enemy);

            if (enemy.Vida == 0)
            {
                combateActivo = false;
                Debug.Log("El enemigo ha sido derrotado.");
                return;
            }

            enemy.Attack(player);

            if (player.Vida == 0)
            {
                combateActivo = false;
                Debug.Log("El jugador ha muerto.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning("Error: " + ex.Message);
        }
    }
}
