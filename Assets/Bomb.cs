using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bomb : MonoBehaviour {

  int timeToBlow = 4;
  int travelDistance = 2;
  GameState gameState;
  Vector2[] directions = new Vector2[] { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

  void Start() {
    gameState = FindObjectOfType<GameState>();
    gameState.turnChange+= PlayerMoved;
  }

  void PlayerMoved() {
    timeToBlow--;
    if (timeToBlow == 0) {
      Blow();
    }
  }

  void Blow() {
    foreach(Vector2 direction in directions) {
      
      RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, travelDistance);
      Debug.DrawRay(transform.position + Config.offset, direction * travelDistance, Color.red, 1);
      if (hit) {
        
      }
    }
    Destroy(gameObject);
  }
}
