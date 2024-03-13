using Managers;
using UnityEngine;

namespace UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        public void Play()
        {
            GameManager.Instance.StartGameplay();
        }
    }
}
