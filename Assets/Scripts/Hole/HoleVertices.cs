using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleVertices : MonoBehaviour
{
    [Header("Hole Mesh")]
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private MeshFilter meshFilter;    

    [Header("Hole Radius")]
    [SerializeField] private float radius;
    [SerializeField] private Transform holeCenter;

    private Mesh mesh;
    private List<Vector3> offsets = new List<Vector3>();
    private List<int> holeVertices = new List<int>();
    private float distance;
    private int verticesCount;
    private Vector3[] vertices;

    private void Awake()
    {
        mesh = meshFilter.mesh;
        FindVertices();
    }

    private void Update()
    {
        UpdateVerticesPosition();
    }


    private void FindVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);
            if (distance<radius)
            {
                offsets.Add(mesh.vertices[i] - holeCenter.position);
                holeVertices.Add(i);
            }
        }
        verticesCount = offsets.Count;
    }

    private void UpdateVerticesPosition()
    {
        vertices = mesh.vertices;
        for (int i = 0; i < verticesCount; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }

        mesh.vertices = vertices;
        meshCollider.sharedMesh = mesh;
        meshFilter.mesh = mesh;        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }
}
