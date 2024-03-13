using States;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameState currentState;
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            MainMenu();
        }

        private void ChangeState(GameState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void MainMenu()
        {
            ChangeState(new MainMenuState(this));
        }

        public void StartGameplay()
        {
            ChangeState(new GameplayState(this));
        }

        public void GameCompleted()
        {
            ChangeState(new GameCompleteState(this));
        }
    }
}
