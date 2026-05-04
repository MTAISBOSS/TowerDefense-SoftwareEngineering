using System;
using Events;
using EventSystem;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private EventBinding<GameResultEvent> gameResultEvent;
        private GameResultEvent _result;

        private void OnEnable()
        {
            gameResultEvent = new EventBinding<GameResultEvent>(HandleGameOver);
            EventBus<GameResultEvent>.Register(gameResultEvent);
        }
        private void OnDisable()
        {
            EventBus<GameResultEvent>.Unregister(gameResultEvent);
        }
        private void HandleGameOver(GameResultEvent result)
        {
            _result = result;
            Invoke($"Handle{result.state.ToString()}",0);
        }

        void HandleVictory()
        {
            Utilities.Logger.Log($"Victory {_result}");
        }
        void HandleDefeated()
        {
            Utilities.Logger.Log("Defeated {_result}");
        }
    }
}