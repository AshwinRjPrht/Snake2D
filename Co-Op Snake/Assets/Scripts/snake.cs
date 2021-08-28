using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public Score sc;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
        {       
                direction = Vector2.up;
            
        } else if(Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
        {
                direction = Vector2.down;   
        }
        else if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {
                direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
                direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for(int i =segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round( this.transform.position.y) + direction.y, 0.0f);
    }
    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        this.transform.position = Vector3.zero;
        sc.ResetScore(0); 
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            sc.IncreaseScore(10);
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
