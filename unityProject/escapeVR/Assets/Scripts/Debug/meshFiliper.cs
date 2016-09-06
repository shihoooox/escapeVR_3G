using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class meshFiliper : MonoBehaviour {
	public int screening = 0;

	// Use this for initialization
	void Start () {
		MeshFilter filter = GetComponent<MeshFilter>();
		if (filter != null)
		{
			Mesh mesh = filter.mesh;
			Vector3[] verts = mesh.vertices;
			for (int m=0;m<mesh.subMeshCount;m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i=0;i<triangles.Length;i+=3)
				{
					Vector3 v1 = verts[triangles[i+1]]-verts[triangles[i]];
					Vector3 v2 = verts[triangles[i+2]]-verts[triangles[i]];
					Vector3 v1v2 = Vector3.Cross(v1,v2);

					if(screening==0||((screening<0)&&(v1v2.y < 0))||((screening>0)&&(v1v2.y > 0))) {
						int temp = triangles[i + 0];
						triangles[i + 0] = triangles[i + 1];
						triangles[i + 1] = temp;
					}
				}
				mesh.SetTriangles(triangles, m);
			}
			mesh.RecalculateNormals();	
		}	

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
