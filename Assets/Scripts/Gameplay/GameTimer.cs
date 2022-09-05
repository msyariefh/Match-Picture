using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace HiDE.Matcher.Gameplay
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private int _totalTime;
        [SerializeField] private TMP_Text _timerText;
        public Action onTimeOver;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            int _temp = _totalTime;
            while (_temp > 0)
            {
                _timerText.text = $"{_temp}s";
                yield return new WaitForSeconds(1f);
                _temp--;
            }
            onTimeOver?.Invoke();
        }
    }

}
