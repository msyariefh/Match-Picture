using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Global
{
    [CreateAssetMenu]
    public class ThemeCollections : ScriptableObject
    {
        [SerializeField] private ThemeObject[] _themeObjects;

        public ThemeObject[] ThemeObjects => _themeObjects;
        public ThemeObject GetThemeObject(int id)
        {
            return System.Array.Find(_themeObjects, theme => theme.ThemeId == id);
        }
    }

}
