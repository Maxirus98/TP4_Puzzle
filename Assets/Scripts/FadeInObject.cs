using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class FadeInObject : MonoBehaviour
{
    [Header("Fade Settings")]
    [Tooltip("Delay before starting the fade-in (in seconds)")]
    public float delay = 1f;

    [Tooltip("Duration of the fade-in (in seconds)")]
    public float fadeDuration = 2f;

    private Material fadeMaterial;
    private Color startColor;
    private bool hasFaded = false;

    void OnEnable()
    {
        SetupMaterial();

        if (!hasFaded)
        {
            StartCoroutine(FadeIn());
        }
    }

    void SetupMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();

        // Make sure we're using an instance of the material, not the shared one
        fadeMaterial = renderer.material;

        // Ensure the shader supports transparency
        if (fadeMaterial.HasProperty("_Color"))
        {
            startColor = fadeMaterial.color;
            Color transparent = startColor;
            transparent.a = 0f;
            fadeMaterial.color = transparent;
        }
        else
        {
            Debug.LogWarning("Material on " + gameObject.name + " does not support color fading.");
        }
    }

    IEnumerator FadeIn()
    {
        hasFaded = true;

        yield return new WaitForSeconds(delay);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            float alpha = Mathf.SmoothStep(0f, 1f, t);

            Color newColor = startColor;
            newColor.a = alpha;
            fadeMaterial.color = newColor;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure final color is fully visible
        startColor.a = 1f;
        fadeMaterial.color = startColor;
    }
}

