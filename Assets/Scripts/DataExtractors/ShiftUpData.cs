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
                    Debug.LogError("Shift Up Data Extractor is null!");
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
