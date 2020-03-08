using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetPile : MonoBehaviour
{
    public GameObject environment;
    List<GameObject> sheets;
    int sheetCount = 0;
    public GameObject topSheet, middleSheet, bottomSheet, sheetCounter, numerator, denominator, remove;
    GameObject instanceList;

    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        sheets = new List<GameObject>();
        sheetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveForward()
    {
        if (index > -1)
            sheets[index].SetActive(false);
        index++;
        if (index == sheetCount)
            index = 0;
        sheets[index].SetActive(true);
        print(index);
        numerator.GetComponent<Text>().text = (index + 1).ToString();
    }

    public void moveBackward()
    {
        sheets[index].SetActive(false);
        index--;
        if (-1 == index)
            index = sheetCount - 1;
        sheets[index].SetActive(true);
        numerator.GetComponent<Text>().text = (index + 1).ToString();
    }

    public void setInstanceList(GameObject list)
    {
        instanceList = list;
    }

    public void addSheet(GameObject sheet)
    {
        sheets.Add(sheet);
        sheetCount++;
        moveForward();
        sheet.GetComponent<RectTransform>().localPosition = gameObject.GetComponent<RectTransform>().localPosition;

        if (1 == sheetCount)
        {
            topSheet.SetActive(true);
            middleSheet.SetActive(false);
            bottomSheet.SetActive(false);
            remove.SetActive(true);
        }
        if (2 == sheetCount)
        {
            topSheet.SetActive(true);
            middleSheet.SetActive(true);
            bottomSheet.SetActive(false);
        }
        if (3 == sheetCount)
        {
            topSheet.SetActive(true);
            middleSheet.SetActive(true);
            bottomSheet.SetActive(true);
        }


        if (sheetCount > 1)
        {
            sheetCounter.SetActive(true);
        }

        numerator.GetComponent<Text>().text = (index + 1).ToString();
        denominator.GetComponent<Text>().text = (sheetCount).ToString();
    }

    public void removeSheet()
    {
        if (sheetCount > 0)
        {
            //sheets[0] = null;
            sheets[index].SetActive(false);
            //sheets.RemoveAt(index);
            sheetCount--;
            moveBackward();
            numerator.GetComponent<Text>().text = (index + 1).ToString();
            denominator.GetComponent<Text>().text = (sheetCount).ToString();
        }

        if (1 == sheetCount)
        {
            topSheet.SetActive(true);
            middleSheet.SetActive(false);
            bottomSheet.SetActive(false);
        }
        if (2 == sheetCount)
        {
            topSheet.SetActive(true);
            middleSheet.SetActive(true);
            bottomSheet.SetActive(false);
        }

        if (sheetCount == 0)
        {

            sheetCounter.SetActive(false);
            remove.SetActive(false);
        }
    }


    public void removePile()
    {
        foreach (GameObject sheet in sheets)
        {
            sheet.SetActive(false);
            Destroy(gameObject);
        }
    }

    public int getSheetCount()
    {
        return sheetCount;
    }

    public GameObject getTopSheet()
    {
        return sheets[index];
    }

    public List<InfoSheet> getSheets()
    {
        List<InfoSheet> sheetList = new List<InfoSheet>();
        foreach (GameObject sheet in sheets)
        {
            sheetList.Add(sheet.GetComponent<SheetLoader>().getSheet());
        }
        return sheetList;
    }
}
