using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListActiveSheets : MonoBehaviour
{
    public GameObject environment, resultObject, turnOrder;
    int count = 0;
    List<GameObject> results = new List<GameObject>();

    public void listSheets()
    {
        GameObject result;
        Dictionary<string, InfoSheet> activeSheets = environment.GetComponent<EnviromentManager>().getActiveSheets();
        foreach (KeyValuePair<string, InfoSheet> tuple in activeSheets)
        {
            print("Test");
            result = Instantiate(resultObject, transform.position, Quaternion.identity);
            results.Add(result);
            count = environment.GetComponent<EnviromentManager>().getActiveSheets().Count;
            result.transform.SetParent(gameObject.transform);
            result.GetComponent<SheetResult>().text.GetComponent<Text>().text = tuple.Key;
            result.GetComponent<SheetResult>().sheet = tuple.Value;
            result.GetComponent<SheetResult>().environment = environment;
            result.GetComponent<SheetResult>().turnOrder = turnOrder;

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (environment.GetComponent<EnviromentManager>().getActiveSheets().Count > count)
        {
            foreach (GameObject r in results)
                Destroy(r);
            results.Clear();
            listSheets();
        }
    }
}
