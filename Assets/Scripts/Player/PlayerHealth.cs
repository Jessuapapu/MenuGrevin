using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Slider slider;

    public Image damageImage;
    public float flashSpeed; // Velocidad en la que va a desaparecer la imagen que va a representar el daño hacia el player
    public Color flashColour; // Va a representar el efecto de daño en la pantalla (color rojo)
    bool isDead;
    bool damaged;

    // Se hacen referencia a estos componentes del jugador porque una vez muerto, no tendria sentido que el jugador 
    // Pueda seguir moviendose, disparando o haciendo animaciones
    Animator anim;
    PlayerShooting playerShooting;
    PlayerMovement playerMovement;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return; // Si el player esta muerto se sale del metodo
        damaged = true;
        currentHealth -= amount;
        slider.value = currentHealth;

        if (currentHealth <= 0) Death();
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Death");

        // Desactivando los scripts del jugador
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
