using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HiDE.Matcher.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;
        //[SerializeField] private Button _exitButton;
        [SerializeField] private string _gameplaySceneName;
        [SerializeField] private string _themeSceneName;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _themeButton.onClick.AddListener(OnThemeButtonClicked);
            //_exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(_gameplaySceneName);
        }
        private void OnThemeButtonClicked()
        {
            SceneManager.LoadScene(_themeSceneName);
        }
        //private void OnExitButtonClicked()
        //{
        //    Application.Quit();
        //}
    }

}


