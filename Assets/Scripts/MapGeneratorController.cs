using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGeneratorController : MonoBehaviour
{
    [Header("Spawn probability")]
    [SerializeField] private int spawnProbability = 70;

    [Header("Maze configuration")]
    [SerializeField] private int maxRoomX = 5;
    [SerializeField] private int maxRoomY = 5;
    [SerializeField] private int offset = 6;

    [Header("Room prefab")]
    [SerializeField] private GameObject room;

    [Header("Spawn Player Script")]
    [SerializeField] private GameObject spawnPlayer;


    //Maze generation
    private Vector3[,] roomPos;
    private bool[,] visited;

    //Room generation
    private RoomController[,] roomController;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze(maxRoomX, maxRoomY);
        GenerateRooms(maxRoomX, maxRoomY);
        RandomSpawnPlayer(maxRoomX, maxRoomY);
    }

    public void GenerateMaze(int rows, int columns)
    {
        visited = new bool[rows, columns];
        roomPos = new Vector3[rows, columns];

        // Asegura que haya al menos una sala en la primera fila
        int initialColumn = Random.Range(0, 0);
        roomPos[0, initialColumn] = new Vector3(0, 0, 0);
        visited[0, initialColumn] = true;


        for (int i = 0; i < rows; i++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (Random.Range(0f, 101f) <= spawnProbability) // Probabilidad del 60% de tener una sala
                {
                    // Verifica si hay alguna sala adyacente
                    bool hasAdjacentRoom = (i > 0 && visited[i - 1, x]) || (i < rows - 1 && visited[i + 1, x]) || (x > 0 && visited[i, x - 1]) || (x < columns - 1 && visited[i, x + 1]);
                    if (hasAdjacentRoom)
                    {
                        roomPos[i, x] = new Vector3(x * offset, 0, i * offset);
                        visited[i, x] = true;
                    }

                }
            }
        }
    }

    void GenerateRooms(int rows, int columns)
    {
        roomController = new RoomController[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (visited[i, x])
                {
                    GameObject newRoom = Instantiate(room, roomPos[i, x], Quaternion.identity);

                    if (i > 0 && visited[i - 1, x])
                    {
                        roomController[i, x] = newRoom.GetComponent<RoomController>();
                        roomController[i, x].UpdateRoom(2);
                    }
                    if (i < rows - 1 && visited[i + 1, x])
                    {
                        roomController[i, x] = newRoom.GetComponent<RoomController>();
                        roomController[i, x].UpdateRoom(1);
                    }
                    if (x > 0 && visited[i, x - 1])
                    {
                        roomController[i, x] = newRoom.GetComponent<RoomController>();
                        roomController[i, x].UpdateRoom(3);
                    }
                    if (x < columns - 1 && visited[i, x + 1])
                    {
                        roomController[i, x] = newRoom.GetComponent<RoomController>();
                        roomController[i, x].UpdateRoom(0);
                    }
                }                
            }
        }
    }

    void RandomSpawnPlayer(int rows, int columns)
    {
        List<Vector3> availableRoomPositions = new List<Vector3>();

        for (int i = 0; i < rows; i++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (roomPos[i, x] != Vector3.zero) // Verifica si la sala existe en esa posición
                {
                    availableRoomPositions.Add(roomPos[i, x]);
                }
            }
        }

        int randomIndex = Random.Range(0, availableRoomPositions.Count);
        Vector3 randomRoomPosition = availableRoomPositions[randomIndex];
        //spawnPlayer.transform.position = new Vector3(randomRoomPosition.x, randomRoomPosition.y + 2, randomRoomPosition.z);
        Instantiate(spawnPlayer, new Vector3(randomRoomPosition.x, randomRoomPosition.y + 2, randomRoomPosition.z), Quaternion.identity);
    }
}
