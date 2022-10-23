using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _manager;

    public Text debugText;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("UI Manager is null");
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
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateText();
    }

    private void UpdateText()
    {
        debugText.text = ConstructDebugString();
    }

    private string ConstructDebugString()
    {
        return "Left rotation: " + _manager.CurrentRotation.GetCurrentRotationLeft() 
               + "Right rotation: " + _manager.CurrentRotation.GetCurrentRotationRight() 
               + "Upper rotation: " + _manager.CurrentRotation.GetCurrentRotationUp()  
               + "Lower rotation: " + _manager.CurrentRotation.GetCurrentRotationDown();
    }
}
