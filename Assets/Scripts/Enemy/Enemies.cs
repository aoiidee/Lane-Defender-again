using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D c2d;
    [SerializeField] private Animator ani;
    private GameManager gm;

    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip death;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2d = GetComponent<Collider2D>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 1;
            ani.SetBool("Hit", true);
            AudioSource.PlayClipAtPoint(hit, transform.position);
            Destroy(collision.gameObject);

            if (health < 0)
            {
                ani.SetBool("Dead", true);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(death, transform.position);
                gm.GainScore();
            }
        }

        if (collision.transform.tag == "health")
        {
            gm.LoseHealth();
            Destroy(gameObject);
        }
    }
}
