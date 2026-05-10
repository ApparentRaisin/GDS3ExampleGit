using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(Examples))]
public class ExamplesEditor : Editor
{
    //I am an example editor
}
#endif

public class Examples : MonoBehaviour
{
    public Mesh instanceMesh;
    public Material instanceMaterial;

    List<Matrix4x4> TRSmatrix = new List<Matrix4x4>();
    
    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            TRSmatrix.Add(Matrix4x4.TRS(Random.insideUnitSphere*10, Quaternion.identity, Vector3.one));
        }
    }

    void Update()
    {
        Graphics.DrawMeshInstanced(instanceMesh, 0, instanceMaterial, TRSmatrix.ToArray());
    }
}


