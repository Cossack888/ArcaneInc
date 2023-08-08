using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlots : MonoBehaviour
{   [SerializeField] int amountOfSlots;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] SlotType type;
    private SupplyGenerator _supply;
    enum SlotType
    {
        market,
        warehouse,
    }
    void Start()
    {
        _supply = FindObjectOfType<SupplyGenerator>();
        for(int i = 0; i < amountOfSlots; i++)
        {
            GameObject createdGO = Instantiate(slotPrefab, gameObject.transform);
            createdGO.hideFlags = HideFlags.HideInHierarchy;
            ItemSlot slot = createdGO.GetComponent<ItemSlot>();
            slot.ID = type + i.ToString();
            
        }
        _supply.SetIdForSlots();
    }

}
