using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade out effect in seconds
    public float scrollSpeed = 6.0f; //Units travled per second


    private Renderer rend;
    private Color originalColor;
    private float fadeTimer;
    private bool fading = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        fadeTimer = 0.0f;
    }

    void Update()
    {
        float distToMove = scrollSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * distToMove, Space.World);
        if (fading)
        {
            fadeTimer += Time.deltaTime;
            float fadeAmount = Mathf.Clamp01(fadeTimer / fadeDuration);
            Color newColor = originalColor;
            newColor.a = 1.0f - fadeAmount;
            rend.material.color = newColor;

            if (fadeAmount >= 1.0f)
            {
                Destroy(this.gameObject); // Make the object inactive when fade out is complete
            }
        }
    }

    public void MissNote()
    {
        fading = true;
        fadeTimer = 0.0f;
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }
}