using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue
{
    public List<QueueItem> queue;
    private string orderKey;
    private int index;
    private string operatingKey;

    public Queue()
    {
        queue = new List<QueueItem>();
    }

    void goToStart()
    {
        index = 0;
    }

    void goToEnd()
    {
        index = queue.Count - 1;
    }

    void moveForward()
    {
        index++;
        if(index > queue.Count - 1)
        {
            index = 0;
            foreach(QueueItem item in queue)
            {
                if (item.getType() == 1)
                    item.deccrementCounter();
                if (item.notify() != "")
                {
                    //place notification action here
                }
            }
        }
    }

    void moveBack()
    {
        index--;
        if (index < 0)
        {
            index = queue.Count - 1;
            foreach (QueueItem item in queue)
            {
                if (item.getType() == 1)
                    item.incrementCounter();
                if (item.notify() != "")
                {
                    //place notification action here
                }
            }
        }
    }

    public void addToQueue(QueueItem item)
    {
        if (null == operatingKey)
            queue.Add(item);
        else
        {
            if (item.getNumericalValue(operatingKey) == float.NegativeInfinity)
            {
                Debug.Log("Can't add to queue; needed field not found");
                return;
            }
            else
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    if (0 == i)
                    {
                        if (queue[i].getNumericalValue(operatingKey) < item.getNumericalValue(operatingKey))
                        {
                            queue.Insert(0, item);
                            return;
                        }
                    }
                    else
                    {
                        if (queue[i - 1].getNumericalValue(operatingKey) > item.getNumericalValue(operatingKey)
                        && queue[i].getNumericalValue(operatingKey) < item.getNumericalValue(operatingKey))
                        {
                            queue.Insert(i, item);
                            return;
                        }
                    }
                }
            }
            queue.Add(item);
        }
    }

    public void orderBy(string key)
    {
        operatingKey = key;

        List<(float, int)> order = new List<(float, int)>();
        List<(QueueItem, int)> nonEntities = new List<(QueueItem, int)>();
        int i = 0;

        foreach (QueueItem item in queue)
        {
            if (item.getType() == 0)
            {
                if (item.getNumericalValue(key) == float.NegativeInfinity)
                {
                    Debug.Log("Error; key does not return numerical field");
                    return;
                }
                else
                {
                    order.Add((item.getNumericalValue(key), i));
                }
            }
            else
            {
                nonEntities.Add((item, i));
            }
            i++;
        }

        int len = order.Count;
        List<QueueItem> tempQueue = new List<QueueItem>();
        int index;

        for (int j = 0; j < len; j++)
        {
            (float, int) temp = order[0];
            index = 0;
            for (int k = 0; k < order.Count; k++)
            {
                if (temp.Item1 < order[k].Item1)
                {
                    temp = order[k];
                    index = k;
                }
            }
            order.RemoveAt(index);

            tempQueue.Add(queue[temp.Item2]);
        }

        foreach ((QueueItem, int) nonEntity in nonEntities)
            tempQueue.Insert(nonEntity.Item2, nonEntity.Item1);

        queue = tempQueue;
    }

    //currently present for testing purposes. May remove if not useful
    public List<string> getTextFieldFromEach(string key)
    {
        List<string> field = new List<string>();
        foreach (QueueItem item in queue)
        {
            field.Add(item.getTextValue(key));
        }

        return field;
    }
}
