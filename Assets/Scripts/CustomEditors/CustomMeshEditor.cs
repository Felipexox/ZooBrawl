using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMeshEditor : MonoBehaviour
{
    float fat = 1;
    public MeshGenerator currentMesh;
    public void OnGUI()
    {
        if(currentMesh != null)
        {
            GUILayout.BeginArea(new Rect(new Vector2(Screen.width / 2, 50), new Vector2(200, 200)));
            fat = GUILayout.HorizontalScrollbar(fat, 0.2f, 0, 1);
            GUILayout.EndArea();
            
        }
        
    }

    public void FatEditor(MeshGenerator meshGen,float fat)
    {
        for(int i = 0; i < meshGen.Vertices.Count; i++)
        {

        }
    }
}
