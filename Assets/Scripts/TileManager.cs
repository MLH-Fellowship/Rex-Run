using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float safeZone = 20f;
    private float tileLength = 30f;
    private int amnTilesOnScreen = 4;
    private List<GameObject> activeTiles;
    private int lastPrefabIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < amnTilesOnScreen; i++) {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    //Create new Tiles
    private void SpawnTile(int prefabIndex = -1) 
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    // Delete Tiles
    private void DeleteTile() 
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    // Randomly generate index of the next tile
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
