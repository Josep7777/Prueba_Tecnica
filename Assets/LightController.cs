using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] private int spawnProbability = 50;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            if (Random.Range(0f, 101f) <= spawnProbability) lights[i].SetActive(false);

        }
    }
}
