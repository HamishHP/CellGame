using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public GameObject enemySpawned;
    public Transform[] spawnPoints;

    private float time = 0;

    public Transform playerPos;

    private void Start()
    {
        SpawnEnemy();
    }

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
        SimpleEnemyScript newEnemy = spawn.GetComponent<SimpleEnemyScript>();
        newEnemy.SetPlayerPos(playerPos);
        spawn.transform.SetParent(null);
    }
}