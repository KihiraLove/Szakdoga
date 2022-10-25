using UnityEngine;

namespace DataExtractors
{
    public class RotationData : MonoBehaviour
    {
        private GameManager _manager;
        
        // Start is called before the first frame update
        void Start()
        {
            _manager = GameManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 currentAngles = gameObject.transform.rotation.eulerAngles;
            _manager.CurrentRotation.Y = currentAngles.y;
            _manager.CurrentRotation.X = currentAngles.x;
        }
    }
}
