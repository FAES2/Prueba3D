using UnityEngine;

public class ParticulaNieve : MonoBehaviour
{
    private Transform jugador;
    private float tiempoVida = 1.5f;   // dura más que la original
    private float velocidad = 2.0f;    // velocidad de movimiento hacia el jugador

    void Start()
    {
        jugador = GameObject.FindWithTag("Player")?.transform;
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        if (jugador != null)
        {
            // Rotar hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direccion);

            // Moverse lentamente hacia el jugador
            transform.position = Vector3.MoveTowards(
                transform.position,
                jugador.position,
                velocidad * Time.deltaTime
            );
        }
    }
}
