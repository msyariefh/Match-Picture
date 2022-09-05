using UnityEngine;

namespace HiDE.Matcher.Global
{
    public class Currency : MonoBehaviour
    {
        public static Currency Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public enum Status{SUCCEED, FAILED}

        public Status AddPlayerCoin(int amount)
        {
            return SaveData.Instance.PlayerData.AddCoins(amount) 
                ? Status.SUCCEED : Status.FAILED;
        }

        public Status SpendPlayerCoin(int amount)
        {
            return SaveData.Instance.PlayerData.SpendCoins(amount)
                ? Status.SUCCEED : Status.FAILED;
        }
    }

}
