using UnityEngine;

namespace AliSoner.Scripts
{
    public class KodSiir : MonoBehaviour
    {
        bool _ıamAlive=true;

        public bool YouLoveMe = true;

        //bool YouAreHere = true;
        int _myHapiness=0;
        int _myWories=-10;
        readonly int Zero = 0;
        readonly int Infinite = 999;


        private void FixedUpdate()
        {

            if (Input.GetKeyUp(KeyCode.E))
            {
                YouLoveMe = false;
            }

            while(_ıamAlive)//hayatta olduğum sürece
            {
                if(YouLoveMe)//eğer beni seversen
                {
                    _myHapiness++;//mutluluğum giderek artacak
                    _myWories--;//kaygılarım azalacak
                    Debug.Log("Mutlulugum : "+_myHapiness);
                    Debug.Log("Kaygım : "+_myWories);
                }
                else if(!YouLoveMe)//eğer beni sevmeyi kesersen
                {
                    _myHapiness = Zero;//mutlu olmıyıcam
                    Debug.Log(_myHapiness);
                    _myWories = Infinite;//sonsuz kaygım olacak
                    Debug.Log(_myWories);
                    _ıamAlive = false;//artık hayatta olmayacağım
                    break;
                }
            }
        }
    }
}


