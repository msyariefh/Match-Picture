using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Global
{
    public class PlayerData
    {
        private int _currentPickedThemeId;
        private int _totalGold;
        private List<int> _ownedThemes;

        public PlayerData()
        {
            _currentPickedThemeId = 0;
            _totalGold = 0;
            _ownedThemes = new List<int>();
        }

        public int CurrentPickedTheme => _currentPickedThemeId;
        public int TotalGold => _totalGold;
        public List<int> OwnedThemes => _ownedThemes;

        public bool AddCoins(int amount)
        {
            _totalGold += amount;

            return true;
        }
        public void AddNewOwnedTheme(int themeId)
        {
            if (_ownedThemes.Contains(themeId)) return;
            _ownedThemes.Add(themeId);
        }
        public bool SpendCoins(int amount)
        {
            if (_totalGold - amount < 0) return false;
            _totalGold -= amount;
            return true;
        }
    }
}
