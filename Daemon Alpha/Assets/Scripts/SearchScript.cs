using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class SearchScript : MonoBehaviour
{
   public string search;
    public OpenPanel op;
    public List<GameObject> optionList = new List<GameObject>();
    public InputField InputField;
    public GameObject layoutGroup;
     public GameObject op_item;
    private GameObject selected;
      public GameObject Bpanel;
  
    public void Start()
    {
        string line;
        using (StreamReader reader = new StreamReader("panelData.txt"))
            {

            while ((line = reader.ReadLine()) != null)
        {
                
            // op_item = GameObject.Find("OptionItem");
        GameObject child = Instantiate(op_item);
        //ins.transform.parent = GameObject.Find("parent").transform;
        //var title = line.Split('$').First();
        string[] parts = line.Split(new char[] { '$' }, 2);
                Debug.Log(parts[1]);

         child.transform.SetParent(layoutGroup.transform,false);
                child.GetComponentsInChildren<Text>()[0].text = parts[0];
                child.GetComponentsInChildren<Text>()[1].text = parts[1];
                child.GetComponent<Button>().onClick.AddListener(() => OnClickFunc());

            }
            
        }


        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("OptionItem")){
        optionList.Add(obj);        
        }  
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
      void OnGUI(){
      if(InputField.isFocused && InputField.text != "" && Input.GetKey(KeyCode.Return)) {
       search = InputField.GetComponent<InputField>().text.ToLower();
         
         foreach (GameObject obj in optionList){
              
            if(obj.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text.ToLower().Contains(search)){
                selected = obj;
                     selected.SetActive(true);
                     Debug.Log(selected.name);
                    Debug.Log("Found");
                     }
            else{
                    obj.SetActive(false);
                    Debug.Log("Not Found");}
            }
     }

      if(InputField.text =="" && Input.GetKey(KeyCode.Return) )
            {
        foreach (GameObject obj in optionList){
                obj.SetActive(true);
                }
        }
      
        }
    }


