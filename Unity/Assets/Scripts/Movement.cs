using UnityEngine;

public class Movement : MonoBehaviour
{
    public float radio = 5f; // Radio del círculo
    public float velocidadAngular = 0.1f; // Velocidad de rotación (radianes por segundo)
    public float duracionSimulacion = 15f; // Duración de la simulación en segundos

    private Vector3 centro; // Centro del círculo
    private float angulo; // Ángulo actual en radianes
    private float tiempoTranscurrido; // Tiempo transcurrido desde el inicio

    private Vector3 escalaInicial; // Escala inicial de la esfera
    private bool simulacionTerminada = false; // Indica si la simulación ha terminado

    void Start()
    {
        // Guardar la posición inicial como el centro del círculo
        centro = transform.position;
        escalaInicial = transform.localScale; // Guardar la escala inicial
    }

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si la simulación ha terminado
        if (tiempoTranscurrido >= duracionSimulacion)
        {
            if (!simulacionTerminada)
            {
                // Mover la esfera a las coordenadas (0, 0.5, 0)
                transform.position = new Vector3(0, 0.5f, 0);
                simulacionTerminada = true; // Marcar la simulación como terminada
            }

            // Escalado oscilante
            float factorEscala = 1f + 0.3f * Mathf.Sin(Time.time * 2f); // Oscila entre 0.7 y 1.3
            transform.localScale = escalaInicial * factorEscala;

            return; // Salir del método Update
        }

        // Rotación hacia adelante (eje X)
        transform.Rotate(Vector3.right * 2f);

        // Rotación hacia la izquierda (eje Y)
        transform.Rotate(Vector3.up * -0.4f, Space.World);

        // Incrementar el ángulo basado en la velocidad angular y el tiempo
        angulo += velocidadAngular * Time.deltaTime;

        // Calcular la nueva posición usando funciones trigonométricas
        float x = centro.x + Mathf.Cos(angulo) * radio;
        float z = centro.z + Mathf.Sin(angulo) * radio;

        // Actualizar la posición de la esfera
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
