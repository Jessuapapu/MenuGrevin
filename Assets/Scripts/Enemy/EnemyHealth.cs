using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int scoreValue;
    public bool isDead;

    Animator anim;

    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Animating();
    }


    public void TakeDamage(int amount)
    {
        // Comprobar si el enemigo esta muerto
        if (isDead) return;

        // Ir quitando vida al enemigo
        currentHealth -= amount;

        // Si la vida llega a 0, se activa el metodo Death
        if (currentHealth <= 0) Death();
    }

    void Death()
    {
        isDead = true;
        anim.SetBool("Dead", true);
        // Destruimos al enemigo
        Destroy(gameObject, 1);
    }

    void Animating()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("Dead", true);
        }
    }
}
