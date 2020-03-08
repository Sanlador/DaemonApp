using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public void removeObject()
    {
        print("Deleting object");
        Destroy(gameObject);
    }
}
