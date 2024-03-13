using Managers;
using UnityEngine;

namespace UI
{
    public class GamePlayUIController : MonoBehaviour
    {
        [SerializeField] 
        private GamePlayUIView gamePlayUIView;
        public static GamePlayUIController Instance { get; private set; }

        private void OnEnable()
        {
            GameEvents.OnScoreChanged += UpdateScoreDisplay;
            GameEvents.OnTimeComplete += GameCompleted;
        }

        private void OnDisable()
        {
            GameEvents.OnScoreChanged -= UpdateScoreDisplay;
            GameEvents.OnTimeComplete -= GameCompleted;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void BackToMainMenu()
        {
            GameManager.Instance.MainMenu();
        }

        private void UpdateScoreDisplay(int newScore)
        {
            gamePlayUIView.UpdateScoreDisplay(newScore);
        }

        private void GameCompleted()
        {
            GameManager.Instance.GameCompleted();
        }

        public void EnableGameOverDia()
        {
            gamePlayUIView.ChangingGamePlayState();
        }
    }
}
