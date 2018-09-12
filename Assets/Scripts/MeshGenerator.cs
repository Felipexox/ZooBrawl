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
        //vertices = pVertices;
    }
    // Use this for initialization
    void Start() {


      //  vertices = GeneratePositions(verticeAmount);
      //  OrganicModel(27, 27, 27, 0.8f);
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

        for(float i = -vertices; i <= vertices; i +=0.45f)
        {
            float j = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(i, 2) - Mathf.Pow(vertices, 2)));
            tempPositions.Add(new Vector3(i, j, 0));
        }
        for (float i = vertices; i >= -vertices; i-=0.45f)
        {
            float j = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(i, 2) - Mathf.Pow(vertices, 2)));
            tempPositions.Add(new Vector3(i, -j, 0));
        }
        tempPositions.Sort((a, b) => a.x.CompareTo(b.x));

        for(int i =0; i<tempPositions.Count;i++)
        {
            if(i%2==0)
            {
                tempPositions[i] = new Vector3(tempPositions[i].x,-Mathf.Abs(tempPositions[i].y));
            }
            else
            {
                tempPositions[i] = new Vector3(tempPositions[i].x, Mathf.Abs(tempPositions[i].y));
            }
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
        //Debug.Log(triangles);
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
           // Debug.Log(tempTriangles.Count);
        }
        if(vertice %2 !=0)
        {
            tempTriangles.Reverse();
        }
        return tempTriangles.ToArray();
    }
    void OrganicModel(int lastIndex, int index ,int originIndex, float mult)
    {
        int[] indexesNearest = IndexNearest(index);
        if(mult >= 0.25f)
        {
            Vector3 direction = ((vertices[lastIndex] - vertices[index]).normalized) * mult;
            vertices[index] += direction;
            if(indexesNearest[0] == originIndex && indexesNearest[1] == originIndex)
            {
                OrganicModel(originIndex, indexesNearest[0], originIndex, mult / 1.8f);
                OrganicModel(originIndex, indexesNearest[1], originIndex, mult / 1.8f);
            }
            else
            {
                if(indexesNearest[0] != lastIndex)
                {
                    OrganicModel(originIndex, indexesNearest[0], originIndex, mult / 1.8f);

                }
                if (indexesNearest[1] != lastIndex)
                {
                    OrganicModel(originIndex, indexesNearest[1], originIndex, mult / 1.8f);

                }
            }
        }
        
            
    }

    int[] IndexNearest(int index)
    {
        int[] indexes = new int[2];
        float menorValor = 0;
        float menorValor2 = 0;
        if (index!=0)
        {
            menorValor = Vector3.Distance(vertices[index], vertices[0]);
            indexes[0] = 0;
            menorValor2 = Vector3.Distance(vertices[index], vertices[0]);
            indexes[1] = 0;
        }
        else
        {
            menorValor = Vector3.Distance(vertices[index], vertices[1]);
            indexes[0] = 1;
            menorValor2 = Vector3.Distance(vertices[index], vertices[1]);
            indexes[1] = 1;
        } 
        for (int i=0;i<vertices.Count;i++)
        {
            if(Vector3.Distance(vertices[index],vertices[i]) < menorValor && index != i)
            {
                menorValor = Vector3.Distance(vertices[index], vertices[i]);

                indexes[0] = i;
            }
        }
        for (int i = 0; i < vertices.Count; i++)
        {
            if (Vector3.Distance(vertices[index], vertices[i]) < menorValor2 && index != i && indexes[0] != i)
            {
                menorValor2 = Vector3.Distance(vertices[index], vertices[i]);

                indexes[1] = i;
            }
        }
        return indexes;
    }
     // Update is called once per frame
	void Update () {
        CreateMesh();
      
    }
   

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        
        for (int i = 0; i < vertices.Count; i++)
        {

            float radius = (Mathf.Abs(vertices[i].x)/vertices[i].x) * Vector3.Distance(transform.position, vertices[i]);
            float arcTg = Mathf.Atan(vertices[i].y / vertices[i].x);
            Debug.Log(arcTg);
            Vector3 rotation = new Vector3(radius * Mathf.Cos((transform.localEulerAngles.z * Mathf.Deg2Rad) + arcTg) , radius * Mathf.Sin( (transform.localEulerAngles.z * Mathf.Deg2Rad)+ arcTg));
            Gizmos.DrawSphere(transform.position + rotation , 0.1f);

        }
    }
}
