using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//[CustomEditor(typeof(MeshGenerator))]
public class CustomMeshEditor : Editor {
    private float fat = 1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MeshGenerator currentMesh = (MeshGenerator)target;
        if(currentMesh != null)
        {
            fat = EditorGUILayout.FloatField(fat);
          
            for (int i = 0; i < currentMesh.Vertices.Count; i++)
            {

                //  currentMesh.Mesh.vertices[i].y = currentMesh.Vertices[i].y * fat;
            }
            
        }
    }
}
