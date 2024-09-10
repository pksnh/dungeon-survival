using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text scoreText;
    public Text bestscoreText;

    private float surviveScore;
    private bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
            surviveScore = 0;
            isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveScore += Time.deltaTime;
            scoreText.text = "Score: " + (int)surviveScore;
        }
        else
        {
            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Samplescene");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(surviveScore > bestScore)
        {
            bestScore = surviveScore;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        bestscoreText.text = "Best Score: " + (int)bestScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
