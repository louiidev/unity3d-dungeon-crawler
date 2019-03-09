using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


class TilemapManager : MonoBehaviour {
  Tilemap tilemap;

  void Start() {
    tilemap = FindObjectOfType<Tilemap>();
  }

  public bool isTileAtPosition(Vector3 position) {
    Vector3Int tilePos = tilemap.WorldToCell(position);
    return tilemap.HasTile(tilePos);
  }
}
