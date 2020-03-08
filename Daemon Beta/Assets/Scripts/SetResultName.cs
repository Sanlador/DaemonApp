using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResultName : MonoBehaviour
{
    public GameObject title;

    public void setName(string name)
    {
        title.GetComponent<Text>().text = name;
    }
}
