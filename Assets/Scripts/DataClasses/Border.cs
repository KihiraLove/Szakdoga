using System;
using DataExtractors;
using UnityEngine;

namespace DataClasses
{
    public class Border
    {
        private readonly float[] _borderRotationDegrees;
        private DogData _dog;

        public Border()
        {
            _borderRotationDegrees = new float[4] { 0, 0, 0, 0 };
            _dog = DogData.Instance;
        }

        public Vector3 LeftBorder { get; private set; }

        public Vector3 RightBorder { get; private set; }

        public Vector3 UpperBorder { get; private set; }

        public Vector3 LowerBorder { get; private set; }

        public float LeftDegree
        {
            get => _borderRotationDegrees[0];
            set
            {
                _borderRotationDegrees[0] = value;
                double x = _dog.HorizontalX * Math.Cos(value) - _dog.HorizontalY * Math.Sin(value);
                double z = _dog.HorizontalY * Math.Cos(value) + _dog.HorizontalX * Math.Sin(value);
                LeftBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float RightDegree
        {
            get => _borderRotationDegrees[1];
            set
            {
                _borderRotationDegrees[1] = value;
                double x = _dog.HorizontalX * Math.Cos(value) - _dog.HorizontalY * Math.Sin(value);
                double z = _dog.HorizontalY * Math.Cos(value) + _dog.HorizontalX * Math.Sin(value);
                RightBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float UpperDegree
        {
            get => _borderRotationDegrees[2];
            set
            {
                _borderRotationDegrees[2] = value;
                double x = _dog.VerticalX * Math.Cos(value) - _dog.VerticalY * Math.Sin(value);
                double z = _dog.VerticalY * Math.Cos(value) + _dog.VerticalX * Math.Sin(value);
                UpperBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float LowerDegree
        {
            get => _borderRotationDegrees[3];
            set
            {
                _borderRotationDegrees[3] = value;
                double x = _dog.VerticalX * Math.Cos(value) - _dog.VerticalY * Math.Sin(value);
                double z = _dog.VerticalY * Math.Cos(value) + _dog.VerticalX * Math.Sin(value);
                LowerBorder = new Vector3((float)x, 0, (float)z);
            }
        }
    }
}