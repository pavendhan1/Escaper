using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2.0f;
    public Vector3 v;
    private bool movingToEnd = true;

    void Update()
    {
       
      Vector3 targetPosition = movingToEnd ? endPoint.position : startPoint.position;

    
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        
        if (transform.position == targetPosition)
        {
            
            movingToEnd = !movingToEnd;
        }


        Debug.Log(transform.position);
    }
}
