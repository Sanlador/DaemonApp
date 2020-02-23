using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
   public string search;
    public List<GameObject> optionList = new List<GameObject>();
    public InputField InputField;

    private GameObject selected;
    public void Start()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("OptionItem")){
        optionList.Add(obj);        
        }  
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
    }

}
