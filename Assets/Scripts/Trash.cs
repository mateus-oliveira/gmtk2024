using UnityEngine;

public class Trash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
