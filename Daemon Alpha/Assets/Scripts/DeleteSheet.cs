using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSheet : MonoBehaviour
{
    public GameObject sheet;
    bool sheetSet = false;

    public void removeSheet()
    {
        sheet.SetActive(false);
        sheetSet = false;
    }

    public void setSheet(GameObject s)
    {
        sheet = s;
        sheetSet = true;
    }

    public bool sheetPresent()
    {
        return sheetSet;
    }

    public void newPile()
    {
        sheet = null;
        sheetSet = false;
    }
}
