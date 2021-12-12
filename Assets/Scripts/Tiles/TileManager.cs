using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap gameTilemap;
    
    [SerializeField] 
    private List<Transform> tilePrefabList;

    [SerializeField] 
    private int gridSize;

    void Start()
    {
        GenerateWorld();
    }

    Transform GetRandomTileType()
    {
        var randomIndex = UnityEngine.Random.Range(0f, tilePrefabList.Count);
        return tilePrefabList[(int) randomIndex];
    }
    
    // Negative coordinates are in use to ensure that the tilemap is centered with the camera
    void GenerateWorld()
    {
        for (var x = gridSize * -1; x < gridSize; x++)
        {
            for (var y = gridSize * -1; y < gridSize; y++)
            {
                Transform randomTileType = GetRandomTileType();
                
                Sprite tileSprite = randomTileType.GetComponent<SpriteRenderer>().sprite;
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = tileSprite;
                tile.gameObject = new GameObject($"{randomTileType.GetComponent<TilePrefabData>().TileType}: {x},{y}");
                gameTilemap.SetTile(new Vector3Int(x,y,0), tile);
            }
        }
        gameTilemap.RefreshAllTiles();
    }
}
