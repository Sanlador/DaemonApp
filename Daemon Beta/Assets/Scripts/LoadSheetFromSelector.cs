using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSheetFromSelector : MonoBehaviour
{
    public GameObject sheet, templateName, parent, pile, selector, console;
    bool sheetLoaded = false;
    bool sheetPile = false;

    public void genSheetFromButton()
    {
        if (parent.GetComponent<DeleteSheet>().sheetPresent())
        {
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
                sheet.GetComponent<SheetLoader>().load(templateName.GetComponent<Text>().text, console);
                pile.GetComponent<SheetPile>().addSheet(sheet);
                sheet.GetComponent<setName>().set(sheet.GetComponent<SheetLoader>().sheet.getInstance());
                selector.transform.SetAsLastSibling();
                sheet.transform.SetParent(pile.transform);
            }
            else
            {
                sheet.GetComponent<SheetLoader>().loadFromButton("Sheets\\" + templateName.GetComponent<Text>().text + ".st");
            }
            sheetLoaded = true;
        }
    }
    public void isSheetPile(GameObject p)
    {
        pile = p;
        sheetPile = true;
    }
    public void setNewPile(GameObject p)
    {
        pile = p;
        if (pile.GetComponent<SheetPile>().getSheetCount() == 0)
        {
            parent.GetComponent<DeleteSheet>().newPile();
        }
        else
        {
            parent.GetComponent<DeleteSheet>().setSheet(pile.GetComponent<SheetPile>().getTopSheet());
        }
    }
}
