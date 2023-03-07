 using Managers;
 using UnityEngine;

namespace Controllers
{
    public class CamControlPC : MonoBehaviour
    {
        public float senX;
        public float senY;

        private float _xRotation;
        private float _yRotation;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            RotateCam();
        }

        private void RotateCam()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

            _yRotation += mouseX;
            _xRotation -= mouseY;
        
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        }


    }
}
