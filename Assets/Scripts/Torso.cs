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
    public float teste;

    [SerializeField]
    private MeshGenerator mesh;

    private void Start()
    {
        teste = 1;
        mesh.Vertices = vertices;
    }
    private void Update()
    {
        if(teste!=height)
        {
            mesh.vertices = HeightNLength(height,length);
        }
        teste = height;
        mesh.CreateMesh();
    }
    private List<Vector3> HeightNLength(float height,float length)
    {
        
        for (int i =0;i<4;i++)
        {
            vertices[i] = new Vector3(vertices[i].x*length, vertices[i].y * height);
        }
        return vertices;
    }

}
