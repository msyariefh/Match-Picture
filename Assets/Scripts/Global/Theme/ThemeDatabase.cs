using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Global
{
    public class ThemeDatabase : MonoBehaviour
    {
        public static ThemeDatabase Instance { get; private set; }
        [SerializeField] private ThemeCollections _themeCollections;

        public ThemeCollections ThemeCollections => _themeCollections;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;

            DontDestroyOnLoad(gameObject);
        }

    }
}

