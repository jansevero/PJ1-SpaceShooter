using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO; //prefab
    public GameObject ItemGO; //prefab
    public GameObject GameManagerGO; //referência

    float maxSpawnRateInSeconds = 5f;

    //chamado em ScheduleNextEnemySpawn
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instancia um clone de inimigo
        GameObject anEnemy = Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //chance de criar item
        if (Random.Range(0,19) < 1)
        {
            GameObject anItem = Instantiate(ItemGO);
            anItem.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

        ScheduleNextEnemySpawn();
    }

    //planeja nascimento do próximo inimigo
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //chamada em ScheduleEnemySpawner
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 5f; //reseta tempo de spawn máximo
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
