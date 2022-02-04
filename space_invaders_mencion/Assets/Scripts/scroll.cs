using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour
{
    [SerializeField]
    RawImage scrollableImage;

    [SerializeField]
    float scrollSpeed;

    [SerializeField]
    Vector2 scrollDirection;

    Rect rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = scrollableImage.uvRect;
    }

    // Update is called once per frame
    void Update()
    {
        rect.y+= scrollDirection.y * scrollSpeed * Time.deltaTime;
        scrollableImage.uvRect = rect;
    }
}
