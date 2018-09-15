using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MeshGenerator : MonoBehaviour {
    [Header("Mesh Propriety")]
    [SerializeField]
    private int verticeAmount;
    private float z = 0;
    private Vector3 teste = Vector3.zero;

    [Header("Internal Controller")]
    [SerializeField]
    private List<Vector3> vertices = new List<Vector3>();
    [SerializeField]
    private Vector3[] normalsV;
    [SerializeField]
    private int[] triangules;
    [SerializeField]
    private Vector2[] uv;
    public Mesh mesh;

    private void Start()
    {
        
    }
    private void Update()
    {
        CreateMesh();

        // tentei fazer isso

        /*if(transform.position.z!=z)
        {
            for(int i=0;i<Vertices.Count;i++)
            {
                vertices[i] = RotByAngle(Vertices[i]);
            }
        }
        if(transform.position!=teste)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                vertices[i] = transform.position + RotByAngle(vertices[i]);
            }
        }
        z = transform.position.z;
        teste = transform.position;*/
    }
    void CreateMesh()
    {
        mesh = new Mesh();
        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh = mesh;

        mesh.vertices = Vertices.ToArray();

        NormalsV = new Vector3[Vertices.Count];
        for (int i = 0; i < NormalsV.Length; i++)
        {
            NormalsV[i] = Vector3.back;
        }

        Uv = new Vector2[Vertices.Count];
        for (int i = 0; i < Vertices.Count; i++)
        {
            Uv[i] = Vertices[i];
        }
        Triangules = CreateTriangles(Vertices.Count);
        // triangules.Length
        mesh.normals = NormalsV;
        mesh.triangles = Triangules;
        mesh.uv = Uv;

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
            Vector3 direction = ((Vertices[lastIndex] - Vertices[index]).normalized) * mult;
            Vertices[index] += direction;
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
            menorValor = Vector3.Distance(Vertices[index], Vertices[0]);
            indexes[0] = 0;
            menorValor2 = Vector3.Distance(Vertices[index], Vertices[0]);
            indexes[1] = 0;
        }
        else
        {
            menorValor = Vector3.Distance(Vertices[index], Vertices[1]);
            indexes[0] = 1;
            menorValor2 = Vector3.Distance(Vertices[index], Vertices[1]);
            indexes[1] = 1;
        } 
        for (int i=0;i<Vertices.Count;i++)
        {
            if(Vector3.Distance(Vertices[index],Vertices[i]) < menorValor && index != i)
            {
                menorValor = Vector3.Distance(Vertices[index], Vertices[i]);

                indexes[0] = i;
            }
        }
        for (int i = 0; i < Vertices.Count; i++)
        {
            if (Vector3.Distance(Vertices[index], Vertices[i]) < menorValor2 && index != i && indexes[0] != i)
            {
                menorValor2 = Vector3.Distance(Vertices[index], Vertices[i]);

                indexes[1] = i;
            }
        }
        return indexes;
    }

   
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        
        for (int i = 0; i < Vertices.Count; i++)
        {

            Vector3 rotation = RotByAngle(vertices[i]);
            Gizmos.DrawSphere(transform.position + rotation , 0.1f);

        }
    }

    int currentVertice = -1;

    private void OnGUI()
    {
        Vector2 mousePosition = Input.mousePosition;

        for (int i = 0; i < vertices.Count; i++)
        {
            Vector2 position = Camera.main.WorldToScreenPoint(RotByAngle(vertices[i]) + transform.position);
           
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Vector2.Distance(position, mousePosition) < 5)
                {
                    currentVertice = i;
                }
            }
            
          
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentVertice = -1;
        }
        if (Input.GetKey(KeyCode.Mouse0) && currentVertice != -1)
        {
       
            Vector2 mouseToWorld = Camera.main.ScreenToWorldPoint(mousePosition) ;
            Vector3 rotation = AngleByRot(mouseToWorld);

            Vector2 currentPosition = rotation - transform.position;
        
            vertices[currentVertice] = currentPosition;
        }
    }

    public Vector3 RotByAngle(Vector3 Vertice)
    {
        Vector3 nulo = Vector3.zero;
        float radius = (Mathf.Abs(Vertice.x) / Vertice.x) * Vector3.Distance(nulo, Vertice);
        float arcTg = Mathf.Atan(Vertice.y / Vertice.x);
        Vector3 rotation = new Vector3(radius * Mathf.Cos((transform.localEulerAngles.z * Mathf.Deg2Rad) + arcTg), radius * Mathf.Sin((transform.localEulerAngles.z * Mathf.Deg2Rad) + arcTg));
        return rotation;
    }
    public Vector3 AngleByRot(Vector3 Vertice)
    {
        Vector3 nulo = Vector3.zero;
        float radius = (Mathf.Abs(Vertice.x) / Vertice.x) * Vector3.Distance(nulo, Vertice);
        float arcTg = Mathf.Atan(Vertice.y / Vertice.x);
        Vector3 rotation = new Vector3(radius * Mathf.Cos((transform.localEulerAngles.z * Mathf.Deg2Rad) - arcTg), -radius * Mathf.Sin((transform.localEulerAngles.z * Mathf.Deg2Rad) - arcTg));
        return rotation;
    }
    public int VerticeAmount
    {
        get
        {
            return verticeAmount;
        }

        set
        {
            verticeAmount = value;
        }
    }

    public List<Vector3> Vertices
    {
        get
        {
            return vertices;
        }

        set
        {
          
            vertices = value;
            
        }
    }

    public Vector3[] NormalsV
    {
        get
        {
            return normalsV;
        }

        set
        {
            normalsV = value;
        }
    }

    public int[] Triangules
    {
        get
        {
            return triangules;
        }

        set
        {
            triangules = value;
        }
    }

    public Vector2[] Uv
    {
        get
        {
            return uv;
        }

        set
        {
            uv = value;
        }
    }

 
 
}
