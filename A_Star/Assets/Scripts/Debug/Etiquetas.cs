using TMPro;
using UnityEngine;

public class Etiquetas : MonoBehaviour
{
    [SerializeField] private TextMeshPro label; // Referencia al componente TextMeshPro para mostrar el texto
    public Coordinates coordenadas; // Almacena las coordenadas de esta etiqueta
    
    // Método para establecer las coordenadas de la etiqueta
    public void SetCoordinates(int x, int y)
    {
        coordenadas = new Coordinates(x, y); // Crea una nueva instancia de Coordinates
        UpdateCordsLabel(); // Actualiza el texto mostrado
    }

    // Método privado para actualizar el texto de la etiqueta
    private void UpdateCordsLabel()
    {
        label.text = $"{coordenadas.x}, {coordenadas.y}"; // Establece el texto con las coordenadas
    }
}