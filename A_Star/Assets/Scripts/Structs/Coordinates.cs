using System;

[Serializable] // Permite que esta estructura sea serializable (útil para JSON y el inspector de Unity)
public struct Coordinates
{
    public int x; // Coordenada X
    public int y; // Coordenada Y
    
    // Constructor que permite crear una instancia de Coordinates con valores específicos
    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}