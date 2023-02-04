using UnityEngine;

namespace Data
{
    public class PlayerCamRotation : MonoBehaviour
    {
        private float[] _rotationsInDegree;
        
        private static PlayerCamRotation _instance;

        public static PlayerCamRotation Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Can't instantiate object to get player camera rotation");
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        
        // Start is called before the first frame update
        void Start()
        {                                       //y, x
            _rotationsInDegree = new float[] { 0, 0 };
        }
        
        public void UpdateRotation()
        {
            Vector3 currentAngles = gameObject.transform.rotation.eulerAngles;
            _rotationsInDegree[0] = currentAngles.y;
            _rotationsInDegree[1] = currentAngles.x;
        }

        public float Y => _rotationsInDegree[0];

        public float X => _rotationsInDegree[1];
    }
}
