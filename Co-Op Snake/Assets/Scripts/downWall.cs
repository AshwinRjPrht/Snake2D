using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D rw)
    {
        if (rw.tag == "Player")
        {
            rw.gameObject.transform.position = new Vector3(rw.gameObject.transform.position.x, 9, 0.0f);
        }
    }
}
