using System;
using System.Collections.Generic;

[Serializable] // Permite que esta estructura sea serializable (útil para JSON y el inspector de Unity)
public struct RobotData
{
    public Coordinates spawnPosition; // Posición inicial del robot en la cuadrícula
    public List<Coordinates> path; // Lista de coordenadas que forman la ruta del robot
}