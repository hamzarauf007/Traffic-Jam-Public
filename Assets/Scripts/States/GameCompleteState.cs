using Managers;
using UI;

namespace States
{
    public class GameCompleteState : GameState
    {
        public GameCompleteState(GameManager gameManager) : base(gameManager) { }

        public override void Enter()
        {
            GamePlayUIController.Instance.EnableGameOverDia();
        }
        
        public override void Exit()
        {
           
        }
    }
}