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
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
