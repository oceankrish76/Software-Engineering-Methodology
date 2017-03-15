using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(MeshGenerator))]
public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed;

	[Range(0,100)]
	public int randomFillPercent;

	public int[,] map;

	void Start() {
		GenerateMap();
	}

	void Update() {
		UpdateMap ();
		/*if (Input.GetMouseButtonDown(0)) {
			UpdateMap ();
		}*/
	}

	void GenerateMap() {
		map = new int[width,height];
		RandomFillMap();

		ClearMapColliders ();

		for (int i = 0; i < 4; i ++) {
			SmoothMap();
		}

		int borderSize = 1;
		int[,] borderedMap = new int[width + borderSize * 2,height];

		for (int x = 0; x < borderedMap.GetLength(0); x ++) {
			for (int y = 0; y < borderedMap.GetLength(1); y ++) {
				if (x >= borderSize && x < width + borderSize) {
					borderedMap[x,y] = map[x-borderSize,y];
				}
				else {
					borderedMap[x,y] =1;
				}
			}
		}

		MeshGenerator meshGen = GetComponent<MeshGenerator>();
		meshGen.GenerateMesh(borderedMap, 1);

		AddColliders ();

	}


	void RandomFillMap() {
		if (useRandomSeed) {
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (x == 0 || x == width-1) {
					map[x,y] = 1;
				}
				else if (x > width / 10f && x < width - width / 10f && y > height - height / 20f) {
					map[x,y] = 0;
				}				
				else {
					map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent)? 1: 0;
				}
			}
		}
	}

	void SmoothMap() {
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				int neighbourWallTiles = GetSurroundingWallCount(x,y);

				if (neighbourWallTiles > 6)
					map[x,y] = 1;
				else if (neighbourWallTiles < 4)
					map[x,y] = 0;

			}
		}
	}
	void SmoothUpdatedMap() {
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				int neighbourWallTiles = GetSurroundingWallCount(x,y);

				if (neighbourWallTiles > 6)
					map[x,y] = 1;
				else if (neighbourWallTiles < 2)
					map[x,y] = 0;

			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
					if (neighbourX != gridX || neighbourY != gridY) {
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else {
					wallCount ++;
				}
			}
		}
		return wallCount;
	}

	bool InnerFieldCheck(int gridX, int gridY) {
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX = neighbourX + 2) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY = neighbourY + 2) {
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
					//if (neighbourX != gridX || neighbourY != gridY) {
						if (map [neighbourX, neighbourY] == 1)
							return true;
						else
							continue;
					//}
				}
			}
		}
		return false;
	}


	public void AddColliders (){
		for (int x = 0; x < map.GetLength (0); x++) {
			for (int y = 0; y < map.GetLength (1); y++) {
				if (map[x,y] == 1) {
					if (InnerFieldCheck(x, y)) {
						BoxCollider boxCollider = gameObject.AddComponent<BoxCollider> ();
						boxCollider.center = new Vector3 (x - width / 2, -1f, y - height / 2);
						boxCollider.size = Vector3.one;
						boxCollider.isTrigger = true;
					}
				}
			}
		}
	}

	public void ClearMapColliders () {
		BoxCollider[] AllColliders = gameObject.GetComponentsInChildren< BoxCollider >();
		foreach (BoxCollider _collider in AllColliders) {
			Destroy (_collider);
		}

		Debug.Log ("Cleared");
	}

	void UpdateMap() {
		ScrollMap (ref map);

		ClearMapColliders ();

		for (int i = 0; i < 4; i++) {
			SmoothUpdatedMap ();
		}

		int borderSize = 1;
		int[,] borderedMap = new int[width + borderSize * 2,height];

		for (int x = 0; x < borderedMap.GetLength(0); x ++) {
			for (int y = 0; y < borderedMap.GetLength(1); y ++) {
				if (x >= borderSize && x < width + borderSize) {
					borderedMap[x,y] = map[x-borderSize,y];
				}
				else {
					borderedMap[x,y] = 1;
				}
			}
		}

		MeshGenerator meshGen = GetComponent<MeshGenerator>();
		meshGen.GenerateMesh(borderedMap, 1);

		AddColliders ();
	}

	void ScrollMap (ref int[,] map) {
		for (int y = 1; y < height; y++) {
			for (int x = 0; x < width; x++) {
				//Shift map
				map [x, y - 1] = map [x, y];
				if (y == height - 1) {
					if (x == 0 || x == width - 1) {
						map [x, y] = 1;
					} else {
						//int lfsr = (((((map [x, height / 2] + map [x, height / 2 - 1]) % 2) + map [x, height / 2 + 1]) % 2) + map [x, height / 2 - 2]) % 2;
						int lfsr = (map[x,0] + map[x,1]) % 2;
						map [x, y] = lfsr;
					}
				}
			}
		}
	}
}