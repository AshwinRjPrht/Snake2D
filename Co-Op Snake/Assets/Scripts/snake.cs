using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    public void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.5f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }


    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if( gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            gridPosition += gridMoveDirection;
           
        }
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(gridMoveDirection) -90 );
    }
    private float getAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }
}
