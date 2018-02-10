using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class DynamicRoadGenerator : MonoBehaviour {	
	private Mesh mesh;

	public int Seed;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
			MeshFilter mf = GetComponent<MeshFilter>();
			Mesh meshCopy = Mesh.Instantiate(mf.sharedMesh) as Mesh;
			mesh = mf.mesh = meshCopy;
		#else
			mesh = GetComponent<MeshFilter>().mesh;	
		#endif

		Generate();
		// Generate Vertices

		// Generate Triangles
	}

	void Generate() {
		int xSize = 10;
		int ySize = 10;
		Vector3[] vertices;
		
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		for (int i = 0, y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++, i++) {
				vertices[i] = new Vector3(x, y);
			}
		}
		mesh.vertices = vertices;

		int[] triangles = new int[xSize * ySize * 6];
		for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
			for (int x = 0; x < xSize; x++, ti += 6, vi++) {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
				triangles[ti + 5] = vi + xSize + 2;
			}
		}
		mesh.triangles = triangles;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
