using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private enum EnemyState
    {
        IDLE,
        WANDER,
        ATTACK,
    }

    public float idleTimer = 4f;
    public float wanderTimer = 2f;
    public float wanderAimVariance = 20f;

    public float attackRange = 5f;
    public float shootRange = 7f;

    private ShootScript shootScript;

    private Transform playerPosition;

    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        shootScript = GetComponent<ShootScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < attackRange && !isAttacking)
        {
            shootScript.StopShooting();
            StopAllCoroutines();
            isAttacking = true;
        }

        if (isAttacking && Vector2.Distance(transform.position, playerPosition.position) < shootRange)
        {
            RotateToPlayer();
            shootScript.StartShooting();
        } // left off here
    }

    private IEnumerator DoIdle()
    {
        yield return new WaitForSeconds(idleTimer);
        StartCoroutine(DoWander());
    }

    private IEnumerator DoWander()
    {
        //aim near player
        RotateToPlayer();
        transform.Rotate(0, 0, Random.Range(-wanderAimVariance, wanderAimVariance));

        shootScript.StartShooting();
        yield return new WaitForSeconds(wanderTimer);
        shootScript.StopShooting();
        StartCoroutine(DoIdle());
    }

    private IEnumerator DoAttack()
    {
        while (Vector2.Distance(transform.position, playerPosition.position) < shootRange)
        {
        }
        shootScript.StopShooting();
        yield return null;
    }

    private void RotateToPlayer()
    {
        Vector3 direction = playerPosition.position - transform.position;
        direction.Normalize();

        // Calculate the angle in degrees between the direction vector and the right vector (being the x vector)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the character to face the mouse pointer
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void SetPlayerPos(Transform playerPos)
    {
        playerPosition = playerPos;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}