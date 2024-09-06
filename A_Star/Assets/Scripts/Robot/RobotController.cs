using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float movementSpeed; // Velocidad de movimiento del robot
    [SerializeField] public GameObject boxVisual;
    
    private List<Coordinates> pathNodes; // Lista de nodos que forman la ruta del robot
    private int currentNodeIndex = 0; // Índice del nodo actual en la ruta
    private bool isWaiting = false; // Estado de espera para el robot
    private int boxInventoryAmount;
    private int currentboxInventory;
    public bool hasBox { get {return currentboxInventory > 0;}} 

    private void Start()
    {
        boxVisual.SetActive(false);
    }

    // Método para inicializar el robot con una ruta
    public void Initialize(List<Coordinates> nodes)
    {
        pathNodes = nodes;
    }

    // Método para mover el robot
    public void Move()
    {
        // Si el robot está esperando, no hace nada
        if (isWaiting) return;
        // Si hemos llegado al final de la ruta, no hacemos nada
        if (currentNodeIndex >= pathNodes.Count) return;

        // Obtenemos las coordenadas del siguiente nodo en la ruta
        Coordinates targetCoordinates = pathNodes[currentNodeIndex];
        // Convertimos las coordenadas a una posición en el mundo usando GridManager
        Vector3 targetWorldPos = GridManager.Instance.GetWorldPosition(targetCoordinates);

        // Verificamos si el nodo tiene el valor 'wait' en true, si es así, esperamos 2 segundos
        if (targetCoordinates.wait)
        {
            StartCoroutine(WaitBeforeNextMove(1.25f));
            return;
        }

        // Movemos el robot hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, movementSpeed * Time.deltaTime);
        Vector3 lookDirection = targetWorldPos - transform.position;
        transform.LookAt(targetWorldPos);
        // Si estamos muy cerca del objetivo (menos de 0.01 unidades), pasamos al siguiente nodo
        if (Vector3.Distance(transform.position, targetWorldPos) < 0.01f)
        {
            currentNodeIndex++;
        }
    }

    // Corrutina para esperar antes de continuar el movimiento
    private IEnumerator WaitBeforeNextMove(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false; // La espera termina y el robot puede moverse de nuevo
        currentNodeIndex++; // Avanzamos al siguiente nodo después de la espera
    }


    public void GrabPayload()
    {
        boxVisual.SetActive(true);
        currentboxInventory++;
        boxInventoryAmount++;
        Debug.Log("Robot recogió una caja");
    }

    public void DropPayload()
    {
        boxVisual.SetActive(false);
        currentboxInventory = 0; 
    }

    // Método para manejar colisiones
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el robot ha colisionado con un objeto con las etiquetas "right" o "left"
        if (other.CompareTag("right") || other.CompareTag("left"))
        {
            // Verificar si el nodo actual es un objetivo (goal)
            if (currentNodeIndex < pathNodes.Count)
            {
                Coordinates currentCoordinates = pathNodes[currentNodeIndex];

                if (currentCoordinates.goal)
                {
                    if (other.CompareTag("right"))
                    {
                        RotateRight(); // Gira a la derecha
                    }
                    else if (other.CompareTag("left"))
                    {
                        RotateLeft(); // Gira a la izquierda
                    }
                }
            }
        }
    }

    // Método para girar el robot a la derecha
    private void RotateRight()
    {
        // Rotar 90 grados a la derecha
        transform.Rotate(0, 90, 0);
        Debug.Log("Robot ha girado a la derecha");
    }

    // Método para girar el robot a la izquierda
    private void RotateLeft()
    {
        // Rotar 90 grados a la izquierda
        transform.Rotate(0, -90, 0);
        Debug.Log("Robot ha girado a la izquierda");
    }
}
