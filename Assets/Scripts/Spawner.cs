using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minSpawnInterval = 0.8f;
    [SerializeField] private float spawnAcceleration = 0.05f;

    private float currentSpawnInterval;

    private void Start()
    {
        Score.Instance.ResetPoints();
        currentSpawnInterval = initialSpawnInterval;
        Invoke("SpawnObject", currentSpawnInterval);
    }

    private void SpawnObject() {
        int randomIndex = Random.Range(0, 3);

        GameObject prefab = prefabs[randomIndex];
        GameObject spawnedObject = Instantiate(prefab, transform.position, Quaternion.identity);

        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();
        MovementController movementController = spawnedObject.AddComponent<MovementController>();

        switch (randomIndex)
        {
            case 0:
                // Red - Small
                spriteRenderer.color = Color.red;
                spawnedObject.transform.localScale = Vector3.one;
                movementController.SetSpeed(7f); // Red - Fastest
                break;
            case 1:
                // Yellow - Medium
                spriteRenderer.color = Color.yellow;
                spawnedObject.transform.localScale = Vector3.one * 1.5f;
                movementController.SetSpeed(6f); // Yellow - Medium speed
                break;
            case 2:
                // Blue - Large
                spriteRenderer.color = Color.blue;
                spawnedObject.transform.localScale = Vector3.one * 2f;
                movementController.SetSpeed(5f); // Blue - Slowest
                break;
        }

        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnAcceleration);

        Invoke("SpawnObject", currentSpawnInterval);
    }
}

public class MovementController : MonoBehaviour
{
    private float speed;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}
