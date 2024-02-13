using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumb=5f;
  [SerializeField]  private Rigidbody2D body;
  [SerializeField]  private Animator anim;
  [SerializeField]  private bool grounded;
    int number = 0;
    public AudioSource source;
    public AudioClip jumbClip;
    public AudioClip CoinClip;
    public AudioClip explotionClip;
    [SerializeField] AudioClip heltheClip;

    public Score score;
    public GameObject explotion;

    public float health;
    public float maxHealth=100;
    public Image healthBar;

    public GameObject GameOver;
    public Vector2 lastPoint;
    bool isStop;
    private void Awake()
    {
      
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        health = maxHealth;
        GameOver.SetActive(false);
    }
    private void Update()
    {if (isStop) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

 
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            anim.SetBool("Walk", true);
        }
          
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
           

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {

                body.velocity = new Vector2(0f, jumb);
                anim.SetTrigger("jump");
                number=1;
                source.PlayOneShot(jumbClip,1);
                grounded = false;
            }
            else
            {
              if(number==1)
                {
                    body.velocity = new Vector2(0f, jumb);
                    anim.SetTrigger("jump");
                    anim.SetBool("Jumb", true);
                    number = 0;
                }
                else
                {
                    anim.SetBool("Jumb", false);
                }
            }


        }
      
       
        anim.SetBool("Jumb", grounded);
        healthBar.fillAmount = health / maxHealth;

        if (health == 0)
        {
            GameOver.SetActive(true);
        }

      
        
    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            score.coinScore++;
            source.PlayOneShot(CoinClip, 1);


        }
        if (collision.gameObject.CompareTag("Boom"))
        {


            GameObject g = Instantiate(explotion, collision.transform.position, explotion.transform.rotation);
            Destroy(collision.gameObject);
            source.PlayOneShot(explotionClip, 1);
            Destroy(g, 0.58f);
           // health -= 20;
            isStop = true;
            StartCoroutine(Delay());
        }
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1f);
            transform.position = lastPoint;
            health -= 20;
            isStop = false;
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            /// health -= 20;
            // transform.position = lastPoint;
            StartCoroutine(Delay());
        }
    
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            StartCoroutine(Delay());
        
    }
        if (collision.gameObject.tag == "Health")
        {
            Destroy(collision.gameObject);
            source.PlayOneShot(heltheClip, 1);
            health += 20;
        }
    }
    }
    
