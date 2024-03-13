using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        private int score = 0;

        private int Score
        {
            get => score;
            set
            {
                score = value;
                if (score <= 0)
                {
                    score = 0;
                }
                GameEvents.ScoreChanged(score);
            }
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

        public void AddScore(int amount)
        {
            Score += amount;
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}