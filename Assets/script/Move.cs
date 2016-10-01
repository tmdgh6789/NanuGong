using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public void moveDown() {
        transform.Translate(Vector2.down * 0.55f * Time.deltaTime);
    }
}
