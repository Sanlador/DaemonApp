using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SheetController : MonoBehaviour, IPointerClickHandler
{
    public GameObject sheetName, text, staticNum, dynamicNum, thisObject, label, instanceName;

    enum pointer { normal, Text, Label, Static, Dynamic };
    pointer pointerMode = pointer.normal;
    private bool nameSet;
    private string n;
    private InfoSheet sheet;

    // Start is called before the first frame update
    void Start()
    {
        nameSet = false;
        sheet = new InfoSheet("");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void saveSheet(bool instance = false)
    {
        if (instance)
        {
            sheet = gameObject.GetComponent<SheetLoader>().getSheet();
            sheet.setInstance(instanceName.GetComponent<Text>().text);
            Debug.Log("Attempting save");
            SheetFileManager.saveSheetToFile(sheet, true);
        }
        else
        {
            n = sheetName.GetComponent<Text>().text;
            if (n != "")
            {
                if (!nameSet)
                {
                    sheet.setName(n);
                }
                else if (n != sheetName.GetComponent<Text>().text)
                {
                    sheet.setName(n);
                }
                Debug.Log("Attempting save");
                SheetFileManager.saveSheetToFile(sheet);
            }

        }
    }

    public void setText()
    {
        pointerMode = pointer.Text;
        //print("Switching mode to text");
    }

    public void setLabel()
    {
        pointerMode = pointer.Label;
        //print("Switching mode to Label");
    }

    public void setStatic()
    {
        pointerMode = pointer.Static;
        //print("Switching mode to static");
    }

    public void setDynamic()
    {
        pointerMode = pointer.Dynamic;
        //print("Switching mode to dynamic");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pointerMode != pointer.normal)
        {
            if (pointer.normal != pointerMode)
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                GameObject newField;
                if (pointer.Text == pointerMode)
                {
                    //Debug.Log(pos);
                    newField = Instantiate(text, pos, Quaternion.identity, transform);
                    newField.GetComponent<FieldManager>().initialize(sheet, "text");
                }
                else if (pointer.Label == pointerMode)
                {
                    newField = Instantiate(label, pos, Quaternion.identity, transform);
                    newField.GetComponent<FieldManager>().initialize(sheet, "label");
                }
                else if (pointer.Static == pointerMode)
                {
                    newField = Instantiate(staticNum, pos, Quaternion.identity, transform);
                    newField.GetComponent<FieldManager>().initialize(sheet, "static");
                }
                else
                {
                    newField = Instantiate(dynamicNum, pos, Quaternion.identity, transform);
                    newField.GetComponent<FieldManager>().initialize(sheet, "dynamic");
                }

                DragHandler DH = newField.GetComponent<DragHandler>();
                DH.dropLocation = thisObject;
                pointerMode = pointer.normal;
            }
        }
    }

    public InfoSheet getSheet()
    {
        return sheet;
    }
}
