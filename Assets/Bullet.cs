using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Enemy target;
    public float speed = 15;
    public float damage = 1f;

    void FixedUpdate() {
        if (target == null) {
            Destroy(this.gameObject);
        }
        try
        {
            MoveToTarget();
        }
        catch (MissingReferenceException r) {
            Destroy(this.gameObject);
        }
    }


    void MoveToTarget() {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, Time.fixedDeltaTime * speed);
    }
}
