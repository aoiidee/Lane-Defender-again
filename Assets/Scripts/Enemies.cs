using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D c2d;
    [SerializeField] private GameManager gm;
    [SerializeField] private Animator ani;

    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip death;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2d = GetComponent<Collider2D>();
        gm = GetComponent<GameManager>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 1;
            AudioSource.PlayClipAtPoint(hit, transform.position);

            if (health < 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(death, transform.position);
                gm.score += 100;
            }
        }

        if (collision.transform.tag == "health")
        {
            gm.health -= 1;
        }
    }
}
