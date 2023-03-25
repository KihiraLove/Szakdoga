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
        private UIManager _ui;

        public GameObject shiftForward;
        public GameObject menuShift;
        
        public GameObject debugPrefab;
        public GameObject menuPrefab;

        private GameObject _menu;
        private GameObject _debugCapsules;

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
            _state = GameState.Menu;
            _ui = UIManager.Instance;
            
            _menu = Instantiate(menuPrefab, menuShift.transform.position, Quaternion.identity);
            SwitchDebugMode();
        }

        private void Update()
        {
            _playerCamRotation.UpdateRotation();
            if (State == GameState.Menu && !_menu)
            {
                _menu = Instantiate(menuPrefab, menuShift.transform.position, Quaternion.identity);
            }
            else if (State != GameState.Menu && _menu)
            {
                Destroy(_menu);
            }
        }

        public GameState State
        {
            get => _state;
            set => _state = value;
        }

        public void SwitchDebugMode()
        {
            if (_ui.debug.Enabled)
            {
                Destroy(_debugCapsules);
            }
            else
            {
                _debugCapsules = Instantiate(debugPrefab, shiftForward.transform.position, Quaternion.identity);
            }
            _ui.debug.SwitchDebugMode();
        }
    }
}
