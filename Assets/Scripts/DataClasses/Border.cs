using UnityEngine;

namespace DataClasses
{
    public class Border
    {
        private float[] _borderRotations;

        public Border()
        {
            _borderRotations = new float[4];
        }
        
        public float GetBorderRotationLeft()
        {
            return _borderRotations[0];
        }

        public float GetBorderRotationRight()
        {
            return _borderRotations[1];
        }

        public float GetBorderRotationUp()
        {
            return _borderRotations[2];
        }

        public float GetBorderRotationDown()
        {
            return _borderRotations[3];
        }

        public void SetBorderRotationLeft(float val)
        {
            _borderRotations[0] = val;
        }
        
        public void SetBorderRotationRight(float val)
        {
            _borderRotations[1] = val;
        }
        
        public void SetBorderRotationUp(float val)
        {
            _borderRotations[2] = val;
        }
        
        public void SetBorderRotationDown(float val)
        {
            _borderRotations[3] = val;
        }
    }
}