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
        private PlayerCamRotation _playerCamRotation;

        private int _pop;
        private double _lastDegree = -9999.0;

        public int pop;

        private static Border _instance;

        public static Border Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Border singleton not instantiated!");
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
            _playerCamRotation = PlayerCamRotation.Instance;
            _leftBorderSet = false;
            _rightBorderSet = false;
            _upperBorderSet = false;
            _lowerBorderSet = false;
            _pop = pop;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            SetBorders();
        }

        private void SetBorders()
        {
            if (_gameManager.State != GameState.BorderCalculation)
                return;
            if (_lastDegree < -9998.0)
                _lastDegree = _playerCamRotation.X;
            
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
            _uiManager.ClearBorderText();
        }

        private void SetLeftBorder()
        {
            if(_uiManager.borderFlag != 1)
                _uiManager.SetBorderTextLeft();
            if (_playerCamRotation.X < 0) ;
            if (Math.Abs(_lastDegree - _playerCamRotation.X) < 2.0 && _pop-- != 0)
                return;
            if (_pop > 0)
            {
                _pop = pop;
                _lastDegree = _playerCamRotation.X;
            }
            else
            {
                LeftDegree = _playerCamRotation.X;
                _leftBorderSet = true;
                _pop = pop;
            }
        }

        private void SetRightBorder()
        {
            if(_uiManager.borderFlag != 2)
                _uiManager.SetBorderTextRight();
            if (Math.Abs(_lastDegree - _playerCamRotation.X) < 2.0 && _pop-- != 0)
                return;
            if (_pop > 0)
            {
                _pop = pop;
                _lastDegree = _playerCamRotation.X;
            }
            else
            {
                RightDegree = _playerCamRotation.X;
                _rightBorderSet = true;
                _lastDegree = _playerCamRotation.Y;
                _pop = pop;
            }
        }
        
        private void SetUpperBorder()
        {
            if(_uiManager.borderFlag != 3)
                _uiManager.SetBorderTextUp();
            if (Math.Abs(_lastDegree - _playerCamRotation.Y) < 2.0 && _pop-- != 0)
                return;
            if (_pop > 0)
            {
                _pop = pop;
                _lastDegree = _playerCamRotation.Y;
            }
            else
            {
                UpperDegree = _playerCamRotation.Y;
                _upperBorderSet = true;
                _pop = pop;
            }
        }

        private void SetLowerBorder()
        {
            if(_uiManager.borderFlag != 4)
                _uiManager.SetBorderTextDown();
            if (Math.Abs(_lastDegree - _playerCamRotation.Y) < 2.0 && _pop-- != 0)
                return;
            if (_pop > 0)
            {
                _pop = pop;
                _lastDegree = _playerCamRotation.Y;
            }
            else
            {
                LowerDegree = _playerCamRotation.Y;
                _lowerBorderSet = true;
                _pop = pop;
            }
        }
        
        public String ConstructDebugString()
        {
            String res = "Pop: " + _pop + System.Environment.NewLine;
            if (_leftBorderSet)
                res = res + "Left Border Set" + System.Environment.NewLine;
            if (_rightBorderSet)
                res = res + "Right Border Set" + System.Environment.NewLine;
            if (_upperBorderSet)
                res = res + "Upper Border Set" + System.Environment.NewLine;
            if (_lowerBorderSet)
                res = res + "Lower Border Set";
            return res;
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