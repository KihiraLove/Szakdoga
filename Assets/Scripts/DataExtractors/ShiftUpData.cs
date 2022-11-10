using UnityEngine;

namespace DataExtractors
{
    public class ShiftUpData : MonoBehaviour
    {
        private static ShiftUpData _instance;

        public static ShiftUpData Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("Shift Up Data Extractor got kidnapped!");
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
