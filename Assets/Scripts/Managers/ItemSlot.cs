using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Sprite emptySprite;
    public Image Image;
    public Item CurrentItem;
    public int amount;
    private TMP_Text _itemCount;
    public bool Restricted, WarehouseSlot, MainInventorySlot, ShopSlot, CurrentSlot,
                IngredientSlot, CraftingTableSlot, TakeOnly, MarketSlot, MainSupplySlot;
    private MovingObjects _movingObjects;
    void Start()
    {
        _itemCount = GetComponentInChildren<TMP_Text>();
        Image = GetComponent<Image>();
        if (CurrentItem != null)
        {
            Image.sprite = CurrentItem.Sprite;
        }
        else
        {
            Image.sprite = emptySprite;
        }
        _movingObjects = MovingObjects.Instance;
        Recount();
    }
    public void OnPointerUp(PointerEventData eventData)
    {

        if (IsValidSlot(eventData))
        {
            ItemSlot NewSlot = eventData.pointerEnter.GetComponent<ItemSlot>();
            ResetSlot(NewSlot);
        }
        else
            _movingObjects.ReturnToDefault();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _movingObjects.SetItemSlot(this);
        ClearSlot();
    }
    public void Recount()
    {
        _itemCount.text = amount.ToString();
    }
    public void ResetSlot(ItemSlot NewSlot)
    {
        NewSlot.CurrentItem = _movingObjects.NewItem;
        NewSlot.amount = _movingObjects.ItemAmount;
        NewSlot.Image.sprite = _movingObjects.NewItem.Sprite;
        NewSlot.Recount();
    }
    public void ClearSlot()
    {
        CurrentItem = null;
        amount = 0;
        Image.sprite = emptySprite;
        Recount();
    }
    public bool IsValidSlot(PointerEventData eventData)
    {
        if (eventData.pointerEnter && eventData.pointerEnter.GetComponent<ItemSlot>())
            return true;
        else
            return false;
    }
}
