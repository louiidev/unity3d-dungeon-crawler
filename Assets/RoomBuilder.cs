using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder : MonoBehaviour
{
    public GameObject[] tiles;
    GameState gameState;
    RoomController roomController;

    void Start() {
        gameState = FindObjectOfType<GameState>();
        roomController = new RoomController();
    }

    public void BuildRoom(List<string> roomCollection, Vector3 position) {
        for (int i = 0; i < roomCollection.Count; i++) {
            for (int j = 0; j < roomCollection[i].Length; j++) {
                int tileIndex = roomCollection[i][j]; 
                GameObject tile = tiles[tileIndex];
                Instantiate(tile, position + new Vector3(i, j), Quaternion.identity);
            }
        }
    }
    
    void PopulateRoom() {
        
    }
}
