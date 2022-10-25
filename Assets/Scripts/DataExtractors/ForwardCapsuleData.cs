using System;
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
