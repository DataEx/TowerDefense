using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float timeToMoveBetweenTiles; 
    public EnemySpawner spawner;
    public List<Tile> route;
    int indexAlongRoute = 0;
    public float health = 3;
    public int rewardOnDestroy;

    void Start() {
        StartCoroutine(MoveAlongPath());
    }

    IEnumerator MoveAlongPath() {
        float elapsedTime;
        while (indexAlongRoute < route.Count) {
            Vector3 currentPosition = this.transform.position;
            Vector3 targetPosition = route[indexAlongRoute].transform.position;
            elapsedTime = 0f;
            while (elapsedTime < timeToMoveBetweenTiles) {
                yield return new WaitForFixedUpdate();
                elapsedTime += Time.fixedDeltaTime;
                this.transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / timeToMoveBetweenTiles);
            }
            this.transform.position = targetPosition;
            indexAlongRoute++;
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Bullet>())
        {
            float damageDealt = collider.GetComponent<Bullet>().damage;
            health -= damageDealt;
            Destroy(collider.gameObject);
            if (health < 0) {
                CurrencyController.AdjustCurrency(rewardOnDestroy);
                spawner.enemiesDestroyed++;
                Destroy(this.gameObject);
            }
        }
    }
}
