using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private List<Vector3> vertices = new List<Vector3>();

    public static MeshGenerator instance;
    [SerializeField]
    private Vector3[] normalsV;

    [SerializeField]
    private int[] triangules;
    [SerializeField]
    private int verticeAmount;
    [SerializeField]
    private Vector2[] uv;
    int vertice = 0;
    private void Awake()
    {
        instance = this;
    }
    public void SubVertices(List<Vector3> pVertices)
    {
        vertices = pVertices;
    }
    // Use this for initialization
    void Start() {


        //vertices = GeneratePositions(verticeAmount);
        //triangules = new int[(vertices.Count - 2) * 3];
    }
 
    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh = mesh;

        mesh.vertices = vertices.ToArray();

        normalsV = new Vector3[vertices.Count];
        for (int i = 0; i < normalsV.Length; i++)
        {
            normalsV[i] = Vector3.back;
        }

        uv = new Vector2[vertices.Count];
        for (int i = 0; i < vertices.Count; i++)
        {
            uv[i] = vertices[i];
        }
        triangules = CreateTriangles(vertices.Count);
        // triangules.Length
        mesh.normals = normalsV;
        mesh.triangles = triangules;
        mesh.uv = uv;

    }
 
    List<Vector3> GeneratePositions(int vertices)
    {
        List<Vector3> tempPositions = new List<Vector3>();
        for(int i = 0; i < vertices; i++)
        {
            float x = i * 0.3f;
            Vector3 position = Vector3.zero;
            if(i<=3)
            {
                position.x =x;
                position.y = Mathf.Pow(x, 3);
            }
            else
            {
                position.x = 3*0.3f;
                position.y = -x+1.5f;
            }
            tempPositions.Add(position);
        }
        return tempPositions;
    }
    int CalcTriangle(int vertices)
    {
        return ((vertices - 2));
    }
	int[] CreateTriangles(int vertice)
    {
        int triangles = CalcTriangle(vertice);
        Debug.Log(triangles);
        List<int> tempTriangles = new List<int>();
        for(int i = 0; i < triangles; i++)
        {
            if (i % 2 == 0)
            {
                tempTriangles.AddRange(new int[]{ i, i + 1, i +2});
            }
            else
                tempTriangles.AddRange(new int[] { i + 1, i, i + 2 });
        }
        for(int i = 0; i < tempTriangles.Count; i++)
        {
            Debug.Log(tempTriangles.Count);
        }
        if(vertice %2 !=0)
        {
            tempTriangles.Reverse();
        }
        return tempTriangles.ToArray();
    }
	// Update is called once per frame
	void Update () {
        CreateMesh();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < vertices.Count; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
