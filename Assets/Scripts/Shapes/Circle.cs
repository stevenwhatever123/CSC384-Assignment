using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public MeshFilter meshFilter;

    public CircleCollider2D collider;
    
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    void Update()
    {
        if (collider != null)
        {
            CreateMesh();
        }
        else
        {
            meshFilter.mesh = null;
        }
    }

    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh = collider.CreateMesh(false, false);
        meshFilter.mesh = mesh;
    }

    public void setCollider(CircleCollider2D collider2D)
    {
        collider = collider2D;
    }
}
