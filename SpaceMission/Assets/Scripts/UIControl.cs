using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    GameObject title = default;

    [SerializeField]
    GameObject gameOver = default;

    [SerializeField]
    Text puan = default;

    [SerializeField]
    GameObject score = default;

    [SerializeField]
    GameObject playButton = default;

    int asteroidPuani;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        puan.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

    }

    public void OyunBasladi()
    {
        asteroidPuani = 0;
        playButton.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
        puan.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        UpdateScore();
    }

    public void OyunBitti()
    {
        gameOver.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }


    void UpdateScore()
    {
        puan.text = asteroidPuani.ToString();
       
    }

    public void AsteroidYokEdildi(GameObject asteroid)
    {
        asteroidPuani += 10;
        UpdateScore();
    }
}
