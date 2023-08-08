using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyGenerator : MonoBehaviour
{
    [SerializeField] Item[] items;
    private int amount;
    private int minAmount;
    private int rarity;
    public Dictionary<Item, int> Supply;
    ItemSlot[] slots;
    public List<ItemSlot> marketSlots;
    public void SetIdForSlots()
    {
        slots = FindObjectsOfType<ItemSlot>();
        marketSlots = new List<ItemSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ID.Contains("market"))
            {
                marketSlots.Add(slots[i]);
            }
        }
    }
    public void GenerateSupply()
    {
        Supply = new Dictionary<Item, int>();
        for (int i = 0; i < items.Length; i++)
        {
            rarity = Random.Range(1, 100);

            int itemRarity = items[i].Rarity;
            minAmount = Mathf.Clamp(50 - itemRarity, 1, 50);
            amount = Mathf.Clamp(Random.Range(minAmount, 99) - itemRarity, 1, 99);
            if (rarity > itemRarity)
                Supply.Add(items[i], amount);
            SendToMarket(items[i]);
        }

    }
    void SendToMarket(Item item)
    {
        for (int i = 0; i < marketSlots.Count; i++)
        {
            ItemSlot currentSlot = marketSlots[i];
            if (currentSlot.ID.Contains(i.ToString()))
            {
                Supply.TryGetValue(item, out int currentAmount);
                currentSlot.SetItemInSLot(item, currentAmount);
            }
        }
    }
}