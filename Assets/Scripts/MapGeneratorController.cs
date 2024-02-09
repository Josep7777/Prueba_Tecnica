using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorController : MonoBehaviour
{
    [Header("Spawn probability")]
    [SerializeField] private int spawnProbability;
    [SerializeField] private int guaranteedSpawns;

    [Header("Maze configuration")]
    [SerializeField] private int maxRoomX;
    [SerializeField] private int maxRoomY;

    [Header("Room prefab")]
    [SerializeField] private GameObject room;

    [SerializeField] private SpawnPlayer spanwPlayer;

    

    private Vector3[,] roomPos;
    private bool startRandomization = false;
    private List<GameObject> rooms;

    public class Room
    {
        public bool[] doors = new bool[4];
        public bool visited = false;
    }

    public Vector2 size;
    public int startPos = 0;

    List<Room> board;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap(maxRoomX, maxRoomY);
        StarterRoom(maxRoomX, maxRoomY);
    }

    public void GenerateMap(int rows, int columns)
    {
        bool[,] visited = new bool[rows, columns];
        roomPos = new Vector3[rows, columns];
        List<GameObject> rooms = new List<GameObject>();

        // Asegura que haya al menos una sala en la primera fila
        int initialColumn = Random.Range(0, 0);
        visited[0, initialColumn] = true;
        Instantiate(room, new Vector3(initialColumn * 6, 0, 0), Quaternion.identity);

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
                        roomPos[i, x] = new Vector3(x * 6, 0, i * 6);
                        visited[i, x] = true;
                        var newRoom = Instantiate(room, roomPos[i, x], Quaternion.identity);
                        rooms.Add(newRoom);
                    }
                }
            }
        }
    }

    void OpenDoors() {
        for (int i = 0; i < rooms.Count; i++)
        {
            //RoomController roomController = rooms[i].GetComponent<RoomController>();
            // Aquí puedes utilizar roomController para acceder a la lógica de apertura de puertas de la sala
            // Ejemplo: roomController.OpenDoors();
        }
    }
    void StarterRoom(int rows, int columns)
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
        spanwPlayer.InstantiatePlayer(new Vector3(randomRoomPosition.x, randomRoomPosition.y + 2, randomRoomPosition.z));

    }

    void MazeGenerator()
    {
        board = new List<Room>();
        for (int i = 0; i < size.x; i++)
        {
            for (int x = 0; x < size.y; x++)
            {
                board.Add(new Room());
            }
        }
        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 25)
        {
            k++;

            board[currentCell].visited = true;

        }
    }

}
