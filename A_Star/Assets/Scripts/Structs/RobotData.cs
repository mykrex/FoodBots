using System;
using System.Collections.Generic;

[Serializable] // Permite que esta estructura sea serializable (útil para JSON y el inspector de Unity)
public struct RobotData
{
    public Coordinates spawnPosition; // Posición inicial del robot en la cuadrícula
    public List<Coordinates> path; // Lista de coordenadas que forman la ruta del robot
    public bool wait; //checa si tiene que esperar o no
    public Coordinates goal;//position donde toma/deja la caja 
}