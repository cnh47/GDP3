using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTrigger : MonoBehaviour
{
    public bool Triggered = false;
    public float scale = 0.1f;
    public float speed = 1.0f;
    public float noiseStrength = 1f;
    public float noiseWalk = 1f;
    private Vector3[] baseHeight;
    float zTrigger = 0f;
    float xTrigger = 0f;
    public Transform player;

    public GameObject pool;

    // Update is called once per frame
    void Update()
    {
        if(Triggered == true){
            Mesh mesh = pool.GetComponent<MeshFilter>().mesh;

            if (baseHeight == null)
                baseHeight = mesh.vertices;

            Vector3[] vertices = new Vector3[baseHeight.Length];
            for (int i=0;i<vertices.Length;i++)
            {
                Vector3 vertex = baseHeight[i];
                vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
                vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f/100)    ) * noiseStrength;
                vertices[i] = vertex;
            }
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
        }
    }

    void OnTriggerEnter(Collider other){
        Triggered = true;
        Debug.Log(player.position.x + ", " + player.position.z);
    }
}
