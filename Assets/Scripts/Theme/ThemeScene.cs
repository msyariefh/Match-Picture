using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HiDE.Matcher.Theme
{
    public class ThemeScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked); 
        }

        private void OnBackButtonClicked()
        {
            SceneManager.LoadScene("Home");
        }
    }

}
