using UnityEngine;

public class SimpleEnemyScript : MonoBehaviour
{
    private Transform playerPosition;

    public float moveSpeed = 2f;

    public float wiggleAmplitude = 0.3f;
    public float wiggleTime = 1f;

    public float rotationSmoothing = 0.1f;

    public int health = 3;

    public GameObject coinObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        RotateToPlayer();

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void RotateToPlayer()
    {
        Vector3 direction = playerPosition.position - transform.position;
        direction.Normalize();

        // Calculate the angle in degrees between the direction vector and the right vector (being the x vector)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the character to face the mouse pointer
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotationSmoothing);

        transform.Rotate(0, 0, wiggleAmplitude * Mathf.Sin(wiggleTime * Time.timeSinceLevelLoad));
    }

    public void SetPlayerPos(Transform playerPos)
    {
        playerPosition = playerPos;
    }

    public void TakeDamage()
    {
        health--;
        if (health < 0)
        {
            Instantiate(coinObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}