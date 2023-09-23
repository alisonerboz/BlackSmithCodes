using UnityEngine;

namespace AliSoner.Scripts
{
    public class Craftt : MonoBehaviour
    {
        [SerializeField] private GameObject kilicPrefab;
        //[SerializeField] private Transform kilicLocation;

        public void KilicCraftla(GameObject p,GameObject g,GameObject c, GameObject k)
        {
        
            Instantiate(kilicPrefab, this.gameObject.transform.position, Quaternion.identity);
            kilicPrefab.transform.GetChild(0).gameObject.SetActive(false);
            Instantiate(p, kilicPrefab.transform.GetChild(0).transform.position, Quaternion.identity);
            kilicPrefab.transform.GetChild(1).gameObject.SetActive(false);
            Instantiate(g, kilicPrefab.transform.GetChild(1).transform.position, Quaternion.identity);
            kilicPrefab.transform.GetChild(2).gameObject.SetActive(false);
            Instantiate(c, kilicPrefab.transform.GetChild(2).transform.position, Quaternion.identity);
            kilicPrefab.transform.GetChild(3).gameObject.SetActive(false);
            Instantiate(k, kilicPrefab.transform.GetChild(3).transform.position, Quaternion.identity);
        }

    
    }
}
