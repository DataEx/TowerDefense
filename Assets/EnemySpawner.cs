using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public LevelController levelController;

    public Enemy enemyToSpawn;
    public int enemiesToSpawn;
    public float spawnInterval;

    int enemiesSpawned = 0;
    public int enemiesDestroyed = 0;

    public int rewardForCompletingLevel;

    public Grid grid;

    void Start() {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {
        while (enemiesSpawned < enemiesToSpawn) {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy() {
        Enemy enemy = Instantiate(enemyToSpawn) as Enemy;
        enemy.transform.position = AStarUtility.startTile.transform.position;
        enemy.spawner = this;
        enemy.route = grid.navigationPath;
    }

    void Update() {
        if (enemiesDestroyed == enemiesToSpawn) {
            levelController.EndLevel();
        }
    }

    public void IncrementEnemiesDestroyed() {
        enemiesDestroyed++;
        MenuController.messageUI.UpdateEnemiesRemaining(GetEnemiesRemaining());
    }

    public int GetEnemiesRemaining() {
        return enemiesToSpawn - enemiesDestroyed;
    }
}
