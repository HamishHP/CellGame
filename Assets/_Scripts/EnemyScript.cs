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

    private EnemyState currentState = EnemyState.IDLE;

    public float idleTimer = 4f;
    public float wanderTimer = 2f;

    public float attackRange = 5f;

    private ShootScript shootScript;

    private Transform playerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        shootScript = GetComponent<ShootScript>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator DoIdle()
    {
        yield return new WaitForSeconds(idleTimer);
        StartCoroutine(DoWander());
    }

    private IEnumerator DoWander()
    {
        //aim near player
        shootScript.StartShooting();
        yield return new WaitForSeconds(wanderTimer);
        shootScript.StopShooting();
        StartCoroutine(DoIdle());
    }

    public void SetPlayerPos(Transform playerPos)
    {
        playerPosition = playerPos;
    }
}