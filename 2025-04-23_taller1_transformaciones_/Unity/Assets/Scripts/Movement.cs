using UnityEngine;

public class Movement : MonoBehaviour
{
    public float radio = 5f; // Radio del c�rculo
    public float velocidadAngular = 0.1f; // Velocidad de rotaci�n (radianes por segundo)
    public float duracionSimulacion = 15f; // Duraci�n de la simulaci�n en segundos

    private Vector3 centro; // Centro del c�rculo
    private float angulo; // �ngulo actual en radianes
    private float tiempoTranscurrido; // Tiempo transcurrido desde el inicio

    private Vector3 escalaInicial; // Escala inicial de la esfera
    private bool simulacionTerminada = false; // Indica si la simulaci�n ha terminado

    void Start()
    {
        // Guardar la posici�n inicial como el centro del c�rculo
        centro = transform.position;
        escalaInicial = transform.localScale; // Guardar la escala inicial
    }

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si la simulaci�n ha terminado
        if (tiempoTranscurrido >= duracionSimulacion)
        {
            if (!simulacionTerminada)
            {
                // Mover la esfera a las coordenadas (0, 0.5, 0)
                transform.position = new Vector3(0, 0.5f, 0);
                simulacionTerminada = true; // Marcar la simulaci�n como terminada
            }

            // Escalado oscilante
            float factorEscala = 1f + 0.3f * Mathf.Sin(Time.time * 2f); // Oscila entre 0.7 y 1.3
            transform.localScale = escalaInicial * factorEscala;

            return; // Salir del m�todo Update
        }

        // Rotaci�n hacia adelante (eje X)
        transform.Rotate(Vector3.right * 2f);

        // Rotaci�n hacia la izquierda (eje Y)
        transform.Rotate(Vector3.up * -0.4f, Space.World);

        // Incrementar el �ngulo basado en la velocidad angular y el tiempo
        angulo += velocidadAngular * Time.deltaTime;

        // Calcular la nueva posici�n usando funciones trigonom�tricas
        float x = centro.x + Mathf.Cos(angulo) * radio;
        float z = centro.z + Mathf.Sin(angulo) * radio;

        // Actualizar la posici�n de la esfera
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
