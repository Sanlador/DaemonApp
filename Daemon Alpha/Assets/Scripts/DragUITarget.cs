using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUITarget : MonoBehaviour
{
    RectTransform rectTransform;
    float height, width;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        width = rectTransform.sizeDelta.x / 1.132f;
        height = rectTransform.sizeDelta.y / 1.132f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool pointerDrop()
    {

        bool inBox =
            (Input.mousePosition.x > (transform.position.x - width / 2) && Input.mousePosition.x < (transform.position.x + width / 2))
            && (Input.mousePosition.x > (transform.position.y - height / 2) && Input.mousePosition.y < (transform.position.x + height / 2));
        return (inBox);
    }
}
