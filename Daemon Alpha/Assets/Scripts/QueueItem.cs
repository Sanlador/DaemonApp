using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Queue item class. Serves as the individual items that populate the turn order queue.
 To instantiate, simply call a constuctor either inputting the entity, counter value, or 
 notification you wish for it to contain*/

public class QueueItem
{
    //0 = entity, 1 = counter, 2 = reminder
    private int itemType;
    private int counter = -1;
    private string notification = "";
    private InfoSheet entity = null;

    public QueueItem(InfoSheet entityItem)
    {
        entity = entityItem;
        itemType = 0;
    }

    public QueueItem(int count)
    {
        counter = count;
        itemType = 1;
    }

    public QueueItem(string message)
    {
        notification = message;
		itemType = 2;
    }

    public int getType()
    {
        return itemType;
    }

    public string notify()
    {
        return notification;
    }

	public List<string> getNumericalKeys (){
		if(itemType != 0){
			return null;
		}
		List<string> result = new List<string>(entity.staticNumericalFields.Keys);
		result.AddRange(entity.dynamicNumericalFields.Keys);
		return result;
	}

	public bool hasNumericalKey (string key){
		if(itemType != 0){
			return false;
		}
		bool S = entity.staticNumericalFields.ContainsKey(key);
		bool D = entity.dynamicNumericalFields.ContainsKey(key);
		return (S|D);
	}

    public float getNumericalValue(string key)
    {
        if (0 == itemType)
        {
            if (entity.dynamicNumericalFields.ContainsKey(key))
                return entity.dynamicNumericalFields[key].Item1;
            else if (entity.staticNumericalFields.ContainsKey(key))
                return entity.staticNumericalFields[key].Item1;
            else
                return float.NegativeInfinity;
        }
        else
            return float.PositiveInfinity;  //returns negative infinity to signal error
    }

    public string getTextValue(string key)
    {
        if (0 == itemType)
        {
            if (entity.textFields.ContainsKey(key))
                return entity.textFields[key].Item1;
            else
                return "";
        }
        else
            return "";  //returns empty string to signal error
    }

    public string getNotification()
    {
        return notification;
	}

	public int getCounter()
	{
		return counter;
	}


	public string getName()
	{
		return entity.getName();
	}

    public void deccrementCounter()
    {
        counter--;
        //if(0 == counter)  //send notification when counter hits zero
        {

        }
    }

    public void incrementCounter()
    {
        counter++;
    }

}
