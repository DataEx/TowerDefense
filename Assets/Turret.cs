using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float range;
    public Transform rotator;
    public Transform bulletSpawnPoint;
    float turnSpeed = 10f;
    public Bullet bulletPrefab;
    public float timeBetweenFire;


    Enemy target;
    List<Enemy> enemiesInRange = new List<Enemy>();

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Awake() {
        GetComponent<CapsuleCollider>().radius = range / this.transform.localScale.x;
        StartCoroutine(AutoFireBullets());
    }

    IEnumerator AutoFireBullets()
    {
        while (true) {
            if (target != null)
            {
                FireBullet();
            }
            yield return new WaitForSecondsRealtime(timeBetweenFire);
        }
    }

    void FireBullet() {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.target = target;
        bullet.transform.position = bulletSpawnPoint.position;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        bullet.transform.rotation = lookRotation;

    }

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<Enemy>()) {
            enemiesInRange.Add(collider.GetComponent<Enemy>());
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            enemiesInRange.Remove(collider.GetComponent<Enemy>());
        }
    }


    void FixedUpdate() {
        while (enemiesInRange.Count > 0 && enemiesInRange[0] == null)
        {
            enemiesInRange.RemoveAt(0);
        }

        if (enemiesInRange.Count > 0)
        {
            target = enemiesInRange[0];
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.fixedDeltaTime * turnSpeed).eulerAngles;
            rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        else {
            target = null;
        }
    }

}
