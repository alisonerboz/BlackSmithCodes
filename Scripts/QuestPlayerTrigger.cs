using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace AliSoner.Scripts
{
    public class QuestPlayerTrigger : MonoBehaviour
    {
        #region Private Variables
        //private bool _iceride;
        private int _step=0;
        private string _neyinicinde;
        #endregion
        //bıçak,balçak,kabza,beygir
        private string[] _blades = { "Demir Bıçaklı","Gümüş Bıçaklı","Altın Bıçaklı" };
        private string[] _collars = { "Demirden Balçaklı","Gümüşden Balçaklı","Altından Balçaklı" };
        private string[] _grips = { "Ahşap Kabzalı","İplik Dokuma Kabzalı","Deri Kaplama Kabzalı" };
        private string[] _pommels = { "Demir Beygirli","Gümüş Beygirli","Altın Beygirli" };
        public string orderId;
        private GameManager _gm;
        private ItemlerScript itemlerimControl;

        private void Start()
        {
            _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            itemlerimControl = GameObject.Find("ItemlerBilgi").GetComponent<ItemlerScript>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (_step==0 && _neyinicinde=="customer")
                {
                    int p = Random.Range(0, 3);
                    //Debug.Log("p : "+p);
                    int g = Random.Range(0, 3);
                    //Debug.Log("g : "+g);
                    int c = Random.Range(0, 3);
                    //Debug.Log("c : "+c);
                    int b = Random.Range(0, 3);
                    //Debug.Log("b : "+b);
                    orderId = p.ToString() + g.ToString() + c.ToString()+ b.ToString() ;
                    Debug.Log("Sipariş No: "+orderId);
                    Debug.Log("Ben bir adet "+_pommels[p]+" "+_grips[g]+" "+_collars[c]+" "+_blades[b]+" kılıç istiyorum");
                    _step++;
                        
                }
                if (_step==1 && _neyinicinde=="customer")
                {
                    if (itemlerimControl.myItems == null)
                        Debug.Log("Burada hiçbirşey göremiyorum");
                    for (var i = 0; i < itemlerimControl.myItems.Count; i++)
                    {
                        if (itemlerimControl.myItems[i].orderIDD==orderId)
                        {
                            Debug.Log("İstediğim Kilic bu!");
                            _step++;
                        }
                        else
                        {
                            //Debug.Log("istediğim kilici getirmemissin. Adım : "+_step);
                        }
                    }
                    
                }
                
                
                if (_neyinicinde=="CraftTable")
                {
                    _gm.EkranAc();
                }
                
            }
        }

        private void OnTriggerStay(Collider other)
        {
            //_iceride = true;
            if(other.CompareTag("customer"))
            {
                _neyinicinde = "customer";
            }
            else if(other.CompareTag("ors"))
            {
                _neyinicinde = "ors";
            }
            else if(other.CompareTag("reyon"))
            {
                _neyinicinde = "reyon";
            }
            else if(other.CompareTag("ocak"))
            {
                _neyinicinde = "ocak";
            }
            else if(other.CompareTag("CraftTable"))
            {
                _neyinicinde = "CraftTable";
            }
            
            
        }

        private void OnTriggerExit(Collider other)
        {
            //_iceride = false;
            _neyinicinde = null;
        }
    }
}
