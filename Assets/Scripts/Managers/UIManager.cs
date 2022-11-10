using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private GameManager _manager;

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
                    Debug.LogError("UI Manager died for some reason!");
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
            _manager = GameManager.Instance;
            ClearBorderText();
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
            return "Y rotation: " + _manager.CurrentRotation.Y + System.Environment.NewLine
                   + "X rotation: " + _manager.CurrentRotation.X;
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
