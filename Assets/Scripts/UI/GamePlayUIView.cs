using TMPro;
using UnityEngine;

namespace UI
{
    public class GamePlayUIView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private TMP_Text timerText;

        [SerializeField] 
        private GameObject gameOverDiaObj;
        [SerializeField] 
        private GameObject gamePlayDiaObj;
    
        [SerializeField]
        private Timer timer;

        private void Update()
        {
            timerText.text = timer.GetFormattedRemainingTime();
        }

        public void UpdateScoreDisplay(int newScore)
        {
            scoreText.text = "Score: " + newScore.ToString();
        }

        public void ChangingGamePlayState()
        {
            gameOverDiaObj.SetActive(true);
            gamePlayDiaObj.SetActive(false);
        }
    }
}
