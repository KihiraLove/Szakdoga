using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private PlayerCamRotation _playerCamRotation;
        private GameManager _gameManager;
        private Border _border;

        public bool enableDebugText;
        
        /*
         * 0: none
         * 1: left
         * 2: right
         * 3: up
         * 4: down
         */
        public int borderFlag;
        
        public Text debugText;
        public Text borderHelper;

        private bool _enableBorderHelper;
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("UI Manager not instantiated!");
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
            ClearBorderText();
            _playerCamRotation = PlayerCamRotation.Instance;
            _gameManager = GameManager.Instance;
            _border = Border.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            if (enableDebugText)
            {
                if (!debugText.enabled)
                {
                    debugText.enabled = true;
                }
                debugText.text = ConstructDebugString();
            }
            else
            {
                if(debugText.enabled)
                    debugText.enabled = false;
            }
            
        }

        private string ConstructDebugString()
        {
            String res = "Y rotation: " + _playerCamRotation.Y + System.Environment.NewLine
                         + "X rotation: " + _playerCamRotation.X + System.Environment.NewLine
                         + _border.ConstructDebugString();
            
            return res;
        }

        public void SetBorderTextLeft()
        {
            borderHelper.text = "Please turn your head left," + System.Environment.NewLine + "as far as you can!";
            borderFlag = 1;
        }
        
        public void SetBorderTextRight()
        {
            borderHelper.text = "Please turn your head right," + System.Environment.NewLine + "as far as you can!";
            borderFlag = 2;
        }
        
        public void SetBorderTextUp()
        {
            borderHelper.text = "Please turn your head up," + System.Environment.NewLine + "as far as you can!";
            borderFlag = 3;
        }
        
        public void SetBorderTextDown()
        {
            borderHelper.text = "Please turn your head down," + System.Environment.NewLine + "as far as you can!";
            borderFlag = 4;
        }

        public void ClearBorderText()
        {
            borderHelper.text = "";
            borderFlag = 0;
        }
    }
}
