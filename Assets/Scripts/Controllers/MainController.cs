﻿using UnityEngine;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        private CamControlPC _pcControl;
        private CamControlVR _vrControl;

        public float senX;
        public float senY;
        
        private static MainController _instance;

        private static MainController Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("Camera Control singleton is not instantiated");
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor or RuntimePlatform.WindowsPlayer:
                    _pcControl = gameObject.AddComponent<CamControlPC>();
                    _pcControl.SetSensitivity(senX, senY);
                    break;
                case RuntimePlatform.Android:
                    _vrControl = gameObject.AddComponent<CamControlVR>();
                    break;
                default:
                    Application.Quit();
                    break;
            }
        }

        private void Update()
        {
            
        }

        public bool IsMainInput()
        {
            return Input.GetMouseButtonDown(0) || Input.GetButton("Tap");
        }
    }
}