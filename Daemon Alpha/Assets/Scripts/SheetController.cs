using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SheetController : MonoBehaviour, IPointerClickHandler
{
    public GameObject text, staticNum, dynamicNum, thisObject;

    enum pointer {normal, Text, Static, Dynamic};
    pointer pointerMode = pointer.normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText()
    {
        pointerMode = pointer.Text;
        print("Switching mode to text");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pointerMode != pointer.normal)
        {
            if (pointer.Text == pointerMode)
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                GameObject newText = Instantiate(text, pos, Quaternion.identity, transform);
                DragHandler DH = newText.GetComponent<DragHandler>();
                DH.dropLocation = thisObject;
                pointerMode = pointer.normal;
            }
        }
    }
}
