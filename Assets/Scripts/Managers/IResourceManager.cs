using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceManager
{

    void AddItem(Item item, int SlotID);
    Item RemoveItem(string itemID);
    int itemCount(string itemID);
    bool CanAddItem(Item item, int amount = 1);
    bool isFull();
    void ClearAllSlots();
}


