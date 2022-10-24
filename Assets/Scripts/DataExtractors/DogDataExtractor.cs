using UnityEngine;

namespace DataExtractors
{
    public class DogDataExtractor : MonoBehaviour
    {
        private static DogDataExtractor _instance;

        public static DogDataExtractor Instance
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
        
        //TODO: automatically calculate distance into coordinates
        public float HorizontalX => 50.0f;

        public float HorizontalY => 0.0f;

        public float VerticalX => 50.0f;

        public float VerticalY => 0.0f;
    }
}
