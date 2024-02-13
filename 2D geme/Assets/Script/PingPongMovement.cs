using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
  public  bool isTop;
    public float SPEED = 2;
    public float amplitude;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 3);

        float vetrical=Mathf.PingPong(Time.time*6,10-1)+1;
        Debug.Log(vetrical);
        transform.position=new Vector2 (transform.position.x,vetrical);


        if(transform.position.x < 45)
        {
            Destroy(gameObject);
        }

    }
}
