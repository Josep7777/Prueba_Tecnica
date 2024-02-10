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
        //UpdateRoom(1);
    }

    public void UpdateRoom(int door)
    {
        /*
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(!status[i]);
        }
        */
        switch (door)
        {
            case 0:
                doors[0].SetActive(false); //Close the up door
                break;
            case 1:
                doors[1].SetActive(false);//Close the left door
                break;
            case 2:
                doors[2].SetActive(false);//Close the right door
                break;
            case 3:
                doors[3].SetActive(false);//Close the down door
                break;
        }
        
    }
}
