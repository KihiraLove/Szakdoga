using DataClasses;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    
    public Border Border;
    public CurrentRotation CurrentRotation;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Game Manager is Null!");
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
        Border = new Border();
        CurrentRotation = new CurrentRotation();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentRotation();
    }

    private void UpdateCurrentRotation()
    {
        float y = camera.transform.rotation.eulerAngles.y;
        if (y < 0)
        {
            CurrentRotation.SetCurrentRotationLeft(y);
            CurrentRotation.SetCurrentRotationRight(0f);
        }
        else if (y > 0)
        {
            CurrentRotation.SetCurrentRotationRight(y);
            CurrentRotation.SetCurrentRotationLeft(0);
        }
        else
        {
            CurrentRotation.SetCurrentRotationRight(0);
            CurrentRotation.SetCurrentRotationLeft(0);
        }

        float x = camera.transform.rotation.eulerAngles.x;
        if (x < 0)
        {
            CurrentRotation.SetCurrentRotationDown(x);
            CurrentRotation.SetCurrentRotationUp(0f);
        }
        else if (x > 0)
        {
            CurrentRotation.SetCurrentRotationUp(x);
            CurrentRotation.SetCurrentRotationDown(0);
        }
        else
        {
            CurrentRotation.SetCurrentRotationUp(0);
            CurrentRotation.SetCurrentRotationDown(0);
        }
    }
}
