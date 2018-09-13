using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageToVector : MonoBehaviour {
    [SerializeField]
    Texture2D image;
    private void Start()
    {
        Points();
    }
    void Points()
    {
        List<Vector3> vectors = new List<Vector3>();
        for(int i = 0; i < image.width; i++)
        {
            for(int j = 0; j < image.height; j++)
            {
                if(image.GetPixel(i,j).a != 0)
                {
                    vectors.Add(new Vector2(i, j));
                }
            }
        }
    }
}
