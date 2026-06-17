using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private bool isSpawnable = true;

    private void Start()
    {
        SpawnEnemy(enemyData);
    }

    private void SpawnEnemy(EnemyData enemyData)
    {
        if (!isSpawnable) return;
        if (enemyData == null) return;
        if (enemyData.EnemyPrefab == null) return;

        EnemyBase enemy = Instantiate(enemyData.EnemyPrefab, transform.position, Quaternion.identity);

        enemy.Initialize(enemyData);
        isSpawnable = false;
    }
}
