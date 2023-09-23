using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AliSoner.Scripts
{
    public class ItemlerScript : MonoBehaviour
    {
        
        public GameObject growing;
        public List<ItemlerBilgi> myItems;
        public Transform slot;
        public GameObject itemPrefab;
        
        private void Start()
        {
            
            GiveItem();
        }

        private void GiveItem()
        {
            for (var i = 0; i < myItems.Count; i++)
            {
                growing = Instantiate(itemPrefab, slot.transform);
                growing.GetComponentInChildren<Text>().text = myItems[i].ıtemNamee;
                growing.GetComponent<Image>().sprite = myItems[i].ıtemPhoto;
                growing.GetComponent<Tasima>().ıtemIddd = i;
                growing.GetComponent<Tasima>().itemismi = myItems[i].ıtemNamee;
                growing.GetComponent<Tasima>().MoneyyyValueee = myItems[i].MoneyyValue;
                growing.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = myItems[i].itemValueee.ToString();
                growing.transform.GetChild(3).gameObject.GetComponent<Button>().GetComponentInChildren<Text>()
                    .text = myItems[i].MoneyyValue.ToString(); //item.MoneyValue.ToString();

            }
        }
    
        public void CollectItem(Item item)
        {
            
            myItems.Add (new ItemlerBilgi(item.ItemName,item.icon, item.id,item.neydenid,item.value,item.prefab,item.orderID,item.MoneyValue /*,item.materialGeldi*/));
            growing = Instantiate(itemPrefab, slot.transform);
            for (var i = 0; i < myItems.Count; i++)
            {
                
                if (item.id-2 == myItems[i].ıtemIdd)
                {
                    myItems[i].itemValueee++;
                    growing.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = myItems[i].itemValueee.ToString();
                    
                }
                else
                {
                    growing.GetComponentInChildren<Text>().text = item.ItemName;
                    growing.GetComponent<Image>().sprite = item.icon;
                    growing.GetComponent<Tasima>().ıtemIddd = i;
                    growing.GetComponent<Tasima>().orderIDDD = item.orderID;
                    growing.GetComponent<Tasima>().tasimaItemInfo = item.prefab;
                    growing.GetComponent<Tasima>().MoneyyyValueee = item.MoneyValue;
                    growing.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = item.value.ToString();
                    growing.transform.GetChild(3).gameObject.GetComponent<Button>().GetComponentInChildren<Text>()
                        .text = item.MoneyValue.ToString();
                    
                    //Debug.Log(myItems.Count);
                }
                growing.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = myItems[i].itemValueee.ToString();
            }
            
            

        }
        public void EksikItemVer(int j)
        {
            GameObject growing2 = Instantiate(itemPrefab, slot.transform);
            for (var i = 0; i < myItems.Count; i++)
            {
                if (j==myItems[i].ıtemIdd)
                {
                    myItems[i].itemValueee++;
                    //growing2.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = myItems[i].itemValueee.ToString();
                }
                else
                {
                    growing2.GetComponentInChildren<Text>().text = myItems[j].ıtemNamee;
                    growing2.GetComponent<Image>().sprite = myItems[j].ıtemPhoto;
                    growing2.GetComponent<Tasima>().ıtemIddd = j;
                    growing2.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = myItems[j].itemValueee.ToString();
                }
                
            }
    
            
        
        
        }
    }
    [System.Serializable]
    public class ItemlerBilgi
    {
        public string ıtemNamee;
        public Sprite ıtemPhoto;
        public int ıtemIdd;
        public int neydenOlcak;
        public int itemValueee;
        public int MoneyyValue;
        public string orderIDD;
        public GameObject prefabb;
        //public Material materialim;

        public ItemlerBilgi(string itemNamee, Sprite itemPhoto, int itemIdd, int neydenOlcak,int itemValuee,GameObject prefabGelen,string orderIDDD,int MoneyyValuee/*,Material materyal*/)
        {
            ıtemNamee = itemNamee;
            ıtemPhoto = itemPhoto;
            ıtemIdd = itemIdd;
            this.neydenOlcak = neydenOlcak;
            itemValueee = itemValuee;
            prefabb = prefabGelen;
            orderIDD = orderIDDD;
            MoneyyValue = MoneyyValuee;
            //materialim = materyal;

        }

    
    }
}