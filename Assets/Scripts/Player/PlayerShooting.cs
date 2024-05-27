using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot; // daño por disparo que va a hacer el player
    public float timeBetweenBullets; // Tiempo entre disparos
    public float range; // Longitud del raycast, hasta que distancia puede disparar el player
    public LayerMask shoottableMask; // Capa de objetos a la que vamos a poder disparar

    float timer; // variable que vamos a usar de contador de tiempo
    Ray ray;
    RaycastHit hit;
    LineRenderer lineRenderer; // la linea de disparo del arma 
    Light gunLight; // para poder ver el disparo
    float effectsDisplayTime = 0.2f; // Variable que va a determinar cuando tiempo van a estar los efectos en pantalla


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime; // Contador de timepo

        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        // Deshabilitar los efectos, el effectsDisplayTime es para que cuando disparemos, el efecto del disparo
        // (destello y linea de disparo) dure la mitad de tiempo antes de volver poder a disparar
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            lineRenderer.enabled = false;
            gunLight.enabled = false;
        }


    }

    void Shoot()
    {
        // Reiniciar el contador para esperar el tiempo adecuado para disparar
        timer = 0;

        // Habilitar el componente LineRenderer que es el que controla el disparo
        lineRenderer.enabled = true;
        gunLight.enabled = true;
        // Establecer el primer punto del LineRenderer
        lineRenderer.SetPosition(0, transform.position);

        // Hacia donde va a apuntar el rayo
        ray.origin = transform.position;
        ray.direction = transform.forward;

        // Disparar el rayo
        if (Physics.Raycast(ray, out hit, range, shoottableMask))
        {
            //Guardar en una variable el gameObject con el que esta chocando
            GameObject _object = hit.collider.gameObject;

            //Comprobar si se esta chocando con el enemigo mediante el GetComponent, revisa si tiene el 
            //Componente EnemyHealth lo que va a indicar que es un enemigo
            if (_object.GetComponent<EnemyHealth>())
            {
                //Si es el enemigo entonces llamamos a la funcion TakeDamage y le pasamos el parametro del daño del player
                _object.GetComponent<EnemyHealth>().TakeDamage(damagePerShot);
            }

            //Llega hasta impactar con algun objeto que tiene un collider
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Hasta donde va a impactar el rayo
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * range));
        }

    }
}
