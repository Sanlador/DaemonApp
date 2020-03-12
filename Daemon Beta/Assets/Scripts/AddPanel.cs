using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.EventSystems;


public class AddPanel : MonoBehaviour
{
   public GameObject APanel;
    public Text[] items;
public Text word;
    public GameObject layoutGroup;
     public GameObject Bpanel;
    public GameObject op_item;
 public Text description;


    public void OnPanel()
        {
        Debug.Log("Called");
            APanel.SetActive(true);
           
        }

      
   public void OnCancel(){
    APanel.SetActive(false);
    }
    
        public void OnClickFunc()
    {
        
         if(Bpanel.activeInHierarchy == false)
        {
            Bpanel.SetActive(true);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[0].text);
        
        GameObject.FindGameObjectWithTag("panel_text").GetComponent<Text>().text = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[0].text;
        GameObject.FindGameObjectWithTag("panel_description").GetComponent<Text>().text = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[1].text;

     
        
      
     
    }
    public void OnSubmit()
        {
        OpenPanel op = gameObject.GetComponent<OpenPanel>();

        using (StreamWriter file = new StreamWriter("panelData.txt",true))
          file.WriteLine("{0} $ {1}", word.text, description.text); 
        
        GameObject child = Instantiate(op_item);
        
        //ins.transform.parent = GameObject.Find("parent").transform;

    child.transform.SetParent(layoutGroup.transform,false);

                child.GetComponentsInChildren<Text>()[0].text = word.text;
                child.GetComponentsInChildren<Text>()[1].text = description.text;
         child.GetComponent<Button>().onClick.AddListener(() => OnClickFunc());



       foreach(var i in op.panelData)
            {
        Debug.Log(i.Key);
        }
APanel.SetActive(false);

        }

   
}
