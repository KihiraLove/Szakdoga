using System;
using Enums;
using Managers;
using UnityEngine;

namespace Data
{
    public class Border : MonoBehaviour
    {
        private bool _leftBorderSet;
        private bool _rightBorderSet;
        private bool _upperBorderSet;
        private bool _lowerBorderSet;
        private GameManager _gameManager;
        private UIManager _uiManager;
        private float[] _borderRotationDegrees;
        private ObjectCoordinates _objectCoordinates;

        private static Border _instance;

        public static Border Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Singleton for border calculations error");
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
            _borderRotationDegrees = new float[] { 0, 0, 0, 0 };
            _objectCoordinates = ObjectCoordinates.Instance;
            _gameManager = GameManager.Instance;
            _uiManager = UIManager.Instance;
            _leftBorderSet = false;
            _rightBorderSet = false;
            _upperBorderSet = false;
            _lowerBorderSet = false;
        }

        // Update is called once per frame
        void Update()
        {
            SetBorders();
        }

        private void SetBorders()
        {
            if (_gameManager.State != GameState.BorderCalculation)
                return;
            if (!_leftBorderSet)
            {
                SetLeftBorder();
                return;
            }
            if (!_rightBorderSet)
            {
                SetRightBorder();
                return;
            }
            if (!_upperBorderSet)
            {
                SetUpperBorder();
                return;
            }
            if (!_lowerBorderSet)
            {
                SetLowerBorder();
                return;
            }
            _gameManager.State = GameState.InGame;
        }

        private void SetLeftBorder()
        {
            _uiManager.SetBorderTextLeft();
        }

        private void SetRightBorder()
        {
            _uiManager.SetBorderTextRight();
        }
        
        private void SetUpperBorder()
        {
            _uiManager.SetBorderTextUp();
        }
        
        private void SetLowerBorder()
        {
            _uiManager.SetBorderTextDown();
        }

        public Vector3 LeftBorder { get; private set; }

        public Vector3 RightBorder { get; private set; }

        public Vector3 UpperBorder { get; private set; }

        public Vector3 LowerBorder { get; private set; }

        public float LeftDegree
        {
            get => _borderRotationDegrees[0];
            set
            {
                _borderRotationDegrees[0] = value;
                double x = _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Cos(value) - _objectCoordinates.ObjectSpawnDistanceFromPlayerX * Math.Sin(value);
                double z = _objectCoordinates.ObjectSpawnDistanceFromPlayerX * Math.Cos(value) + _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Sin(value);
                LeftBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float RightDegree
        {
            get => _borderRotationDegrees[1];
            set
            {
                _borderRotationDegrees[1] = value;
                double x = _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Cos(value) - _objectCoordinates.ObjectSpawnDistanceFromPlayerX * Math.Sin(value);
                double z = _objectCoordinates.ObjectSpawnDistanceFromPlayerX * Math.Cos(value) + _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Sin(value);
                RightBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float UpperDegree
        {
            get => _borderRotationDegrees[2];
            set
            {
                _borderRotationDegrees[2] = value;
                double x = _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Cos(value) - _objectCoordinates.ObjectSpawnDistanceFromPlayerY * Math.Sin(value);
                double z = _objectCoordinates.ObjectSpawnDistanceFromPlayerY * Math.Cos(value) + _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Sin(value);
                UpperBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float LowerDegree
        {
            get => _borderRotationDegrees[3];
            set
            {
                _borderRotationDegrees[3] = value;
                double x = _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Cos(value) - _objectCoordinates.ObjectSpawnDistanceFromPlayerY * Math.Sin(value);
                double z = _objectCoordinates.ObjectSpawnDistanceFromPlayerY * Math.Cos(value) + _objectCoordinates.ObjectSpawnDistanceFromPlayerZ * Math.Sin(value);
                LowerBorder = new Vector3((float)x, 0, (float)z);
            }
        }
    }
}