using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private int speed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip shootSound;

    public void SpawnBullet()
    {
        GameObject bullet = Instantiate(shoot, spawnPoint);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }
}
