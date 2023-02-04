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
        
        public GameObject forwardCapsule;

        public GameObject shiftForward;

        public GameObject shiftUp;

        //Properties
        public float ObjectSpawnDistanceFromPlayerZ => shiftForward.transform.localPosition.z + forwardCapsule.transform.localPosition.z;

        public float ObjectSpawnDistanceFromPlayerX => shiftForward.transform.localPosition.x + forwardCapsule.transform.localPosition.x;
        
        public float ObjectSpawnDistanceFromPlayerY => shiftForward.transform.localPosition.y + forwardCapsule.transform.localPosition.y;
        
        //Functions
        private void Start()
        {

        }
    }
}
