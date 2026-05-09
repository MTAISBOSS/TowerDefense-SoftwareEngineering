using System;
using Events;
using EventSystem;
using UnityEngine;

namespace UI.Buttons
{
    public class StartGameBtn : MonoBehaviour
    {
        public void Execute()
        {
            EventBus<GameStartedEvent>.Raise(new GameStartedEvent());
        }
    }
}