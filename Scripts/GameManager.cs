using UnityEngine;
namespace AliSoner.Scripts
{
    public class GameManager : MonoBehaviour
    {
        /*public List<Quest> NewQuest;
        public GameObject cameram;*/
        public GameObject hud;
        public GameObject world;
        public GameObject ıtemsScript;
        [SerializeField] private Camera perspektif;
        [SerializeField] private Camera ortografik;
        [SerializeField] private FirstPersonController look;
        bool _hudDurum=true;
        public int paramiz = 0;
        private void Satis()
        {
            if (ıtemsScript.GetComponent<ItemlerScript>().myItems[GetComponent<Tasima>().ıtemIddd].itemValueee >= 1)
            {
                //paramiz+=
                ıtemsScript.GetComponent<ItemlerScript>().myItems[GetComponent<Tasima>().ıtemIddd].itemValueee--;
                Debug.Log(paramiz);
            }
        }
        private void Start()
        {
            ıtemsScript = GameObject.Find("ItemlerBilgi");
            //cameram.GetComponent<Camera>().orthographic = false;
            hud = GameObject.Find("0");
            perspektif.enabled = true;
            ortografik.enabled = false;
            hud.SetActive(false);
        }

        /*[System.Serializable]
        public class Quest
        {
            public int OrderItemId;

            public Quest(int OrderItemId2)
            {
                OrderItemId = OrderItemId2;
            }
        }*/
        void Update()
        {

            if (Input.GetKeyUp(KeyCode.I))
            {
                if (_hudDurum == false)
                {
                    world.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    look.enabled = false;
                    Cursor.visible = true;
                    Time.timeScale = 0.25f;
                    hud.SetActive(true);
                    ortografik.enabled = true;
                    perspektif.enabled = false;
                    _hudDurum = true;
                    //cameram.GetComponent<Camera>().orthographic = true;
                }
                else if (_hudDurum)
                {
                    world.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    look.enabled = true;
                    Cursor.visible = true;
                    Time.timeScale = 1f;
                    hud.SetActive(false);
                    perspektif.enabled = true;
                    ortografik.enabled = false;
                    _hudDurum = false;
                    //cameram.GetComponent<Camera>().orthographic = false;
                }
            }
        }

        public void EkranAc()
        {
            if (_hudDurum == false)
            {
                world.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                look.enabled = false;
                Cursor.visible = true;
                //Time.timeScale = 0.001f;
                hud.SetActive(true);
                ortografik.enabled = true;
                perspektif.enabled = false;
                _hudDurum = true;
                //cameram.GetComponent<Camera>().orthographic = true;
            }
            else if (_hudDurum)
            {
                world.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                look.enabled = true;
                Cursor.visible = true;
                //Time.timeScale = 1;
                hud.SetActive(false);
                perspektif.enabled = true;
                ortografik.enabled = false;
                _hudDurum = false;
                //cameram.GetComponent<Camera>().orthographic = false;
            }
        }
    }
}
