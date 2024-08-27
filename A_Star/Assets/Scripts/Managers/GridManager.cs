using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Singleton para acceder fácilmente a esta instancia desde otras partes del código
    public static GridManager Instance { get; private set; }
    
    [SerializeField] private Coordinates gridSize; // Tamaño de la cuadrícula
    [field: SerializeField] public int TileSize { get; private set; } // Tamaño de cada casilla
    [SerializeField] private GameObject tilePrefab; // Prefab de la casilla a instanciar

    private void Awake()
    {
        // Implementación del patrón Singleton
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destruye duplicados
        }
    }
    
    private void Start()
    {
        ClearGrid(); // Limpia la cuadrícula existente
        SpawnGrid(); // Genera una nueva cuadrícula
    }

    [ContextMenu("Spawn Grid")] // Permite ejecutar este método desde el menú contextual en el editor
    private void SpawnGrid()
    {
        // Recorre las coordenadas X e Y para crear la cuadrícula
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                // Calcula la posición de la casilla en el mundo
                Vector3 tilePosition = new Vector3(x * TileSize, 0, y * TileSize);
                // Instancia la casilla
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tile.transform.parent = transform; // Establece el padre de la casilla
                tile.name = $"Tile ({x}, {y})"; // Nombra la casilla con sus coordenadas
                tile.GetComponent<Etiquetas>().SetCoordinates(x, y); // Establece las coordenadas en el componente Etiquetas
            }
        }
    }
    
    private void ClearGrid()
    {
        // Destruye todas las casillas hijas existentes
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    // Método para obtener la posición en el mundo a partir de coordenadas de la cuadrícula
    public Vector3 GetWorldPosition(Coordinates coordinates)
    {
        return new Vector3(coordinates.x * TileSize, 0, coordinates.y * TileSize);
    }
}