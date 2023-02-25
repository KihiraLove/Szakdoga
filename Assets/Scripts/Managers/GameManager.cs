using Data;
using Enums;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private ObjectCoordinates _objectCoordinates;
        private PlayerCamRotation _playerCamRotation;
        private Border _border;
        private GameState _state;

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
            _objectCoordinates = ObjectCoordinates.Instance;
            _playerCamRotation = PlayerCamRotation.Instance;
            _border = Border.Instance;
            _state = GameState.BorderCalculation;
        }

        private void Update()
        {
            _playerCamRotation.UpdateRotation();
        }

        public GameState State
        {
            get => _state;
            set => _state = value;
        }
    }
}
