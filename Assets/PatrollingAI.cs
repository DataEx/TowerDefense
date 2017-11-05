using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PatrollingAI : MonoBehaviour {

    public Transform target;
    Vector3 start;
    Vector3 end;
    bool movingToEnd = true;

	void Awake() {
        start = this.transform.position;
        end = target.transform.position;
	}

    void Update() {
        AICharacterControl ai = GetComponent<AICharacterControl>();
        if (ai.agent.remainingDistance <= ai.agent.stoppingDistance) {
            if (movingToEnd)
            {
                target.position = start;
                movingToEnd = false;
            }
            else {
                target.position = end;
                movingToEnd = true;
            }
        }

    }


}
