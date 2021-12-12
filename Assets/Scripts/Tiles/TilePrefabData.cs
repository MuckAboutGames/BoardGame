using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Grass,
    Desert,
    Mountain,
    Town
}

public class TilePrefabData : MonoBehaviour
{
    [SerializeField]
    private TileType tileType;

    // This should not be settable from other scripts, so it's a read-only property
    public TileType TileType => tileType;
}
