using System;
using System.Collections.Generic;
using Data;
using Enums;
using Managers;
using Managers.SubManagers;
using UnityEngine;

namespace GameModes
{
    public class NormalGame : MonoBehaviour
    {

        private List<Vector3> _positions;
        private GameObject _currentObjects;
        private ExerciseDictionary _exercises;
        private FileHandler _fileHandler;
        private GameManager _game;
        private UIManager _ui;
        private bool _isExerciseChosen = true;
        private int _chosenExercise = -1;
        private bool _isExerciseLoaded = false;

        public GameObject spherePrefab;
        
        private void Start()
        {
            _exercises = ExerciseDictionary.Instance;
            _game = GameManager.Instance;
            _ui = UIManager.Instance;
            _fileHandler = new FileHandler();
            _objects = new List<GameObject>();
        }

        private void Update()
        {
            if (!(_game.State == GameState.InGame && _isExerciseChosen)) return;
            if (!_isExerciseLoaded)
            {
                LoadExercise();
            }
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 rayDirection = ray.direction * 100f;
            
            if (Physics.Raycast(ray.origin, rayDirection, out RaycastHit hit))
            {
                 GameObject o = hit.collider.gameObject;
                _ui.debug.RaycastDebugText = "Ray collided with " + o.name;
                if(o.name == "Sphere")
                {
                    
                }
            }
        }
        
        public int ChosenExercise
        {
            get => _chosenExercise;
            set = _chosenExercise = value;
        }

        private void LoadExercise()
        {
            foreach (Vector3 vector in _exercises.GetExercise(_chosenExercise))
            {
                _objects.Add(obj);
            }

                Debug.Log("exercise loaded");
                _isExerciseLoaded = true;
        }

        public Vector3 CalculateNewPosition(Vector3 playerPosition, Vector3 originPosition, Vector3 baseDistancePosition, Vector3 newDistancePosition, Vector3 baseObjectPosition)
        {
            // Calculate the distances between the player and origin positions, and between the base distance and new distance positions
            float playerOriginDistance = Vector3.Distance(playerPosition, originPosition);
            float baseNewDistance = Vector3.Distance(baseDistancePosition, newDistancePosition);

            // Calculate the proportion of distance between the player and origin positions that the base distance position represents
            float baseProportion = Vector3.Distance(playerPosition, baseDistancePosition) / playerOriginDistance;

            // Calculate the new position based on the proportion of distance between the player and origin positions represented by the new distance position
            Vector3 newPosition = playerPosition + (newDistancePosition - playerPosition) * (baseProportion * baseNewDistance / Vector3.Distance(playerPosition, newDistancePosition));

            // Move the base object to the new position
            Vector3 baseOffset = baseObjectPosition - baseDistancePosition;
            Vector3 newBasePosition = newPosition + baseOffset;

            return newBasePosition;
        }
    }
}
