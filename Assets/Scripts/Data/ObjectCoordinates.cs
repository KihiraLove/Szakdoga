using UnityEngine;

namespace Data
{
    public class ObjectCoordinates : MonoBehaviour
    {
        //Singleton implementation
        private static ObjectCoordinates _instance;
        public static ObjectCoordinates Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("Can't instantiate object to collect coordinates");
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
        }
        
        public GameObject menuShift;

        public GameObject shiftForward;

        public GameObject shiftUp;
        
        public float SpawnDistanceFromPlayer => shiftForward.transform.localPosition.z + menuShift.transform.localPosition.z;
    }
}
