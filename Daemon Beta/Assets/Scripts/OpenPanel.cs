using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;

public class OpenPanel : MonoBehaviour
    {
  public GameObject[] buttonList;
  public GameObject Bpanel;
public Dictionary<string,string> panelData = new Dictionary<string, string>(){{"Gregarpor","Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium"},{"Werradith","Sample Text-1 Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium"},{"Kepplier","Sample Text-2 Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt"},
    {"Flunge","Lorem ipsum dolor sit amet Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt"},{"Happliest","Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium"},{"Eggmode","ipsum dolor sit amet Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt"},{"Fliondeso","lorem ipsum"},{"Geosyog","Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt"}};


  

    public void Start()
    {  Debug.Log("size"+new FileInfo("panelData.txt").Length);
      /*  if(new FileInfo("panelData.txt")==0)
            {
            using (StreamWriter file = new StreamWriter("panelData.txt"))
          
    foreach (var entry in panelData){
        file.WriteLine("{0} $ {1}", entry.Key, entry.Value); 
                }
            }*/
        
        //Bpanel.SetActive(!Bpanel.activeSelf);
        Debug.Log("Init");
        buttonList= GameObject.FindGameObjectsWithTag("OptionItem");
        int index=0;
        Debug.Log(buttonList.Length);
        foreach( GameObject r in buttonList)
            {
            Debug.Log("Call");
               r.GetComponent<Button>().onClick.AddListener(() => OnClickFunc());
                index++;          
            }
                     

    }

    public void OnClickFunc()
    {
       // Debug.Log("22"+EventSystem.current.currentSelectedGameObject.name);
         if(Bpanel.activeInHierarchy == false)
        {
            Bpanel.SetActive(true);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[0].text);
        //GameObject.FindGameObjectWithTag("panel_text").GetComponent<Text>().text = panelData[EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>()[0].text];
        Debug.Log(Bpanel.activeInHierarchy);
        
      
     
    }

     public void OnClose()
        {
         Bpanel.SetActive(false);
    }

}
