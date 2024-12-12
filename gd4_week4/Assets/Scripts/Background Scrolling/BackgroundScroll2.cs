using UnityEngine;

public class BackgroundScroll2 : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
