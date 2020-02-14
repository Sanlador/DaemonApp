using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUITarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    float height, width;
    bool inZone;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inZone = false;
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

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
        inZone = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        inZone = false;
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
