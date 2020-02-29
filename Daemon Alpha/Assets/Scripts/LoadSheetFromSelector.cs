using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSheetFromSelector : MonoBehaviour
{
    public GameObject sheet, templateName, parent;
    bool sheetLoaded = false;
    bool sheetPile = false;

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
            if (sheetPile)
            {
                sheet.GetComponent<SheetLoader>().load(templateName.GetComponent<Text>().text);
            }
            else
            {
                sheet.GetComponent<SheetLoader>().loadFromButton("Sheets\\" + templateName.GetComponent<Text>().text + ".st");
            }
            sheetLoaded = true;
        }
    }

    public void isSheetPile()
    {
        sheetPile = true;
    }
}
