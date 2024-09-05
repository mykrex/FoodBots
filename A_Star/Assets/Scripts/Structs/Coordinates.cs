using System;

[Serializable] // Permite que esta estructura sea serializable (útil para JSON y el inspector de Unity)
public struct Coordinates
{
    public int x; // Coordenada X
    public int y; // Coordenada Y
    public bool wait; // Indica si el robot debe esperar en este punto
    public bool goal; // Indica si este punto es un objetivo (por ejemplo, para recoger o dejar una caja)

    // Constructor que permite crear una instancia de Coordinates con valores específicos
    public Coordinates(int x, int y, bool wait = false, bool goal = false)
    {
        this.x = x;
        this.y = y;
        this.wait = wait;
        this.goal = goal;
    }
}