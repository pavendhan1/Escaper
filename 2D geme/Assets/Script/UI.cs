using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI CoineText;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip ButtonClip;
    [SerializeField] Score scroe;
    // Start is called before the first frame update
    void Start()
    {
       scroe= GetComponent<Score>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text= scroe.coinScore.ToString();
        CoineText.text="Score :"+ scroe.coinScore.ToString();
    }
    public void Restart()
    {
        source.PlayOneShot(ButtonClip, 1);
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        source.PlayOneShot(ButtonClip, 1);
        SceneManager.LoadScene("Start");
    }
}

