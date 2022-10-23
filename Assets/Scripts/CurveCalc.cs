using UnityEngine;

public class CurveCalc : MonoBehaviour
{
    private float _lastRotation;
    private int _popCounter;
    private GameManager _manager;
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameManager.Instance;
        _popCounter = 60;
        _lastRotation = gameObject.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool LookLeft()
    {
        if (!StaysInYRange()) return false;
        
        return true;
    }

    private bool StaysInYRange()
    {
        float currentAnglesY = gameObject.transform.rotation.eulerAngles.y;
        float lowerRange = currentAnglesY - 3;
        float upperRange = currentAnglesY + 3;

        if (lowerRange < _lastRotation && _lastRotation < upperRange)
        {
            if (_popCounter <= 0) return true;
            _popCounter--;
            return false;
        }

        return true;
    }

}
