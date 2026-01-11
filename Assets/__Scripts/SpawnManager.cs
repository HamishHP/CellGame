using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public GameObject enemySpawned;
    public Transform[] spawnPoints;

    private float time;

    public Transform playerPos;

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;

        if (time > spawnRate)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawn = Instantiate(enemySpawned, spawnPoint);
        EnemyScript newEnemy = spawn.GetComponent<EnemyScript>();
        newEnemy.SetPlayerPos(playerPos);
        spawn.transform.SetParent(null);
    }
}