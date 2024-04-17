using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlyout : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade out effect in seconds

    private Color originalColor;
    private float fadeTimer;
    private bool fading = false;
    public bool flipped;
    public float speed = 1f;
    public float speedDecay = .25f;
    MeshRenderer mr;
    TextMeshPro tmpro;
    RectTransform rTransform;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rTransform = GetComponent<RectTransform>();
        tmpro = GetComponent<TextMeshPro>();
        originalColor = tmpro.color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!flipped && speed <= 0) || (flipped && speed >= 0))
        {
            fading = true;
        }
        else
        {
            rTransform.position = new Vector2(rTransform.position.x, rTransform.position.y + speed * Time.deltaTime);
            speed -= speedDecay * Time.deltaTime;
        }

        if (fading)
        {
            fadeTimer += Time.deltaTime;
            float fadeAmount = Mathf.Clamp01(fadeTimer / fadeDuration);
            Color newColor = originalColor;
            newColor.a = 1.0f - fadeAmount;
            tmpro.color = newColor;

            if (fadeAmount >= 1.0f)
            {
                Destroy(this.gameObject); // Make the object inactive when fade out is complete
            }
        }
    }
}
