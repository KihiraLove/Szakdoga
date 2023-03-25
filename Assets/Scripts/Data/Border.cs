using System;
using Enums;
using Managers;
using UnityEngine;

namespace Data
{
    public class Border : MonoBehaviour
    {
        private GameManager _gameManager;
        private UIManager _uiManager;
        private float[] _borderRotationDegrees;
        private ObjectCoordinates _objectCoordinates;
        private PlayerCamRotation _playerCamRotation;
        private BorderFlag _borderFlag;
        private int _pop;
        private double _lastDegree = -9999.0;
        private bool _helperTextCalled;
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
            _borderFlag = BorderFlag.None;
            _pop = pop;
            _helperTextCalled = false;
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
            
            switch (_borderFlag)
            {
                case BorderFlag.None:
                    SetLeftBorder();
                    return;
                case BorderFlag.Left:
                    SetRightBorder();
                    return;
                case BorderFlag.Right:
                    SetUpperBorder();
                    return;
                case BorderFlag.Up:
                    SetLowerBorder();
                    return;
                case BorderFlag.Down:
                case BorderFlag.All:
                default:
                    _gameManager.State = GameState.InGame;
                    _uiManager.borderHelper.ClearBorderText();
                    break;
            }
        }

        private void SetLeftBorder()
        {
            if (!_helperTextCalled)
            {
                _uiManager.borderHelper.SetBorderTextLeft();
                _helperTextCalled = true;
            }
            float yRotation = _playerCamRotation.Y;
            if (yRotation is > 360 or < 180) return;
            if (Math.Abs(_lastDegree - yRotation) < 2.0) 
                _pop--;
            else
            {
                _pop = pop;
                _lastDegree = yRotation;
            }

            if (_pop != 0) return;
            LeftDegree = yRotation;
            _borderFlag = BorderFlag.Left;
            _pop = pop;
            _helperTextCalled = false;
        }

        private void SetRightBorder()
        {
            if (!_helperTextCalled)
            {
                _uiManager.borderHelper.SetBorderTextRight();
                _helperTextCalled = true;
            }
            float yRotation = _playerCamRotation.Y;
            if (yRotation is > 180 or < 0) return;
            if (Math.Abs(_lastDegree - yRotation) < 2.0) 
                _pop--;
            else
            {
                _pop = pop;
                _lastDegree = yRotation;
            }

            if (_pop != 0) return;
            RightDegree = yRotation;
            _borderFlag = BorderFlag.Right;
            _pop = pop;
            _helperTextCalled = false;
        }
        
        private void SetUpperBorder()
        {
            if (!_helperTextCalled)
            {
                _uiManager.borderHelper.SetBorderTextUp();
                _helperTextCalled = true;
            }
            float xRotation = _playerCamRotation.X;
            if (xRotation is > 360 or < 180) return;
            if (Math.Abs(_lastDegree - xRotation) < 2.0) 
                _pop--;
            else
            {
                _pop = pop;
                _lastDegree = xRotation;
            }

            if (_pop != 0) return;
            RightDegree = xRotation;
            _borderFlag = BorderFlag.Up;
            _pop = pop;
            _helperTextCalled = false;
        }

        private void SetLowerBorder()
        {
            if (!_helperTextCalled)
            {
                _uiManager.borderHelper.SetBorderTextDown();
                _helperTextCalled = true;
            }
            float xRotation = _playerCamRotation.X;
            if (xRotation is > 180 or < 0) return;
            if (Math.Abs(_lastDegree - xRotation) < 2.0) 
                _pop--;
            else
            {
                _pop = pop;
                _lastDegree = xRotation;
            }

            if (_pop != 0) return;
            RightDegree = xRotation;
            _borderFlag = BorderFlag.Down;
            _pop = pop;
            _helperTextCalled = false;
        }
        
        public string ConstructDebugString()
        {
            string res = "Pop: " + _pop + System.Environment.NewLine;
            if (_borderFlag >= BorderFlag.Left)
                res = res + "Left Border Set" + System.Environment.NewLine;
            if (_borderFlag >= BorderFlag.Right)
                res = res + "Right Border Set" + System.Environment.NewLine;
            if (_borderFlag >= BorderFlag.Up)
                res = res + "Upper Border Set" + System.Environment.NewLine;
            if (_borderFlag >= BorderFlag.Down)
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