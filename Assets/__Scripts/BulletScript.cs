using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float moveSpeed = 5f;

    private Rigidbody2D rb;

    public float bulletLifetime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * moveSpeed;
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<SimpleEnemyScript>().TakeDamage();
        }

        /*if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCircleController>().TakeDamage();
        }*/

        Destroy(gameObject);
    }

    public void SetBulletSpeed(float speed)
    {
        moveSpeed = speed;
    }
}