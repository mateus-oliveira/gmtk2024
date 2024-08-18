using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private int spawnInterval;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // Randomize color and size
        int randomIndex = Random.Range(0, 3);

        GameObject prefab = prefabs[randomIndex];
        GameObject spawnedObject = Instantiate(prefab, transform.position, Quaternion.identity);

        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();

        switch (randomIndex)
        {
            case 0:
                // Red - Small
                spriteRenderer.color = Color.red;
                spawnedObject.transform.localScale = Vector3.one;
                break;
            case 1:
                // Yellow - Medium
                spriteRenderer.color = Color.yellow;
                spawnedObject.transform.localScale = Vector3.one * 1.5f;
                break;
            case 2:
                // Blue - Large
                spriteRenderer.color = Color.blue;
                spawnedObject.transform.localScale = Vector3.one * 2f;
                break;
        }
    }
}
