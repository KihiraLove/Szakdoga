using UnityEngine;

namespace DataClasses
{
    public class CurrentRotation
    {
        private readonly float[] _rotationsInDegree;

        public CurrentRotation()
        {                               //y, x
            _rotationsInDegree = new float[2] { 0, 0 };
        }

        public float Y
        {
            get => _rotationsInDegree[0];
            set => _rotationsInDegree[0] = value;
        }
        
        public float X
        {
            get => _rotationsInDegree[1];
            set => _rotationsInDegree[1] = value;
        }
    }
}