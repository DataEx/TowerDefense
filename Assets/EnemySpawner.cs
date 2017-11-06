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
        enemy.transform.position = this.transform.position;
        enemy.spawner = this;
        enemy.route = grid.navigationPath;
    }

    void Update() {
        if (enemiesDestroyed == enemiesToSpawn) {
            print("You beat the level!");
            levelController.EndLevel();
        }
    }
}
