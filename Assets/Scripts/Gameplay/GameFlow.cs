using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiDE.Matcher.Gameplay
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameTimer _timer;
        [SerializeField] private TileGroup _tileGroup;
        public enum Result { WIN, LOSE};
        private void OnEnable()
        {
            _tileGroup.onTilesCleared += () => SetGameOverState(Result.WIN);
            _timer.onTimeOver += () => SetGameOverState(Result.LOSE);
        }

        private void OnDisable()
        {
            _tileGroup.onTilesCleared -= () => SetGameOverState(Result.WIN);
            _timer.onTimeOver -= () => SetGameOverState(Result.LOSE);
        }

        private void SetGameOverState(Result result)
        {
            switch (result)
            {
                case Result.WIN:
                    Debug.Log("WIN");
                    break;
                case Result.LOSE:
                    Debug.Log("LOSE");
                    break;
            }
        }
    }

}
