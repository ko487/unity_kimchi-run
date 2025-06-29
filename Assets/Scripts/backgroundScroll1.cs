using UnityEngine;

public class backgroundScroll1 : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast shoud the  texture scroll?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   // i want 10 units per secen ||| 2 fps
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
