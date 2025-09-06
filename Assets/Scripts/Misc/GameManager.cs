using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    public int health = 3;
    public int score = 0;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemies;
    private int ranPoint;
    private int spawnIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health = " + health;
        scoreText.text = "Score = " + score;

        StartCoroutine(SpawnTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainScore()
    {
        score += 100;
        scoreText.text = "Score = " + score;
    }

    public void LoseHealth()
    {
        health -= 1;
        healthText.text = "Health = " + health;

        if (health == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            ranPoint = Random.Range(0, points.Length);

            spawnIndex = Random.Range(0, enemies.Length);

            Instantiate(enemies[spawnIndex], points[ranPoint].position, Quaternion.identity);

            yield return new WaitForSeconds(2);
        }
    }
}
