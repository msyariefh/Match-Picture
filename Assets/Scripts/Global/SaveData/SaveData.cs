using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Global
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance { get; private set; }
        public PlayerData PlayerData { get; private set; }
        private const string DATA_KEY = "MatcherPlayerData";

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;

            InitPlayerData();
            DontDestroyOnLoad(gameObject);
        }

        private void InitPlayerData()
        {
            if (!PlayerPrefs.HasKey(DATA_KEY))
            {
                PlayerData = new();
                SavePlayerData();
            }
            else
            {
                PlayerData = JsonUtility.FromJson<PlayerData>(
                    PlayerPrefs.GetString(DATA_KEY));
            }
        }

        public void SavePlayerData()
        {
            PlayerPrefs.SetString(DATA_KEY, JsonUtility.ToJson(PlayerData));
        }


    }

}
