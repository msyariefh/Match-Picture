using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HiDE.Matcher.Global
{
    [System.Serializable]
    public class ThemeObject 
    {
        [SerializeField] private int _themeId;
        [SerializeField] private string _resourcePath;
        [SerializeField] private int _price;
        [SerializeField] private int _totalObjects = 5;

        public int ThemeId => _themeId;
        public string ResourcePath => _resourcePath;
        public int Price => _price;
        public int TotalObject => _totalObjects;
    }

}
