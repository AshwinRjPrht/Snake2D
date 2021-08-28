using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D rw)
    {
     if(rw.tag == "Player")
        {
            rw.gameObject.transform.position = new Vector3(-19, rw.gameObject.transform.position.y, 0.0f);
        }   
    }
}

