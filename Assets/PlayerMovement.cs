using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerMovement : MonoBehaviour {
  bool stickDown = false;
  TilemapManager tilemapManager;
  GameState gameState;

  void Start() {
    tilemapManager = FindObjectOfType<TilemapManager>();
    gameState = FindObjectOfType<GameState>();
  }

  void Update() {
    Vector3 input = GetInput();
    Move(input);
    setStickDown(input);
  }

  void Move(Vector3 input) {
    if (input != Vector3.zero && !stickDown && tilemapManager.isTileAtPosition(transform.position + input)) {
      transform.position+= input;
      gameState.PlayerMoved();
    }
  }

  void setStickDown(Vector3 input) {
    stickDown = input != Vector3.zero;
  }

  Vector3 GetInput() {
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
    if (x != 0) {
      return new Vector3(x, 0);
    }
    if (y != 0) {
      return new Vector3(0, y);
    }
    return Vector3.zero;
  }
}
