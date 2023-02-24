using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform Player;

    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        CameraFocusOnPlayer();
    }

    void CameraFocusOnPlayer()//focus camera on player
    {
        Vector3 temp = transform.position;
        temp.x = Player.position.x;
        temp.z = Player.position.z - 25;// magic number to center display 

        transform.position = temp;
    }
}
