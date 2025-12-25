using UnityEngine;
using System;

public class WeatherControllerParticle : MonoBehaviour
{
    [Header("Prefab del sistema de partículas de nieve")]
    public ParticleSystem sistemaNieve;

    [Header("Jugador")]
    public Transform jugador;

    [Header("Altura de generación")]
    public float alturaGeneracion = 45f;

    private bool activarNieve = false;

    void Awake()
    {
        DateTime ahora = DateTime.Now;
        int mes = ahora.Month;
        int dia = ahora.Day;

        // Activar nieve si está entre 29 Nov y 1 Feb
        if ((mes == 11 && dia >= 29) || mes == 12 || mes == 1 || (mes == 2 && dia <= 1))
        {
            activarNieve = true;
            if (sistemaNieve != null)
            {
                sistemaNieve.Play();
            }
        }
    }

    void Update()
    {
        if (activarNieve && jugador != null && sistemaNieve != null)
        {
            // Posicionar el sistema de partículas sobre el jugador a la altura indicada
            Vector3 posicion = jugador.position;
            posicion.y = alturaGeneracion;
            sistemaNieve.transform.position = posicion;
        }
    }
}
