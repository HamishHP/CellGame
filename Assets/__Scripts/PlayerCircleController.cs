using UnityEngine;

public class PlayerCircleController : MonoBehaviour
{
    public Camera cam;
    public ShootScript shootScript;
    private ScoreHandler scoreHandler;

    public SpriteRenderer sr;
    private bool isDead = false;

    public GameObject resetButton;

    //private int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        scoreHandler = GetComponent<ScoreHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            shootScript.StopShooting();
            sr.enabled = false;
            resetButton.SetActive(true);
            return;
        }

        FaceCursor();

        if (Input.GetMouseButtonDown(0))
        {
            shootScript.StartShooting();
        }

        if (Input.GetMouseButtonUp(0))
        {
            shootScript.StopShooting();
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        return mousePos;
    }

    private Vector3 GetMouseDirection()
    {
        // Calculate the direction vector from the character to the mouse pointer
        Vector3 direction = GetMousePos() - transform.position;
        return direction.normalized;
    }

    private void FaceCursor()
    {
        Vector3 direction = GetMouseDirection();

        // Calculate the angle in degrees between the direction vector and the right vector (being the x vector)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the character to face the mouse pointer
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    /*public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            Debug.Log("Oops died");
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            scoreHandler.IncrementScore();
        }
    }
}