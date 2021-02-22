using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Instant_Mesh : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public GameObject maze;

    public int xSize = 20;
    public int zSize = 20;
    public int global_serialdata = 0;

    public int serialCounter = 0;
    public int[] serialData;

    void Awake()
    {
        serialData = new int[xSize * zSize];

    }

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

        for (int i = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 21f;
                //vertices[i] = new Vector3(x, y * global_serialdata/90, z);
                vertices[i] = new Vector3(x, y * serialData[i]/90, z);
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

        GameObject.FindGameObjectWithTag("Particle").GetComponent<Serial_Particle>().OnMessageArrived(message);  //controlling Particle System; script Serial_Particle

        int serialdata = System.Convert.ToInt32(message);
        global_serialdata = serialdata;

        serialData[serialCounter] = serialdata;
        serialCounter++;
        if (serialCounter >= xSize * zSize)
            serialCounter = 0;

        CreateShape();

        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            colors[i] = Color.Lerp(Color.magenta, Color.blue, serialdata/100);
            //colors[i] = Color.Lerp(Color.red, Color.green, .5f);
        }
        
        mesh.colors = colors;

        UpdateMesh();

        movingMaze(global_serialdata);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }

    void movingMaze(int data)
    {
        maze.transform.rotation = Quaternion.Euler(0, 0, global_serialdata);
    }

}
