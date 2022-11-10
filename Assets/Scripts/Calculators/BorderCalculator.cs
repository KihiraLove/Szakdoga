using Managers;
using UnityEngine;

namespace Calculators
{
    public class BorderCalculator : MonoBehaviour
    {
        private float _lastRotation;
        private int _popCounter;
        private bool _left;
        private bool _right;
        private bool _upper;
        private bool _lower;
        private GameManager _gameManager;
        private UIManager _uiManager;

        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;
            _uiManager = UIManager.Instance;
            _popCounter = 60;
            _lastRotation = gameObject.transform.rotation.eulerAngles.y;
            _left = false;
            _right = false;
            _upper = false;
            _lower = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!(_left && _right && _lower && _upper))
            {
                if (!_left)
                {
                    if (_uiManager.borderFlag == 0)
                    {
                        _uiManager.SetBorderTextLeft();
                        _uiManager.borderFlag++;
                    }
                } else if(!_right)
                {
                    _uiManager.SetBorderTextRight();
                } else if (!_upper)
                {
                    _uiManager.SetBorderTextUp();
                }else if (!_lower)
                {
                    _uiManager.SetBorderTextDown();
                }
            }
        }
    }
}