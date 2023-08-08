using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour,IResourceManager
{
    void Start()
    {

    }
    public void AddItem(Item item, int SlotID)
    {
        throw new System.NotImplementedException();
    }

    public bool CanAddItem(Item item, int amount = 1)
    {
        throw new System.NotImplementedException();
    }

    public void ClearAllSlots()
    {
        throw new System.NotImplementedException();
    }

    public bool isFull()
    {
        throw new System.NotImplementedException();
    }

    public int itemCount(string itemID)
    {
        throw new System.NotImplementedException();
    }

    public Item RemoveItem(string itemID)
    {
        throw new System.NotImplementedException();
    }


}
