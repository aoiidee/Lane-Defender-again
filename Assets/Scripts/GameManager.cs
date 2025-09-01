using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    public int health = 3;
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health = " + health;
        scoreText.text = "Score = " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            gameOver.SetActive(true);
        }
    }
}
