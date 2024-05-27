using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;

    // Capa donde va a estar el suelo de la escena
    public LayerMask LayerFloor;

    Rigidbody rb;

    //Creamos una variable Animator para poder controlar las condiciones de las animaciones desde codigo
    //Animator anim;

    Vector3 movement; //Guardaremos la direccion de movimiento
    float horizontal;
    float vertical;

    void Start()
    {
        // Inicializamos las variables para acceder a los componentes 
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Los inputs van en el update para que siempre capte las teclas en cualquier frame, en el fixedUpdate va 
        // a un frame en especifico por lo que no captaria siempre los inputs si lo ponemos ahí
        InputPlayer();
    }

    void FixedUpdate()
    {
        Move();
        //Animating();
    }

    void InputPlayer()
    {
        // Teclas para mover al personaje
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        movement = new Vector3(horizontal, 0, vertical); // Direccion de movimiento a traves de los input
        movement.Normalize(); // Normalizar el vector es normalizar su modulo para que valga uno y no vaya mas rapido que el movimiento
        // El movimiento mediante el rigidbody se traduce de la siguiente manera, mi posicion actual + hacia donde me estoy
        // moviendo, siempre multiplicando eso por la velocidad y por los frames por segundo
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    /*void Animating()
    {
        // verificamos si estamos presionando los inputs, estos son los verificadores de que si el personaje se esta
        // moviendo o no
        if (horizontal != 0 || vertical != 0)
        {
            // Tiene que ser el SetBool porque ese fue la condicion que le pusimos en el Animator al IsMoving
            // Si se detecta movimiento entonces activar la animacion
            anim.SetBool("IsMoving", true);
        }
        else
        {
            // Si no se detecta movimiento, se vuelve falso
            anim.SetBool("IsMoving", false);
        }
    }*/
}
