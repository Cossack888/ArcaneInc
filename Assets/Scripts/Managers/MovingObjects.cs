using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MovingObjects : MonoBehaviour
{
    public static MovingObjects Instance { get; private set; }
    public Item NewItem;
    public ItemSlot Slot;
    public Image Img;
    [SerializeField] Sprite defaultSprite;
    public int ItemAmount;

    private void Start()
    {
        Img = GetComponentInChildren<Image>();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    public void SetItemSlot(ItemSlot itemSlot)
    {
        Slot = itemSlot;
        if (Slot.CurrentItem)
        {
            NewItem = Slot.CurrentItem;
            Img.sprite = Slot.CurrentItem.Sprite;
            ItemAmount = Slot.amount;
        }
    }
    public void ClearDataCache()
    {
        Img.sprite = defaultSprite;
        NewItem = null;
        ItemAmount = 0;
    }
    public void ReturnToDefault()
    {
        if (Slot)
        {
            Slot.Image.sprite = Img.sprite;
            Slot.CurrentItem = NewItem;
            Slot.amount = ItemAmount;
            Slot.GetComponentInChildren<TMP_Text>().text = ItemAmount.ToString();
        }
    }
    public void DecreaseAmount(int amount)
    {
        ItemAmount -= amount;
    }
}
