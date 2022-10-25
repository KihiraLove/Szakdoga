using UnityEngine;

namespace DataExtractors
{
    public class ForwardCapsuleData : MonoBehaviour
    {
        private static ForwardCapsuleData _instance;

        public static ForwardCapsuleData Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("Forward Capsule Data Extractor is null!");
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
