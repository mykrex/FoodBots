using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float movementSpeed; // Velocidad de movimiento del robot
    [SerializeField] private GameObject boxVisual;
    
    private List<Coordinates> pathNodes; // Lista de nodos que forman la ruta del robot
    private int currentNodeIndex = 0; // Índice del nodo actual en la ruta
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
        // Si hemos llegado al final de la ruta, no hacemos nada
        if (currentNodeIndex >= pathNodes.Count) return;

        // Obtenemos las coordenadas del siguiente nodo en la ruta
        Coordinates targetCoordinates = pathNodes[currentNodeIndex];
        // Convertimos las coordenadas a una posición en el mundo usando GridManager
        Vector3 targetWorldPos = GridManager.Instance.GetWorldPosition(targetCoordinates);

        // Movemos el robot hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, movementSpeed * Time.deltaTime);

        // Si estamos muy cerca del objetivo (menos de 0.01 unidades), pasamos al siguiente nodo
        if (Vector3.Distance(transform.position, targetWorldPos) < 0.01f)
        {
            currentNodeIndex++;
        }
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
}