using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(this.gameObject);
	}
	
}
