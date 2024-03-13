using Managers;
using UnityEngine.SceneManagement;

namespace States
{
    public class MainMenuState : GameState
    { 
        public MainMenuState(GameManager gameManager) : base(gameManager) { }

        public override void Enter()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}