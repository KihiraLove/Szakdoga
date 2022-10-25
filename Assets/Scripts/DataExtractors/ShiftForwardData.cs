using UnityEngine;

namespace DataExtractors
{
    public class ShiftForwardData : MonoBehaviour
    {
        private static ShiftForwardData _instance;

        public static ShiftForwardData Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("Shift Forward Data Extractor is null!");
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
