using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public int neydenid;
    public string ItemName;
    public int value;
    public Sprite icon;
    public GameObject prefab;
    public int MoneyValue;
    public string orderID;
    //public Material materialGeldi;



}
