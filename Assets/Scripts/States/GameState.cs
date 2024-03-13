using Managers;

namespace States
{
    public abstract class GameState
    {
        protected GameManager gameManager;

        protected GameState(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}