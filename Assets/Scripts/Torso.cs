using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour {

    [System.Serializable]
    class BackBone
    {
        public Vector2 position;

        public float radius;

        public Vector3 rotation;

        public BackBone leftBackBone;

        public BackBone rightBackBone;

        public BackBone(Vector2 position, float radius)
        {
            this.position = position;
            this.radius = radius;
        }
        public BackBone(float radius)
        {
            this.radius = radius;
        }
    }
    [SerializeField]
    List< BackBone>  backBones = new List<BackBone>();
    BackBone centerBone;
    [SerializeField]
    MeshGenerator mesh;
    float radius = 0.3f;
    private void Start()
    {
        centerBone = new BackBone(radius);
        backBones.Add(centerBone);
    }

    private void Update()
    {
        List<Vector3> vertices = new List<Vector3>();
        BackBone tempBackBone = centerBone;
        while(tempBackBone.leftBackBone != null)
        {
            tempBackBone = tempBackBone.leftBackBone;
        }
        vertices.Add(tempBackBone.position + Vector2.down * 0.5f + Vector2.left*2);
        vertices.Add(tempBackBone.position + Vector2.up * radius + Vector2.left * 2);
        while (tempBackBone != null)
        {
            vertices.Add(tempBackBone.position + Vector2.down * 2);
            vertices.Add(tempBackBone.position + Vector2.up * radius);
            tempBackBone = tempBackBone.rightBackBone; 
        }
        mesh.Vertices = vertices;
    }
    private void OnDrawGizmosSelected()
    {

        for(int i = 0; i < backBones.Count; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(backBones[i].position, backBones[i].radius);
            Gizmos.color = Color.blue;
            if (backBones[i].leftBackBone != null)
            {
                Gizmos.DrawSphere((backBones[i].position + backBones[i].leftBackBone.position)/2, 0.1f);
       
            }
            if (backBones[i].rightBackBone != null)
            {
                Gizmos.DrawSphere((backBones[i].position + backBones[i].rightBackBone.position) / 2, 0.1f);

            }
        }
    }
    int currentBone = -1;

    private void OnGUI()
    {
        Vector2 mousePosition = Input.mousePosition;

        for (int i = 0; i < backBones.Count; i++)
        {
            Vector2 position = Camera.main.WorldToScreenPoint(backBones[i].position);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Vector2.Distance(position, mousePosition) < 5)
                {
                    currentBone = i;
                }
            }


        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentBone = -1;
        }

        if (Input.GetKey(KeyCode.Mouse0) && currentBone != -1)
        {

            Vector2 mouseToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 currentPosition = mouseToWorld;
            if (backBones[currentBone].rightBackBone == null || backBones[currentBone].leftBackBone == null)
            {
                if (Vector2.Distance(currentPosition, backBones[currentBone].position) > (radius * 2) + .1f)
                {
                    BackBone backBone = new BackBone(currentPosition, radius);
                    if (currentPosition.x >= backBones[currentBone].position.x)
                    {
                        backBone.leftBackBone = backBones[currentBone];
                        backBones[currentBone].rightBackBone = backBone;
                    }
                    else
                    {
                        backBone.rightBackBone = backBones[currentBone];
                        backBones[currentBone].leftBackBone = backBone;
                    }
                    backBones.Add(backBone);

                    currentBone = backBones.Count - 1;


                }
            }
        }
    }

}
