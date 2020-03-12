using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToTimeline : MonoBehaviour
{
    public GameObject counterText, counterNum, notificationText, timeline;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addCounter()
    {
        int counter = int.Parse(counterNum.GetComponent<InputField>().text);
        string message = counterText.GetComponent<InputField>().text;
        timeline.GetComponent<Timeline>().new_count(new QueueItem(counter, message));
        counterNum.GetComponent<InputField>().text = "";
        counterText.GetComponent<InputField>().text = "";
    }

    public void addNotification()
    {
        string message = notificationText.GetComponent<InputField>().text;
        timeline.GetComponent<Timeline>().new_notif(new QueueItem(message));
        notificationText.GetComponent<InputField>().text = "";
    }
}
