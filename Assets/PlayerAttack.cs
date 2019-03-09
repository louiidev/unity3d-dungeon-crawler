using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bomb;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }
}
