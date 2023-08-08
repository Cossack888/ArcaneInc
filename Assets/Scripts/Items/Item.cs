using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public Sprite Sprite;
    public ItemType Type;
    public bool IsStackable = true;
    public string ItemName;
    //public int MaximumStacks = 99;
    public float Value;
    public int Rarity;

    public enum ItemType
    {
        craftingIngredient,
        potion,
        weapon,
        armor,
        tradingGoods,
        all,
    }
    public virtual Item GetCopy()
    {
        return this;
    }

}