using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetPile : MonoBehaviour
{

    List<GameObject> sheets;
    int sheetCount = 0;
    public GameObject topSheet, middleSheet, bottomSheet;
    GameObject instanceList;

    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        sheets = new List<GameObject>();
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

    }

    public void moveBackward()
    {
        sheets[index].SetActive(false);
        index--;
        if (-1 == index)
            index = sheetCount - 1;
        sheets[index].SetActive(true);

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
    }

    public void removeSheet()
    {
        if (sheetCount > 0)
        {
            sheets.RemoveAt(index);
            sheetCount--;
            moveBackward();
        }
            
    }

}
