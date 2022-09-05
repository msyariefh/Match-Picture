using HiDE.Matcher.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Theme
{
    public class ThemeList : MonoBehaviour
    {
        [SerializeField] private Transform _listContainer;
        [SerializeField] private GameObject _listTemplate;


        private void InitThemeList()
        {
            foreach (ThemeObject theme in 
                ThemeDatabase.Instance.ThemeCollections.ThemeObjects)
            {

            }
        }

        private void InstantiateOwnedTheme()
        {

        }
    }

}
