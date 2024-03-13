using Managers;
using UnityEngine.SceneManagement;

namespace States
{
    public class GameplayState : GameState
    {
        public GameplayState(GameManager gameManager) : base(gameManager) { }

        public override void Enter()
        {
            SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        }
    }
}