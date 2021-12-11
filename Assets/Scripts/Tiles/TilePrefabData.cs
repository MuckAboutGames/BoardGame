using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePrefabData : MonoBehaviour
{
    public enum TileTypes
    {
        Grass,
        Desert,
        Mountain,
        Town
    }

    public TileTypes TileType;
}
