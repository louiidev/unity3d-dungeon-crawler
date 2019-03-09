using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    GameState gameState;
    int mapSize;
    Vector2Int currentPosition = Vector2Int.zero;
    List<Vector2Int> roomPositions = new List<Vector2Int>();
    public GameObject tile;

    void Start() {
        gameState = FindObjectOfType<GameState>();
        mapSize = Config.mapSize;
        SetupMap();
        Generate();
    }

    int getStartPosition() {
        return Random.Range(0, mapSize);
    }

    Vector2Int GetRandomDirection() {
        int randomIndex = Random.Range(0, 5);
        Vector2Int[] directions = { Vector2Int.right, Vector2Int.down, Vector2Int.left, Vector2Int.right, Vector2Int.left };
        return directions[randomIndex];
    }

    Vector2Int GetNextPosition() {
        int i = 0;
        Vector2Int nextPositon = GetRandomDirection() + currentPosition;
        while(nextPositon.x >= mapSize || nextPositon.x < 0 ||
              nextPositon.y > 0 || nextPositon.y <= (mapSize * -1) || 
              roomPositions.Contains(nextPositon)) {
                  i++;
            nextPositon = GetRandomDirection() + currentPosition;
            if (i > 1000) {
                Debug.Log("Error index too high");
                break;
            }
        }
        return nextPositon;
    }

    void SetupMap() {
        int startX = getStartPosition();
        currentPosition = new Vector2Int(startX, 0);
        roomPositions.Add(currentPosition);
        Instantiate(tile, (Vector2)currentPosition * mapSize, Quaternion.identity);
    }

    void Generate() {
        int i = 0;
        Debug.Log((mapSize * -1) -1);
        while(currentPosition.y != (mapSize * -1) + 1) {
            i++;
            currentPosition = GetNextPosition();
            roomPositions.Add(currentPosition);
            Debug.Log(currentPosition);
            Instantiate(tile, (Vector2)currentPosition * mapSize, Quaternion.identity);
            if (i > 1000) {
                Debug.Log("ERROR too high");
                break;
            }
        }
    }
}
