using DataExtractors;
using UnityEngine;

namespace Collectors
{
    public class CoordinateDataCollector : MonoBehaviour
    {
        //Singleton implementation
        private static CoordinateDataCollector _instance;
        public static CoordinateDataCollector Instance
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

        private DogData _dogData;
        
        //Properties
        public float HorizontalX => _shiftForward.LocalCoordinates.z + _forwardCapsule.LocalCoordinates.z;

        public float HorizontalY => _shiftForward.LocalCoordinates.x + _forwardCapsule.LocalCoordinates.x;

        public float VerticalX => _shiftForward.LocalCoordinates.z + _forwardCapsule.LocalCoordinates.z;

        public float VerticalY => _shiftForward.LocalCoordinates.y + _forwardCapsule.LocalCoordinates.y;
        
        //Functions
        private void Start()
        {
            _forwardCapsule = ForwardCapsuleData.Instance;
            _shiftForward = ShiftForwardData.Instance;
            _shiftUp = ShiftUpData.Instance;
            _dogData = DogData.Instance;
        }
    }
}
