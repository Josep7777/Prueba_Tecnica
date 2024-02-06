using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;

    [SerializeField] private bool[] testStatus;
    // Start is called before the first frame update
    void Start()
    {
        UpdateRoom(testStatus);
    }

    void UpdateRoom(bool[] status) { 
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(!status[i]);
        }
    }
}
