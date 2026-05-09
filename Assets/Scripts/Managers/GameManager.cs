using System;
using Events;
using EventSystem;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private EventBinding<GameEndedEvent> gameEndedEvent;
        private EventBinding<GameStartedEvent> gameStartedEvent;
        private GameEndedEvent endedResult;
        private bool isGameRunning;

        private void OnEnable()
        {
            gameEndedEvent = new EventBinding<GameEndedEvent>(HandleGameOver);
            gameStartedEvent = new EventBinding<GameStartedEvent>(StartGame);
            
            EventBus<GameEndedEvent>.Register(gameEndedEvent);
            EventBus<GameStartedEvent>.Register(gameStartedEvent);
        }
        private void OnDisable()
        {
            EventBus<GameEndedEvent>.Unregister(gameEndedEvent);
            EventBus<GameStartedEvent>.Unregister(gameStartedEvent);
        }

        private void StartGame()
        {
            isGameRunning = true;
        }
        private void HandleGameOver(GameEndedEvent endedResult)
        {
            this.endedResult = endedResult;
            isGameRunning = false;
            Invoke($"Handle{endedResult.state.ToString()}",0);
        }

        void HandleVictory()
        {
            Utilities.Logger.Log($"Victory {endedResult}");
        }
        void HandleDefeated()
        {
            Utilities.Logger.Log("Defeated {_result}");
        }
    }
}