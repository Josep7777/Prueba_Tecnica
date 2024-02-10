using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [Header("Minimap texture")]
    [SerializeField] SpriteRenderer minimapTexture;

    [Header("Minimap colors")]
    [SerializeField] Color visitedColor;
    [SerializeField] Color notVisitedColor;
    [SerializeField] Color actualPositionColor;

    void Start()
    {
        minimapTexture.color = notVisitedColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        minimapTexture.color = actualPositionColor;
    }

    private void OnTriggerStay(Collider other)
    {
        minimapTexture.color = actualPositionColor;
    }

    private void OnTriggerExit(Collider other)
    {
        minimapTexture.color = visitedColor;
    }
}
