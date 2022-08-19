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
    private float scaleUpValue = 1.1f;
    private HoleMovement holeMovement;

    private void Awake()
    {
        mesh = meshFilter.mesh;
        FindVertices();
        holeMovement = GetComponent<HoleMovement>();
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

    public void UpScaleHole()
    {
        vertices = mesh.vertices;
        for (int i = 0; i < verticesCount; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i]* scaleUpValue;
        }

        mesh.vertices = vertices;
        meshCollider.sharedMesh = mesh;
        meshFilter.mesh = mesh;

        holeCenter.localScale *= scaleUpValue;
        radius *= scaleUpValue;
        ChangeBoundaryValues();

        for (int i = 0; i < offsets.Count; i++)
        {
            offsets[i] *= scaleUpValue;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }

    private void ChangeBoundaryValues()
    {
        holeMovement.boundaryXValue /= scaleUpValue * 0.95f;        
        holeMovement.boundaryZValue /= scaleUpValue * 0.93f;
       
    }
}
