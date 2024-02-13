using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WInningPoint : MonoBehaviour
{
    [SerializeField] GameObject WinImage;
    // Start is called before the first frame update
    void Start()
    {
        WinImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")))
        {
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        WinImage.SetActive(true);
    }
}
