using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSheetFromSelector : MonoBehaviour
{
    public GameObject sheet, templateName, parent;

    public void genSheetFromButton()
    {
        sheet = Instantiate(sheet, parent.transform);
        sheet.GetComponent<SheetLoader>().loadFromButton("Sheets\\" + templateName.GetComponent<Text>().text + ".st");
    }
}
