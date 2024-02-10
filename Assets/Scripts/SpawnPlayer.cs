using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public void InstantiatePlayer(Vector3 position)
    {
        Instantiate(player, position, Quaternion.identity);
    }
}
