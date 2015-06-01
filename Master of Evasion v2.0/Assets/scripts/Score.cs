using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {//класс считающий очки

    public Text scoreText;
    public int ballValue;

    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "Score:\n" + score;
	}

    void OnTriggerEnter2D()
    {
        score += ballValue=1;
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            score -= ballValue = 2;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;
    }
}
