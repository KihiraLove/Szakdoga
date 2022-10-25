using Collectors;
using DataClasses;
using DataExtractors;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Border Border;
    public CurrentRotation CurrentRotation;
    public CoordinateDataCollector coordinateData;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
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
        coordinateData = CoordinateDataCollector.Instance;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
