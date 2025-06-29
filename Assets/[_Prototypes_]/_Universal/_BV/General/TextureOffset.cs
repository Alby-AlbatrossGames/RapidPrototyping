using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TextureOffset : MonoBehaviour
{
    public float scrollX = 0.5f;
    public float scrollY = 0.5f;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Renderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        renderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
