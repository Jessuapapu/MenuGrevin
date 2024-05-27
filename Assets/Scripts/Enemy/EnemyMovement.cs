using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player; // Variable para representar al jugador
    NavMeshAgent agent; // Variable para representar al enemigo
    Animator anim;

    void Start()
    {
        // Buscar dentro de la escena un objeto con el tag de "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // Comprobar que el jugador no sea nulo
        if (player != null)
        {
            // Mover al enemigo hacia la posicion del jugador
            agent.SetDestination(player.transform.position);

        }

        Animating();

    }

    void Animating()
    {
        // Para saber si el enemigo se esta moviendo es con el magnitude
        if (agent.velocity.magnitude != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
