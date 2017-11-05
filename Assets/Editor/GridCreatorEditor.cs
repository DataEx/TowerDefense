using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridCreator))]
public class GridCreatorEditor : Editor {


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridCreator gridScript = (GridCreator)target;
        if (GUILayout.Button("Build Grid"))
        {
            gridScript.CreateGrid();
        }
    }
}
