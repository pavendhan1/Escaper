using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{
    public GameObject OptionImage;
    public GameObject MenuImage;
    public AudioSource source;
    public AudioClip Buttonclip;
    // Start is called before the first frame update
    void Start()
    {
        OptionImage.SetActive(false);
        source=GetComponent<AudioSource>();

    }

  public void Play()
    {
        source.PlayOneShot(Buttonclip, 1);
        SceneManager.LoadScene("Game");
    }
    public void Quid()
    {
        source.PlayOneShot(Buttonclip, 1);
        Application.Quit();
    }
    public void Option()
    {
        source.PlayOneShot(Buttonclip, 1);
        OptionImage.SetActive(true);
        MenuImage.SetActive(false);
    }
    public void Back()
    {
        source.PlayOneShot(Buttonclip, 1);
        OptionImage.SetActive(false );
        MenuImage.SetActive(true);
    }
}
