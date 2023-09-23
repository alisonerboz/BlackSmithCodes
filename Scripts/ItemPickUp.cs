using AliSoner.Scripts;
using UnityEngine;


public class ItemPickUp : MonoBehaviour//,IPointerDownHandler
{
    public ItemlerScript toplacnm;
    public Item Item;

    private GameObject script;
    //public Material mate;
    private void Start()
    {
        /*script=GameObject.Find("ItemlerBilgi");
        script.GetComponent<ItemlerScript>().CollectItem(Item);*/
        toplacnm = GameObject.Find("ItemlerBilgi").GetComponent<ItemlerScript>();
    }

    private void OnMouseDown()
    {
        toplacnm.CollectItem(Item);
        //script.GetComponent<ItemlerScript>().CollectItem(Item);
        Destroy(gameObject);
    }
    

}
