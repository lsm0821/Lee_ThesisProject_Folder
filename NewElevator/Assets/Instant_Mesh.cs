using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Instant_Mesh : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;
    public int global_serialdata = 0;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();

        //CreateShape();
        UpdateMesh();
    }


    void CreateShape()
    {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //int i = 0;

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 21f;
                vertices[i] = new Vector3(x, y * global_serialdata/90, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //triangles = new int[6];
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }






        /*
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0),
            new Vector3 (1,0,1)
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
        */

    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals(); //for lighting calculation. 
    }

    void OnMessageArrived(string message)
    {
        Debug.Log(message);

        int serialdata = System.Convert.ToInt32(message);
        global_serialdata = serialdata;

        CreateShape();

        UpdateMesh();

        /*if (midValue == 192)
        {
            midValue = System.Convert.ToInt32(message);
        }*/

        //GetComponent<Elevator>().speed = midValue - System.Convert.ToInt32(message);

        //GetComponent<Elevator>().speed = System.Convert.ToInt32(message);

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }

}
