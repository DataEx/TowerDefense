using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grid : MonoBehaviour {

    public Transform walkables;
    public Transform nonWalkables;
    NavMeshSurface navMeshCreator;

    void Awake() {
        navMeshCreator = walkables.GetComponent<NavMeshSurface>();
    }

    public void ResetNavMesh() {
        navMeshCreator = walkables.GetComponent<NavMeshSurface>();

        navMeshCreator.BuildNavMesh();
    }
}
