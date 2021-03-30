using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Transform player;
    public Image winner;

    void Start()
    {
        winner.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log(distance);
        if (distance < 4)
        {
            winner.enabled = true;
        }
    }
}
