using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    [SerializeField]
    [Range(10,100)]
    private float fat;
    [SerializeField]
    private float length;
    [SerializeField]
    private float height;
    [SerializeField]
    public List<Vector3> vertices = new List<Vector3>();

    [SerializeField]
    private MeshGenerator mesh;

    private void Start()
    {
        mesh.Vertices = new List<Vector3>(vertices);
    }
    private void Update()
    {
      
        HeightNLength(height,length);
        
     
     
    }
    private void HeightNLength(float height,float length)
    {
        
        for (int i =0;i<4;i++)
        {
            mesh.vertices[i] = new Vector3(vertices[i].x*length, vertices[i].y * height);
        }
    }

}
