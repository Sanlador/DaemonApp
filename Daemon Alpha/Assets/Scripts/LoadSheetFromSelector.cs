using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSheetFromSelector : MonoBehaviour
{
    public GameObject sheet, templateName, parent;
    bool sheetLoaded = false;
    public void genSheetFromButton()
    {
        if (parent.GetComponent<DeleteSheet>().sheetPresent())
        {
            print("Test");
            parent.GetComponent<DeleteSheet>().removeSheet();
        }

        if (!sheet.activeSelf)
        {
            sheet.SetActive(true);
        }
        else
            sheet = Instantiate(sheet, parent.transform);
        parent.GetComponent<DeleteSheet>().setSheet(sheet);

        if (!sheetLoaded)
        {
            sheet.GetComponent<SheetLoader>().loadFromButton("Sheets\\" + templateName.GetComponent<Text>().text + ".st");
            sheetLoaded = true;
        }
    }
}
