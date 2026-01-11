using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public GameObject enemySpawned;
    public Transform[] spawnPoints;

    float time;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > spawnRate)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawn = Instantiate(enemySpawned, spawnPoint);
        spawn.transform.SetParent(null);
    }
}
