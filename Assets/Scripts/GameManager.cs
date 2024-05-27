using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Header es un metodo para hacer que desde Unity se cree un encabezado, es para tener un mejor orden
    [Header("Array Positions")]
    public Transform[] positions; // Array para las posiciones de los enemigos
    [Header("Array enemies")]
    public GameObject[] enemyPrefab; // Enemigos que van a aparecer

    // El space va a crear un espacio para que no se vea tan pegado dentro de Unity
    [Space]
    public Transform parentEnemies; // GameObject vacio que va a ser el padre de los clones que van a aparecer

    // Es para especificar dentro de Unity que una variable va a poder estar entre esas variables
    [Range(2, 6)]
    [Tooltip("Tiempo de aparicion de los enemigos")] // Es para un pequeño aviso para que sirve 
    public float time; // Cada cuanto tiempo vamos a instanciar a los enemigos

    void Start()
    {
        // Metodo para llamar a un metodo repetidamente
        InvokeRepeating("CreateEnemy", time, time);
    }

    void Update()
    {

    }

    void CreateEnemy()
    {

        int pos = Random.Range(0, positions.Length); // Generar un numero aleatorio para que aparezcan los enemigos
        int enemy = Random.Range(0, enemyPrefab.Length); // Que enemigo se va a generar en las posiciones

        // Guardar en una variavle la instanciancion de los enemigos en sus respectivas posiciones y cual enemigo
        GameObject cloneEnemy = Instantiate(enemyPrefab[enemy], positions[pos].position, positions[pos].rotation);
        cloneEnemy.transform.SetParent(parentEnemies); // Hacer que los enemigos sean hijos de parentEnemies para tener un mayor orden
    }
}
