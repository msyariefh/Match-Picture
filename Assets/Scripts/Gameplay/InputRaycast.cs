using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Gameplay
{
    public class InputRaycast : MonoBehaviour
    {
        public Action<TileInfo, TileInfo> onTileClicked;
        [SerializeField] LayerMask _gameplayLayer;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastObject(Input.mousePosition);
            }
        }

        private void RaycastObject(Vector2 screenPosition)
        {
            Vector2 _worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
            RaycastHit2D _hit = Physics2D.Raycast(_worldPosition, 
                Vector2.zero, 1f, _gameplayLayer);
            if (_hit.collider != null)
            {
                IRaycastable _tileRaycastObj = _hit.collider.GetComponent<IRaycastable>();
                _tileRaycastObj?.OnRaycasted();
            }
        }
    }

}
