using UnityEditor;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("player");
            collision.gameObject.GetComponent<PayerMovement>().lastPoint = transform.position;
            
           
        }
    }
}
