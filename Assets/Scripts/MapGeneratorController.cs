using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorController : MonoBehaviour
{
    [SerializeField] private GameObject room;

    [SerializeField] private int maxRoomX, maxRoomY;

    private bool[] visited;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap(maxRoomX, maxRoomY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap(int rows, int columns)
    {
        bool[,] visited = new bool[rows, columns];

        // Asegura que haya al menos una sala en la primera fila
        int initialColumn = Random.Range(0, columns);
        visited[0, initialColumn] = true;
        Instantiate(room, new Vector3(initialColumn * 6, 0, 0), Quaternion.identity);

        for (int i = 1; i < rows; i++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (Random.Range(0f, 1f) > 0.4f) // Probabilidad del 60% de tener una sala
                {
                    visited[i, x] = true;

                    // Verifica si hay alguna sala adyacente
                    if ((i > 0 && visited[i - 1, x]) || (i < rows - 1 && visited[i + 1, x]) || (x > 0 && visited[i, x - 1]) || (x < columns - 1 && visited[i, x + 1]))
                    {
                        Vector3 posicion = new Vector3(x * 6, 0, i * 6);
                        Instantiate(room, posicion, Quaternion.identity);
                    }
                }
            }
        }
    }

}
