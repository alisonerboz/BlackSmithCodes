using System;
using UnityEngine;
using UnityEngine.UI;

namespace AliSoner.Scripts
{
    public class Tasima : MonoBehaviour
    {
        public GameObject canvas;
        public int ıtemIddd;
        public string itemismi;
        public string orderIDDD;
        public float uzaklik;
        //public GameObject 
        public GameObject ıtemsScript;
        public GameObject craftSystems;
        public GameObject tasimaItemInfo;
        public int MoneyyyValueee;
        public GameObject kazmaac;
        public GameObject _TicaretObje;
        public Ticaret _Ticaret;
        
        //public Material materyalllInfo;

        public int OurMoney=0;
        public void Start()
        {
            _TicaretObje = GameObject.Find("Ticaretim");
            _Ticaret = _TicaretObje.GetComponent<Ticaret>();
            OurMoney = _Ticaret.Bakiyemiz;
            kazmaac = GameObject.Find("Selection Manager");
            //_GameManager.paramiz = OurMoney;
            canvas = GameObject.Find("MarketCanvas");
            craftSystems = GameObject.Find("CraftSystem");
            ıtemsScript = GameObject.Find("ItemlerBilgi");
        }

        private void Update()
        {
            OurMoney = _Ticaret.Bakiyemiz;
            //Debug.Log("saniyede arttı : "+OurMoney);
        }

        public void OnMouseDrag()
        {
            if (Camera.main != null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = uzaklik;
                var transform1 = transform;
                transform1.position = mousePos;
                transform1.parent = canvas.transform;
            }
        }
        

        public void OnMouseDown()
        {
            OurMoney = _Ticaret.Bakiyemiz;
            Debug.Log("Tıkladım Artı : "+OurMoney);
            if (Camera.main != null)
            {
                if (OurMoney >= MoneyyyValueee)
                {
                    _Ticaret.Alis(MoneyyyValueee);
                    if (itemismi == "Kazma")
                    {
                        kazmaac.GetComponent<SelectionManager>().KazmaKilidAc();
                    }
                    if (itemismi == "Harita")
                    {
                        _Ticaret.OyunBitsin();
                    }
                    //if()
                    Debug.Log("Satin Alindi");
                    this.gameObject.SetActive(false);
                }

                if (MoneyyyValueee > OurMoney)
                {
                    Debug.Log("Yetersiz Bakiye");
                }
                /*
                */
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Slot")&&other.gameObject.GetComponent<Image>().sprite==null)
            {
                other.gameObject.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
                craftSystems.GetComponent<CraftSystem>().ItemGeldi(gameObject);
                ıtemsScript.GetComponent<ItemlerScript>().myItems[GetComponent<Tasima>().ıtemIddd].itemValueee-=2;
                gameObject.SetActive(false);
                Destroy(this.gameObject,15f);
            }
        }

        
        public void SellItem()
        {
            _Ticaret.Satis(this.MoneyyyValueee);
            this.gameObject.SetActive(false);
            
        }
    }
}
