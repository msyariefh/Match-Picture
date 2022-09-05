using HiDE.Matcher.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HiDE.Matcher.Gameplay
{
    public class TileGroup : MonoBehaviour
    {
        public Action onTilesCleared;
        private float _tileSize;
        [SerializeField] private GameObject _tileTemplate;

        [Header("Grid Configuration")]
        [SerializeField] private int _gridWidth;
        [SerializeField] private int _gridHeight;
        [SerializeField] private float padding;
        [SerializeField] private Transform _topLeft;
        private Camera _camera;

        private GameObject[,] _grid;
        private List<int>[] _gridPool;
        private Sprite[] _theme;
        private int _totalTilesToBeSolved;

        private TileInfo _lastSelectedTile;


        private void Awake()
        {
            _totalTilesToBeSolved = _gridWidth * _gridHeight;
            _lastSelectedTile.Assigned = false;
            _grid = new GameObject[_gridHeight, _gridWidth];
            _gridPool = new List<int>[2];
            _gridPool[0] = new List<int>();
            _gridPool[1] = new List<int>();
            for (int i = 0; i < _gridHeight; i++)
            {
                for(int j = 0; j <_gridWidth; j++)
                {
                    _gridPool[0].Add(i);
                    _gridPool[1].Add(j);
                }
            }

            _camera = Camera.main;
            _tileSize = (_camera.orthographicSize * 2 * _camera.aspect) / _gridWidth;

            _theme = Resources.LoadAll<Sprite>(ThemeDatabase.Instance.ThemeCollections.GetThemeObject(
                SaveData.Instance.PlayerData.CurrentPickedTheme).ResourcePath);
        }

        private void Start()
        {
           
            int _totalObject = ThemeDatabase.Instance.ThemeCollections.GetThemeObject(
                SaveData.Instance.PlayerData.CurrentPickedTheme).TotalObject;
            int _temp = UnityEngine.Random.Range(0, _totalObject);

            int _totalTiles = (_gridHeight * _gridWidth) / 2;

            for (int i = 0; i < _totalTiles; i++)
            {
                if (_temp < _totalObject - 1) _temp++;
                else _temp = 0;

                InstantiateTileObject(_temp);
                InstantiateTileObject(_temp);

            }
        }

        private void InstantiateTileObject(int value)
        {
            var coor = RandomizeTileCoor();
            Vector3 _truePos = new Vector3(
                _topLeft.position.x + coor.X * _tileSize + (_tileSize / 2),
                _topLeft.position.y - coor.Y * _tileSize,
                0
                );
            GameObject _instantiated = Instantiate(_tileTemplate,
                _truePos, Quaternion.identity, _topLeft);
            ITileObject _tileInterface = _instantiated.GetComponent<ITileObject>();
            _tileInterface.SetTileInfo(new TileInfo(value, coor));
            _instantiated.GetComponent<SpriteRenderer>().sprite = _theme[value];
            _instantiated.GetComponent<TileObject>().onTileClicked += TryMatchClickedTiles;
            _grid[coor.Y, coor.X] = _instantiated;
        }


        private void TryMatchClickedTiles(TileInfo tileInfo)
        {
            //if (_lastSelectedTile ==  null) _lastSelectedTile = tileInfo;
            if (_lastSelectedTile.Assigned == false)
            {
                _lastSelectedTile = tileInfo;
                return;
            }

            if (tileInfo.Value == _lastSelectedTile.Value)
            {
                DeactivateTwoTiles(_lastSelectedTile, tileInfo);
            }

            _lastSelectedTile.Assigned = false;
        }

        private void DeactivateTwoTiles(TileInfo tile1, TileInfo tile2)
        {
            _grid[tile1.Coordinate.Y, tile1.Coordinate.X].SetActive(false);
            _grid[tile2.Coordinate.Y, tile2.Coordinate.X].SetActive(false);
            _totalTilesToBeSolved -= 2;
            if (_totalTilesToBeSolved == 0)
            {
                onTilesCleared?.Invoke();
            }
        }

        private Coordinate2D RandomizeTileCoor()
        {
            
            int _x;
            int _y;
            do
            {
                _x = UnityEngine.Random.Range(0, _gridPool[1].Count);
                _y = UnityEngine.Random.Range(0, _gridPool[0].Count);
            } while (_grid[_gridPool[0][_y], _gridPool[1][_x]] != null);
            _x = _gridPool[1][_x];
            _y = _gridPool[0][_y];
            _gridPool[0].Remove(_y);
            _gridPool[1].Remove(_x);

            return new Coordinate2D(_x, _y);
        }
    }

}
