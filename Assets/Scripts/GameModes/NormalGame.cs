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
        private GameObject _currentObject;
        private ExerciseDictionary _exercises;
        private FileHandler _fileHandler;
        private GameManager _game;
        private UIManager _ui;
        private ExerciseChooser _exerciseChooser;
        private bool _isExerciseLoaded = false;
        private int _index = 0;

        public GameObject spherePrefab;

        private void Start()
        {
            _exercises = ExerciseDictionary.Instance;
            _game = GameManager.Instance;
            _ui = UIManager.Instance;
            _exerciseChooser = ExerciseChooser.Instance;
            _fileHandler = new FileHandler();
            _positions = new List<Vector3>();
        }

        private void Update()
        {
            if (_game.State != GameState.InGame) return;
            if (!_isExerciseLoaded)
            {
                LoadExercise();
                _currentObject = _game.SpawnObject(spherePrefab, GetNextVector().Value);
            }
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 rayDirection = ray.direction * 100f;
            
            if (Physics.Raycast(ray.origin, rayDirection, out RaycastHit hit))
            {
                 GameObject o = hit.collider.gameObject;
                _ui.debug.RaycastDebugText = "Ray collided with " + o.name;
                if(o.name == "Sphere(Clone)")
                {
                    NextObject();
                }
            }
        }

        private void NextObject()
        {
            _game.DestroyObject(_currentObject);
            Vector3? nextPos = GetNextVector();
            if (nextPos.HasValue)
            {
                _currentObject = _game.SpawnObject(spherePrefab, nextPos.Value);
                return;
            }
            EndExercise();
        }

        private void EndExercise()
        {
            _isExerciseLoaded = false;
            _game.State = GameState.GameOver;
        }
        
        private Vector3? GetNextVector()
        {
            if (_positions == null || _index >= _positions.Count)
            {
                _index = 0;
                return null;
            }
            Vector3 nextVector = _positions[_index];
            _index++;
            return nextVector;
        }

        private void LoadExercise()
        {
            _positions = _exercises.GetExercise(_exerciseChooser.ChosenExercise);
            Debug.Log("exercise loaded"); 
            _isExerciseLoaded = true;
        }

        public Vector3 CalculateNewPosition(Vector3 playerPosition, Vector3 originPosition, Vector3 baseBorderPosition, Vector3 newDistancePosition, Vector3 baseObjectPosition)
        {
            // Calculate the distances between the player and origin positions, and between the base distance and new distance positions
            float playerOriginDistance = Vector3.Distance(playerPosition, originPosition);
            float baseNewDistance = Vector3.Distance(baseBorderPosition, newDistancePosition);

            // Calculate the proportion of distance between the player and origin positions that the base distance position represents
            float baseProportion = Vector3.Distance(playerPosition, baseBorderPosition) / playerOriginDistance;

            // Calculate the new position based on the proportion of distance between the player and origin positions represented by the new distance position
            Vector3 newPosition = playerPosition + (newDistancePosition - playerPosition) * (baseProportion * baseNewDistance / Vector3.Distance(playerPosition, newDistancePosition));

            // Move the base object to the new position
            Vector3 baseOffset = baseObjectPosition - baseBorderPosition;
            Vector3 newBasePosition = newPosition + baseOffset;

            return newBasePosition;
        }
    }
}
