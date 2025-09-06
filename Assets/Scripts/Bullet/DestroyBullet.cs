using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
