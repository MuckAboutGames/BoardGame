using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    private Tilemap tilemap;
    
    [SerializeField] 
    private List<Transform> tilePrefabList;

    [SerializeField] 
    private int gridSize;
    
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    
    void Start()
    {
        GenerateWorld();
    }

    Transform GetRandomTileType()
    {
        var randomIndex = UnityEngine.Random.Range(0f, tilePrefabList.Count);
        return tilePrefabList[(int) randomIndex];
    }

    void GenerateWorld()
    {
        for (var x = gridSize * -1; x < gridSize; x++)
        {
            for (var y = gridSize * -1; y < gridSize; y++)
            {
                Sprite tileSprite = GetRandomTileType().GetComponent<SpriteRenderer>().sprite;
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = tileSprite;
                tilemap.SetTile(new Vector3Int(x,y,0), tile);
                tilemap.RefreshAllTiles();
            }
        }
        
    }
}
