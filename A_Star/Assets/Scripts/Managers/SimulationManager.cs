using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private float spawnOffset; // Desplazamiento para el spawn de robots (no usado en este código)
    [SerializeField] GameObject robotPrefab; // Prefab del robot a instanciar
    [SerializeField] TextAsset jsonFile; // Archivo JSON con datos de los robots

    private List<Robot> robots = new List<Robot>(); // Lista para almacenar los robots creados

    void Start()
    {
        LoadRobotsFromJson(); // Carga los robots desde el archivo JSON al iniciar
    }

    void Update()
    {
        // Actualiza el movimiento de todos los robots en cada frame
        foreach (Robot robot in robots)
        {
            robot.Move();
        }
    }

    void LoadRobotsFromJson()
    {
        try
        {
            // Intenta deserializar el JSON a una lista de datos de robots
            RobotDataList robotDataList = JsonUtility.FromJson<RobotDataList>(jsonFile.text);

            // Crea un robot por cada entrada en el JSON
            foreach (RobotData robotData in robotDataList.robots)
            {
                SpawnRobot(robotData);
            }
        }
        catch (System.Exception e)
        {
            // Manejo de errores en caso de que el JSON no pueda ser parseado
            Debug.LogError($"Error parsing JSON: {e.Message}");
        }
    }

    void SpawnRobot(RobotData robotData)
    {
        // Obtiene la posición de spawn del robot usando el GridManager
        Vector3 spawnPos = GridManager.Instance.GetWorldPosition(robotData.spawnPosition);
        
        // Instancia el robot en la posición calculada
        GameObject robotObject = Instantiate(robotPrefab, spawnPos, Quaternion.identity);
        
        // Obtiene el componente Robot del objeto instanciado
        Robot robot = robotObject.GetComponent<Robot>();
        
        // Inicializa el robot con su ruta
        robot.Initialize(robotData.path);
        
        // Agrega el robot a la lista de robots
        robots.Add(robot);
    }
}