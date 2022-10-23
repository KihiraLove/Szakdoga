using UnityEngine;

namespace DataClasses
{
    public class CurrentRotation
    {
        private float[] _rotations;

        public CurrentRotation()
        {
            _rotations = new float[4];
        }

        public float GetCurrentRotationLeft()
        {
            return _rotations[0];
        }

        public float GetCurrentRotationRight()
        {
            return _rotations[1];
        }

        public float GetCurrentRotationUp()
        {
            return _rotations[2];
        }

        public float GetCurrentRotationDown()
        {
            return _rotations[3];
        }

        public void SetCurrentRotationLeft(float val)
        {
            _rotations[0] = val;
        }
        
        public void SetCurrentRotationRight(float val)
        {
            _rotations[1] = val;
        }
        
        public void SetCurrentRotationUp(float val)
        {
            _rotations[2] = val;
        }
        
        public void SetCurrentRotationDown(float val)
        {
            _rotations[3] = val;
        }
    }
}