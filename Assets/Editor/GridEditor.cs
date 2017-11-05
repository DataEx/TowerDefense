using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Grid gridScript = (Grid)target;
        if (GUILayout.Button("Build NavMesh"))
        {
            gridScript.ResetNavMesh();
        }
    }
}
