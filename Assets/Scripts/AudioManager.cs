using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonidos : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public Slider slider;


    void Start()
    {
        // Verificar si el AudioSource está asignado, si no, obtenerlo
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Verificar nuevamente y lanzar una advertencia si no está presente
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the GameObject. Please add an AudioSource component.");
            return;
        }

        // Asignar el clip de audio y reproducirlo
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Update()
    {
        // Verificar si el AudioSource está asignado antes de usarlo
        if (audioSource != null)
        {
            audioSource.volume = slider.value;
        }
    }
}