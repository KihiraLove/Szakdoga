using Data;
using Enums;
using Managers;
using UnityEngine;

namespace GameModes
{
    public class EditMode : MonoBehaviour
    {
        private GameObject[] _objects;
        private GameManager _game;
        private PlayerCamRotation _camRotation;
        private Border _border;
        private void Start()
        {
            _game = GameManager.Instance;
            _camRotation = PlayerCamRotation.Instance;
            _border = Border.Instance;
        }

        private void Update()
        {
            if(!(_game.State == GameState.EditMode && Input.GetMouseButtonDown(0))) return;
             
        }
    }
}