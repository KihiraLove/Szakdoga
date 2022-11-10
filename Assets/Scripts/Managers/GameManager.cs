using Collectors;
using DataClasses;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public Border Border;
        public CurrentRotation CurrentRotation;
        public CoordinateDataCollector coordinateData;

        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Game Manager got sucked into the void!");
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
            Border = new Border();
            CurrentRotation = new CurrentRotation();
            coordinateData = CoordinateDataCollector.Instance;
        }
    }
}
