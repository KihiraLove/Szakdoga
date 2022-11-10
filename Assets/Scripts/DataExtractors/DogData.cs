using UnityEngine;

namespace DataExtractors
{
    public class DogData : MonoBehaviour
    {
        private static DogData _instance;
        
        public static DogData Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("DOG Data Extractor is Null!");
                return _instance;
            }
        }
        
        private void Awake()
        {
            _instance = this;
        }
        
        public Vector3 LocalCoordinates => gameObject.transform.localPosition;

        public Vector3 WorldCoordinates => gameObject.transform.position;
    }
}
