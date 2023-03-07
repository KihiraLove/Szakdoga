﻿using System;
using Managers;
using UnityEngine;

namespace Data
{
    public class RayCast : MonoBehaviour
    {
        public Camera cam;

        private UIManager _ui;
        private GameManager _game;

        private void Start()
        {
            _ui = UIManager.Instance;
            _game = GameManager.Instance;
        }

        private void Update()
        {
            CheckForRayHit();
        }

        private void CheckForRayHit()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 rayOrigin = cam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

                if (Physics.Raycast(rayOrigin, cam.transform.forward, out RaycastHit hit))
                {
                    var o = hit.collider.gameObject;
                    _ui.RaycastDebugText = "Ray collided with " + o.name;
                    switch (o.name)
                    {
                        case "DebugClickBox":
                            _game.SwitchDebugMode();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}