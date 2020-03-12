using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 offset, startPos;
    private bool start = true;
    private DragUITarget target;

    public GameObject dropLocation;

    //public GameObject dragEntity;

    // Start is called before the first frame update
    void Start()
    {
        target = dropLocation.GetComponent<DragUITarget>();

    }

    // Update is called once per frame
    void Update()
    {
        offset = Input.mousePosition - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (start)
            startPos = transform.position;
        start = false;
        transform.position = Input.mousePosition - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (target.pointerDrop())
        {
            Debug.Log("Placing over applicable UI element");
            GetComponent<FieldManager>().changeCoords();
        }
        else
        {
            transform.position = startPos;
            Debug.Log("Returning to initial position");
        }
        start = true;
    }
}
