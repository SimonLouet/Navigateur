/*
 * The .obj and .mtl files must follow Wavefront OBJ Specifications.
 *
 * OBJ Supported List
 *
 *   Vertex Data
 *     - v  Geometric vertices (not support w)
 *     - vt Texture vertices (not support w)
 *     - vn Vertex normals
 *
 *   Elements
 *     - f Face (only support triangulate faces)
 *
 *   Grouping
 *     - o Object name
 *
 *   Display
 *     - mtllib Material library (not support multiple files)
 *     - usemtl Material name
 *
 * MTL Supported List
 *
 *   Material Name
 *     - newmtl Material name
 *
 *   Texture Map
 *     - map_Kd Texture file is linked to the diffuse (not support options)
 */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileReader {

	public struct MeshFile {
		public string o;
		public string mtllib;
		public List<string> usemtl;
		public List<Vector3> v;
		public List<Vector3> vn;
		public List<Vector2> vt;
		public List<List<int[]>> f;
	}

	public static Mesh ReadObjFile (string data) {
        float maxX = 0;
        float maxXline = 0;
        float x = 0;
		MeshFile obj = new MeshFile ();

		obj.usemtl = new List<string> ();
		obj.v = new List<Vector3> ();
		obj.vn = new List<Vector3> ();
		obj.vt = new List<Vector2> ();
		obj.f = new List<List<int[]>> ();
        
        string[] lines = data.Split('\n');
        obj.f.Add (new List<int[]> ());
		foreach (string line in lines) {
			if (line == "" || line.StartsWith ("#"))
				continue;
			string[] token = line.Split (' ');
			switch (token [0]) {

			case ("o"):
				obj.o = token [1];
				break;
			case ("mtllib"):
				obj.mtllib = token [1];
				break;
			case ("usemtl"):
				//obj.usemtl.Add (token [1]);
				//obj.f.Add (new List<int[]> ());
				break;
			case ("v"):
                if(float.Parse (token [1].Replace('.', ',')) > maxX){
                    maxX = float.Parse (token [1].Replace('.', ','));
                    maxXline = x;
                }
				obj.v.Add (new Vector3 (
					float.Parse (token [1].Replace('.', ',')),
					float.Parse (token [2].Replace('.', ',')),
					float.Parse (token [3].Replace('.', ','))));
				break;
			case ("vn"):
				obj.vn.Add (new Vector3 (
					float.Parse (token [1].Replace('.', ',')),
					float.Parse (token [2].Replace('.', ',')),
					float.Parse (token [3].Replace('.', ','))));
				break;
			case ("vt"):
				obj.vt.Add (new Vector3 (
					float.Parse (token [1].Replace('.', ',')),
					float.Parse (token [2].Replace('.', ','))));
				break;
			case ("f"):
                int z = 1;
                
                while(z < token.Length - 2){
    				int[] triplet = Array.ConvertAll (token [1].Split ('/'), x => {
    					if (String.IsNullOrEmpty (x))
    						return 0;
    					return int.Parse (x);
    				});
    				obj.f [obj.f.Count - 1].Add (triplet);
                    z += 1;
                    triplet = Array.ConvertAll (token [z].Split ('/'), x => {
    					if (String.IsNullOrEmpty (x))
    						return 0;
    					return int.Parse (x);
    				});
    				obj.f [obj.f.Count - 1].Add (triplet);
                    
                    triplet = Array.ConvertAll (token [z + 1].Split ('/'), x => {
    					if (String.IsNullOrEmpty (x))
    						return 0;
    					return int.Parse (x);
    				});
    				obj.f [obj.f.Count - 1].Add (triplet);
                }
                
				break;
			}
            x += 1;
		}
        Debug.Log("ligne : " + maxXline + "  value : " + maxX);
        List<int[]> triplets = new List<int[]> ();
  		List<int> submeshes = new List<int> ();
  
  		for (int i = 0; i < obj.f.Count; i += 1) {
  			for (int j = 0; j < obj.f [i].Count; j += 1) {
  				triplets.Add (obj.f [i] [j]);
  			}
  			submeshes.Add (obj.f [i].Count);
  		}
  
  		Vector3[] vertices = new Vector3[triplets.Count];
  		Vector3[] normals = new Vector3[triplets.Count];
  		Vector2[] uvs = new Vector2[triplets.Count];
  
  		for (int i = 0; i < triplets.Count; i += 1) {
  			vertices [i] = obj.v [triplets [i] [0] - 1];
  			normals [i] = obj.vn [triplets [i] [2] - 1];
  			if (triplets [i] [1] > 0)
  				uvs [i] = obj.vt [triplets [i] [1] - 1];
  		}
  
        Mesh mesh = new Mesh ();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        
  		mesh.name = obj.o;
  		mesh.vertices = vertices;
  		mesh.normals = normals;
  		mesh.uv = uvs;
  		mesh.subMeshCount = submeshes.Count;
  
  		int vertex = 0;
  		for (int i = 0; i < submeshes.Count; i += 1) {
  			int[] triangles = new int[submeshes [i]];
  			for (int j = 0; j < submeshes [i]; j += 1) {
  				triangles [j] = vertex;
  				vertex += 1;
  			}
  			mesh.SetTriangles (triangles, i);
  		}
  
  		mesh.RecalculateBounds ();
            
		return mesh;
	}
}