using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPile : MonoBehaviour
{
    public GameObject instanceList, pile, marker1, marker2;
    int pileCount = 0;

    public void newPile()
    {
        pileCount++;
        GameObject newPile = Instantiate(pile);
        if ((pileCount % 2) == 1)
        {
            newPile.GetComponent<RectTransform>().localPosition = marker1.GetComponent<RectTransform>().localPosition;
        }
        else
        {
            newPile.GetComponent<RectTransform>().localPosition = marker2.GetComponent<RectTransform>().localPosition;
        }
        instanceList.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
