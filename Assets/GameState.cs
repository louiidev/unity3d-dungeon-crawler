using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void TurnChange();
    public event TurnChange turnChange;

    public void PlayerMoved() {
        if (turnChange != null) {
            turnChange();
        }
    }
}
