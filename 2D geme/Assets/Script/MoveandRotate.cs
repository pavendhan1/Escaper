using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveandRotate : MonoBehaviour
{
    public float rotateSpeed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed* Time.deltaTime);


        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < 142f)
        {
            Destroy(gameObject);
        }
    }
}
