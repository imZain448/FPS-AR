using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] TilePrefabs;

    private Transform PlayerTransform;
    private float PositionZ;
    private float tileLenght;
    private int NumberOfTiles = 10;
    private float thresholdRegion = 60f;

    private int PrefabIndex;

    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        PrefabIndex = 0;
        tileLenght = TilePrefabs[0].GetComponentInChildren<Renderer>().bounds.size.z;
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        PositionZ = tileLenght;
        SpawnTile(0);
        for (int i = 0; i <= 9; i++)
        {
            SpawnTile(RandomIndex());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.z - thresholdRegion > PositionZ - NumberOfTiles * tileLenght)
        {
            SpawnTile(RandomIndex());
            DeleteTiles();
        }
    }

    [HideInInspector]
    public void SpawnTile(int index, int prefabIndex = -1)
    {
        GameObject platform;
        platform = Instantiate(TilePrefabs[index]) as GameObject;
        platform.transform.SetParent(transform);
        platform.transform.position = new Vector3(0 , -1.32f , PositionZ);
        PositionZ += tileLenght;
        activeTiles.Add(platform);
    }

    void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomIndex()
    {
        if (TilePrefabs.Length == 1)
            return 0;
        int randomIndex = PrefabIndex;
        while (randomIndex == PrefabIndex)
        {
            randomIndex = Random.Range(0, TilePrefabs.Length);
        }
        PrefabIndex = randomIndex;
        return randomIndex;
    }
}
