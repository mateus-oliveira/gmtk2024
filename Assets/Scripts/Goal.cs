using UnityEngine;

public class CircleController : MonoBehaviour
{
    private float[] scales = { 1f, 1.5f, 2f };
    private string[] colors = { "Red", "Yellow", "Blue" };
    private int currentScaleIndex = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip pointSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResizeCircle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseRadius();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseRadius();
        }
    }

    private void IncreaseRadius()
    {
        if (currentScaleIndex < scales.Length - 1)
        {
            currentScaleIndex++;
            ResizeCircle();
        }
    }

    private void DecreaseRadius()
    {
        if (currentScaleIndex > 0)
        {
            currentScaleIndex--;
            ResizeCircle();
        }
    }

    private void ResizeCircle()
    {
        // Update the scale
        transform.localScale = Vector3.one * scales[currentScaleIndex];

        /*/ Update the color based on scale
        switch (currentScaleIndex)
        {
            case 0:
                spriteRenderer.color = Color.red; // Small (Red)
                break;
            case 1:
                spriteRenderer.color = Color.yellow; // Medium (Yellow)
                break;
            case 2:
                spriteRenderer.color = Color.blue; // Large (Blue)
                break;
        }*/
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(colors[currentScaleIndex])) {
            Destroy(other.gameObject);
            Score.Instance.AddPoints(1);
            AudioManager.instance.PlayAudio(pointSound);
        } else {
            Life.Instance.DecreaseLife();
        }
    }
}
