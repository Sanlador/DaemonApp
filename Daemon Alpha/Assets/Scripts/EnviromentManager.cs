using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviromentManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public Dictionary<string, InfoSheet> activeSheets;
    public GameObject selector, content, pile, buttonUp, buttonDown, markerLeft, markerRight, pileCounter, numerator, denominator;
    public List<GameObject> activePiles;

    int pileCount, pileIndex;
    GameObject newPile, pileLeft, pileRight;

    public void addPile()
    {
        pileCount++;
        if (pileCount % 2 == 1)
        {
            print(pileCount);
            print(pileCount);
            if (pileCount > 2)
            {
                pileLeft.SetActive(false);
                pileRight.SetActive(false);
                buttonUp.SetActive(true);
                pileCounter.SetActive(true);
            }
            newPile = Instantiate(pile);
            newPile.transform.SetParent(gameObject.transform);
            newPile.GetComponent<RectTransform>().localPosition = markerLeft.GetComponent<RectTransform>().localPosition;
            pileLeft = newPile;
            pileIndex = pileCount / 2;
            buttonDown.SetActive(false);
        }
        else
        {
            newPile = Instantiate(pile);

            newPile.transform.SetParent(gameObject.transform);
            newPile.GetComponent<RectTransform>().localPosition = markerRight.GetComponent<RectTransform>().localPosition;
            pileRight = newPile;
        }
        activePiles.Add(newPile);

        newPile.GetComponent<AddSheet>().content = content;
        newPile.GetComponent<AddSheet>().selector = selector;

        numerator.GetComponent<Text>().text = (pileIndex + 1).ToString();
        denominator.GetComponent<Text>().text = (pileCount / 2 + 1).ToString();
    }

    public void moveDown()
    {
        pileIndex++;

        pileLeft.SetActive(false);
        pileRight.SetActive(false);
        pileLeft = activePiles[pileIndex * 2];
        pileLeft.SetActive(true);
        if (activePiles.Count > (pileIndex * 2 + 2))
        {
            pileLeft = activePiles[pileIndex * 2 + 1];
            pileLeft.SetActive(true);
        }

        if (pileCount < ((pileIndex + 1) * 2) + 1)
        {
            buttonDown.SetActive(false);
        }
        buttonUp.SetActive(true);

        numerator.GetComponent<Text>().text = (pileIndex + 1).ToString();
        denominator.GetComponent<Text>().text = (pileCount / 2 + 1).ToString();
    }

    public void moveUp()
    {
        pileIndex--;
        print(pileIndex);
        pileLeft.SetActive(false);
        pileRight.SetActive(false);
        pileLeft = activePiles[pileIndex * 2];
        pileLeft.SetActive(true);
        pileLeft = activePiles[pileIndex * 2 + 1];
        pileLeft.SetActive(true);

        buttonDown.SetActive(true);
        if (0 == pileIndex)
        {
            buttonUp.SetActive(false);
        }
        buttonDown.SetActive(true);

        numerator.GetComponent<Text>().text = (pileIndex + 1).ToString();
        denominator.GetComponent<Text>().text = (pileCount / 2 + 1).ToString();
    }

    public Dictionary<string, InfoSheet> getActiveSheets()
    {
        Dictionary<string, InfoSheet> sheets = new Dictionary<string, InfoSheet>();

        foreach (GameObject pile in activePiles)
        {
            int i = 0;
            foreach (InfoSheet sheet in pile.GetComponent<SheetPile>().getSheets())
            {
                sheets.Add(sheet.getInstance(), sheet);
            }
        }

        return sheets;
    }

    void Start()
    {
        pileCount = 0;
        pileIndex = 0;
        activePiles = new List<GameObject>();
        buttonDown.SetActive(false);
        buttonUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //getActiveSheets();
    }
}
