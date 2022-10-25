using System;
using Collectors;
using UnityEngine;

namespace DataClasses
{
    public class Border
    {
        private readonly float[] _borderRotationDegrees;
        private readonly CoordinateDataCollector _coordinateData;

        public Border()
        {
            _borderRotationDegrees = new float[] { 0, 0, 0, 0 };
            _coordinateData = CoordinateDataCollector.Instance;
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
                double x = _coordinateData.HorizontalX * Math.Cos(value) - _coordinateData.HorizontalY * Math.Sin(value);
                double z = _coordinateData.HorizontalY * Math.Cos(value) + _coordinateData.HorizontalX * Math.Sin(value);
                LeftBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float RightDegree
        {
            get => _borderRotationDegrees[1];
            set
            {
                _borderRotationDegrees[1] = value;
                double x = _coordinateData.HorizontalX * Math.Cos(value) - _coordinateData.HorizontalY * Math.Sin(value);
                double z = _coordinateData.HorizontalY * Math.Cos(value) + _coordinateData.HorizontalX * Math.Sin(value);
                RightBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float UpperDegree
        {
            get => _borderRotationDegrees[2];
            set
            {
                _borderRotationDegrees[2] = value;
                double x = _coordinateData.VerticalX * Math.Cos(value) - _coordinateData.VerticalY * Math.Sin(value);
                double z = _coordinateData.VerticalY * Math.Cos(value) + _coordinateData.VerticalX * Math.Sin(value);
                UpperBorder = new Vector3((float)x, 0, (float)z);
            }
        }
        
        public float LowerDegree
        {
            get => _borderRotationDegrees[3];
            set
            {
                _borderRotationDegrees[3] = value;
                double x = _coordinateData.VerticalX * Math.Cos(value) - _coordinateData.VerticalY * Math.Sin(value);
                double z = _coordinateData.VerticalY * Math.Cos(value) + _coordinateData.VerticalX * Math.Sin(value);
                LowerBorder = new Vector3((float)x, 0, (float)z);
            }
        }
    }
}