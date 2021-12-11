using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInputController : MonoBehaviour
{
    private Grid grid;
    private Tilemap tilemap;

    private void Start()
    {
        grid = gameObject.GetComponentInParent<Grid>();
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Get position of the mouseclick
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //Convert position of the mouseclick to the position of the tile located at the mouseclick
            Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
            
            Tile clickedTile = tilemap.GetTile<Tile>(coordinate);
            Debug.Log(clickedTile.gameObject.name);
        }
    }
}
