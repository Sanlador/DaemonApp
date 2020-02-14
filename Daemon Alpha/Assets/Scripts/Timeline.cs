using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{

	Queue queue = new Queue();

	public Button forward = null;
	public Button backward = null;
	public Button foreskip = null;
	public Button backskip = null;

	public Button addNote = null;
	public Button addCounter = null;
	public Button addSheet = null;
	public Button order = null;
	public InputField sortBy = null;


	public Transform viewTrans = null;

	public Transform transform = null;

	public GameObject eventPrefab = null;

	public GameObject notification = null;
	public Text 	  notifText = null;
	public InputField notifInput = null;
	public Button dismissPopup = null;
	bool poppedUp = false;

	List<GameObject>  events = new List<GameObject>();

	int buffer_size = 2;

	int notif_count = 0;
	int count_count = 0;
	int sheet_count = 0;

	float currentPosition = 0;
	const float approach = 0.1f;


	QueueItem new_notif(){
		QueueItem result = new QueueItem("notif"+notif_count.ToString());
		notif_count++;
		return result;
	}


	QueueItem new_count(){
		QueueItem result = new QueueItem(count_count);
		count_count++;
		return result;
	}


	QueueItem new_sheet(){
		InfoSheet sheet = new InfoSheet("sheet"+sheet_count.ToString());
		sheet.addDynamic("initiative",(float)-sheet_count,float.PositiveInfinity,float.NegativeInfinity,(float)sheet_count,1f,1f);
		sheet.addDynamic("reverse",(float)sheet_count,float.PositiveInfinity,float.NegativeInfinity,(float)sheet_count,1f,1f);
		sheet_count++;
		return new QueueItem(sheet);
	}


	void refresh(){

		if(queue.queue.Count > 0 ){
			
			float target  = queue.getIndex();
			int current_idx = ((int)(currentPosition+0.5) + queue.queue.Count) % queue.queue.Count;
			int label_idx = ((int)(-currentPosition) + queue.queue.Count) % queue.queue.Count;
			float diff = currentPosition - current_idx;
			
			for(int i = -buffer_size; i <= buffer_size; i++){
				int idx = (i + current_idx + queue.queue.Count)%queue.queue.Count;
				Text label = events[i+buffer_size].GetComponentInChildren<Text>();
				label.text=((char) ((int)'A' + idx)).ToString();
				RectTransform rtform = events[i+buffer_size].GetComponentInChildren<RectTransform>();
				rtform.anchoredPosition = new Vector2(0,0);
				rtform.anchorMin = new Vector2(0.5f,0.5f);
				rtform.anchorMax = new Vector2(0.5f,0.5f);
				rtform.offsetMin = new Vector2(128*(+i-diff)-24,-24);
				rtform.offsetMax = new Vector2(128*(+i-diff)+24,24);

				/*
				int lastIdx = (i + current_idx + queue.queue.Count - 1)%queue.queue.Count;
				int nextIdx = (i + current_idx + queue.queue.Count + 1)%queue.queue.Count;
				if(queue.queue.Count == 0){
					events[i+buffer_size].SetActive(false);
					Debug.Log("All out");
				} if( (lastIdx > idx) ){
					events[i+buffer_size].SetActive(i <= 0);
				} else if( (nextIdx < idx) ){
					events[i+buffer_size].SetActive(i >= 0);
				} else {
					events[i+buffer_size].SetActive( i == 0 );
				}
				//*/

			}
				
			currentPosition = target * approach + currentPosition * (1.0f - approach);

		}

	}


	void HandleChange(){
		/*
		if(queue.queue.Count == 0){
			return;
		}

		QueueItem currentEvent = queue.queue[queue.getIndex()];
		char[] newl = {'\n','\r'};
		string[] input = notifInput.text.Split(newl);

		if((input.Length == 1) || (input[0].Trim().Length == 0) ){
			queue.removeCurrentItem();
			if(queue.queue.Count == 0){
				dismiss_button();
			}
			return;
		}


		return;

		switch(currentEvent.getType()){
		case 0:
			notifText.text = currentEvent.getName();
			break;
		case 1:
			notifText.text = currentEvent.getCounter().ToString();
			break;
		case 2:
			notifText.text = currentEvent.getNotification();
			break;
		default:
			notifText.text = "";
			return;
		}
		notification.SetActive(true);
		*/
	}


	void do_popup(){

		if(queue.queue.Count == 0){
			return;
		}

		QueueItem currentEvent = queue.queue[queue.getIndex()];
		switch(currentEvent.getType()){
		case 0:
			Debug.Log("Name");
			notifInput.text = currentEvent.getName();
			break;
		case 1:
			Debug.Log("Count");
			notifInput.text = currentEvent.getCounter().ToString();
			break;
		case 2:
			Debug.Log("Note");
			notifInput.text = currentEvent.getNotification();
			break;
		default:
			notifInput.text = "";
			return;
		}
		notification.SetActive(true);
	}


	void fwd_button(){
		Debug.Log("Forward");
		queue.moveForward();
		do_popup();
		//refresh();
	}

	void bwd_button(){
		Debug.Log("Backward");
		queue.moveBack();
		do_popup();
		//refresh();
	}

	void fkp_button(){
		Debug.Log("Foreskip");
		queue.goToEnd();
		do_popup();
		//refresh();
	}

	void bkp_button(){
		Debug.Log("Backskip");
		queue.goToStart();
		do_popup();
		//refresh();
	}

	void notif_button(){
		Debug.Log("Notif");
		queue.addToQueue(new_notif());
		//refresh();
	}

	void count_button(){
		Debug.Log("Count");
		queue.addToQueue(new_count());
		do_popup();
		//refresh();
	}

	void sheet_button(){
		Debug.Log("Sheet");
		queue.addToQueue(new_sheet());
		do_popup();
		//refresh();
	}

	void order_button(){
		Debug.Log("Order");
		if(sortBy.text.Length == 0){
			return;
		}
		queue.orderBy(sortBy.text);
		do_popup();
		//refresh();
	}

	void dismiss_button(){
		Debug.Log("Dismiss");
		notifInput.text = "";
		notification.SetActive(false);
		//refresh();
	}



    // Start is called before the first frame update
    void Start()
    {
		transform = GetComponent<Transform>();

		forward    = transform.Find("Forward_Button").GetComponent<Button>();
		backward   = transform.Find("Backward_Button").GetComponent<Button>();
		foreskip   = transform.Find("ForeSkip_Button").GetComponent<Button>();
		backskip   = transform.Find("BackSkip_Button").GetComponent<Button>();

		addNote    = transform.Find("Note_Button").GetComponent<Button>();
		addCounter = transform.Find("Counter_Button").GetComponent<Button>();
		addSheet   = transform.Find("Sheet_Button").GetComponent<Button>();
		order      = transform.Find("Order_Button").GetComponent<Button>();

		sortBy     = transform.Find("Order_By_Field").GetComponent<InputField>();
		viewTrans  = transform.Find("TimeLine_View").GetComponent<Transform>();

		notification = transform.Find("Popup").gameObject;
		notifInput = notification.transform.Find("Popup_View").GetComponent<InputField>();
		notifInput.onValueChanged.AddListener(delegate {HandleChange(); });
		notifText = notification.transform.Find("Popup_View").Find("Popup_Text").GetComponent<Text>();
		dismissPopup = transform.Find("TimeLine_Reticle").GetComponent<Button>();


		forward.onClick.AddListener		(fwd_button);
		backward.onClick.AddListener	(bwd_button);
		foreskip.onClick.AddListener	(fkp_button);
		backskip.onClick.AddListener	(bkp_button);
		addNote.onClick.AddListener		(notif_button);
		addCounter.onClick.AddListener	(count_button);
		addSheet.onClick.AddListener	(sheet_button);
		order.onClick.AddListener		(order_button);
		dismissPopup.onClick.AddListener(dismiss_button);



		for( int i = -buffer_size; i <= buffer_size; i++){
			GameObject go = Instantiate(eventPrefab,viewTrans);
			RectTransform rt = go.GetComponent<RectTransform>();
			events.Add(go);
		}

		notification.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
		refresh();
    }
}
