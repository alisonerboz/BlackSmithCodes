using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AliSoner.Scripts
{
    public class CraftSystem : MonoBehaviour
    {
        private int _missing1, _missing2, _missing3, _missing4,_rising;
        
        public int inComingItem;
        public GameObject inComingItem1;
        public GameObject inComingItem2;
        public GameObject inComingItem3;
        public GameObject inComingItem4;
        public Image enteringU1;
        public Image enteringU2;
        public Image enteringU3;
        public Image enteringU4;
        public Image risingUI;
        public string willBeItemID;
        public GameObject itemsScript;
        private GameObject _customBlade;
        private GameObject _customBladePart1,_customBladePart2,_customBladePart3,_customBladePart4;
        Craftt _craftCustomBlade;
        [SerializeField] private GameObject kilicimcraft;
        [SerializeField] private GameObject world;
        
        [SerializeField] private Transform BladeLokasyon;

        private Material pommelColor, gripColor, collarsColor, knifeColor;
        private bool craftliyormu=false;
        private string orderIDolustur;

        private GameObject kilicim;
        private int totalValue;
        private void Start()
        {
            _craftCustomBlade = GetComponent<Craftt>();
        }

        public void ItemGeldi(GameObject arrivedItems)
        {
            inComingItem++;
            switch(inComingItem)
            {
                case 1:
                    inComingItem1 = arrivedItems;
                    break;
                case 2:
                    inComingItem2 = arrivedItems;
                    break;
                case 3:
                    inComingItem3 = arrivedItems;
                    break;
                case 4:
                    inComingItem4 = arrivedItems;
                    
                    willBeItemID += inComingItem1.GetComponent<Tasima>().ıtemIddd;
                    _missing1 = inComingItem1.GetComponent<Tasima>().ıtemIddd;
                    _customBladePart1 = inComingItem1.GetComponent<Tasima>().tasimaItemInfo;
                    //pommelColor.color = inComingItem1.GetComponent<Tasima>().materyalllInfo.color;
                    //orderIDolustur += inComingItem1.GetComponent<Tasima>().orderIDDD.ToString();
                    totalValue+=inComingItem1.GetComponent<Tasima>().MoneyyyValueee;
                    
                    
                    willBeItemID += inComingItem2.GetComponent<Tasima>().ıtemIddd;
                    _missing2 = inComingItem2.GetComponent<Tasima>().ıtemIddd;
                    _customBladePart2 = inComingItem2.GetComponent<Tasima>().tasimaItemInfo;
                    //gripColor.color = inComingItem1.GetComponent<Tasima>().materyalllInfo.color;
                    //orderIDolustur += inComingItem2.GetComponent<Tasima>().orderIDDD.ToString();
                    totalValue+=inComingItem2.GetComponent<Tasima>().MoneyyyValueee;
                    
                    willBeItemID += inComingItem3.GetComponent<Tasima>().ıtemIddd;
                    _missing3 = inComingItem3.GetComponent<Tasima>().ıtemIddd;
                    _customBladePart3 = inComingItem3.GetComponent<Tasima>().tasimaItemInfo;
                    //collarsColor.color = inComingItem1.GetComponent<Tasima>().materyalllInfo.color;
                    //orderIDolustur += inComingItem3.GetComponent<Tasima>().orderIDDD.ToString();
                    totalValue+=inComingItem3.GetComponent<Tasima>().MoneyyyValueee;
                    
                    willBeItemID += inComingItem4.GetComponent<Tasima>().ıtemIddd;
                    _missing4 = inComingItem4.GetComponent<Tasima>().ıtemIddd;
                    _customBladePart4 = inComingItem4.GetComponent<Tasima>().tasimaItemInfo;
                    //knifeColor.color = inComingItem1.GetComponent<Tasima>().materyalllInfo.color;
                    //orderIDolustur += inComingItem4.GetComponent<Tasima>().orderIDDD.ToString();
                    totalValue+=inComingItem4.GetComponent<Tasima>().MoneyyyValueee;
                    
                    orderIDolustur = inComingItem1.GetComponent<Tasima>().orderIDDD+
                                     inComingItem2.GetComponent<Tasima>().orderIDDD+
                                     inComingItem3.GetComponent<Tasima>().orderIDDD+
                                     inComingItem4.GetComponent<Tasima>().orderIDDD;
                    var countHowMany = itemsScript.GetComponent<ItemlerScript>().myItems.Count;
                    for(var i=0;i<countHowMany;i++)
                    {
                        if(willBeItemID==itemsScript.GetComponent<ItemlerScript>().myItems[i].neydenOlcak.ToString())
                        {
                            risingUI.sprite = itemsScript.GetComponent<ItemlerScript>().myItems[i].ıtemPhoto;
                            _rising = itemsScript.GetComponent<ItemlerScript>().myItems[i].ıtemIdd;
                            itemsScript.GetComponent<ItemlerScript>().myItems[i].itemValueee++;
                        }
                        else
                        {
                            //_craftCustomBlade.KilicCraftla(_customBladePart1,_customBladePart2,_customBladePart3,_customBladePart4);
                            //Instantiate(goldenBlade, pommelLokasyon.transform.position, Quaternion.identity);
                            /*goldenBlade.GetComponentInChildren<GameObject>().GetComponent<Material>().color =
                                pommelColor.color;
                            Debug.Log("renk " + pommelColor+" " + goldenBlade.GetComponentInChildren<GameObject>()
                                .GetComponent<Material>().color);*/
                            //itemsScript.GetComponent<ItemlerScript>().CollectItem();
                            if(!craftliyormu)
                                Craftla();



                        }
                    }
                    Wait();
                    inComingItem = 0;
                    break;
            }
        }

        private async void Craftla()
        {
            craftliyormu = true;
            await UniTask.Delay(250);
            kilicimcraft.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial=_customBladePart1.GetComponent<MeshRenderer>().sharedMaterial;//pommel renklendir
            kilicimcraft.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterials=_customBladePart2.GetComponent<MeshRenderer>().sharedMaterials;//gripleri renklendir
            kilicimcraft.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().sharedMaterial=_customBladePart3.GetComponent<MeshRenderer>().sharedMaterial;//collarsın kucugu renklendir
            kilicimcraft.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>()
                .sharedMaterial = _customBladePart3.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;//collarsın buyugu renklendir
            kilicimcraft.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().sharedMaterial=_customBladePart4.GetComponent<MeshRenderer>().sharedMaterial;//kilic renklendir
            Instantiate(kilicimcraft, BladeLokasyon.transform.position, Quaternion.identity);
            kilicim=GameObject.Find("kilicGold(Clone)");
            kilicim.GetComponent<ItemPickUp>().Item.orderID = orderIDolustur;
            kilicim.GetComponent<ItemPickUp>().Item.MoneyValue = totalValue*2;
            craftliyormu = false;
            Debug.Log(orderIDolustur);
        }
        private async void Wait()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            enteringU1.sprite = null;
            enteringU2.sprite = null;
            enteringU3.sprite = null;
            enteringU4.sprite = null;
            risingUI.sprite = null;
            willBeItemID = null;
            itemsScript.GetComponent<ItemlerScript>().EksikItemVer(_missing1);
        
            itemsScript.GetComponent<ItemlerScript>().EksikItemVer(_missing2);
        
            itemsScript.GetComponent<ItemlerScript>().EksikItemVer(_missing3);
        
            itemsScript.GetComponent<ItemlerScript>().EksikItemVer(_missing4);
            itemsScript.GetComponent<ItemlerScript>().EksikItemVer(_rising);
        

        }
    }
}
