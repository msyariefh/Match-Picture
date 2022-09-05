using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Gameplay
{
    public class TileObject : MonoBehaviour, IRaycastable, ITileObject
    {
        public Action<TileInfo> onTileClicked;
        private TileInfo _tileInfo;

        public TileInfo GetTileInfo()
        {
            return _tileInfo;
        }

        public void OnRaycasted()
        {
            onTileClicked?.Invoke(_tileInfo);
        }

        public void SetTileInfo(TileInfo tileInfo)
        {
            _tileInfo = tileInfo;
        }
    }

}
