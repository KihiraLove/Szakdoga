using System;
using UnityEngine;

namespace DataExtractors
{
    public class DogData : MonoBehaviour
    {
        //Singleton implementation
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

        //Variables
        private ForwardCapsuleData _forwardCapsule;

        private ShiftForwardData _shiftForward;

        private ShiftUpData _shiftUp;
        
        //Properties
        public Vector3 LocalCoordinates => gameObject.transform.localPosition;

        public Vector3 WorldCoordinates => gameObject.transform.position;
        
        //TODO: automatically calculate distance into coordinates
        public float HorizontalX => 50.0f;

        public float HorizontalY => 0.0f;

        public float VerticalX => 50.0f;

        public float VerticalY => 0.0f;
        
        //Functions
        private void Start()
        {
            _forwardCapsule = ForwardCapsuleData.Instance;
            _shiftForward = ShiftForwardData.Instance;
            _shiftUp = ShiftUpData.Instance;
        }
    }
}
