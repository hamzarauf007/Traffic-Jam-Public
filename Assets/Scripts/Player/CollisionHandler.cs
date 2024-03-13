using UnityEngine;
using Managers;
using Traffic;
using Cash;
using Particles;
using Sound;

namespace Player
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerController playerController;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Money"))
            {
                ICollectable moneyScript = other.GetComponent<ICollectable>();
                if (moneyScript != null)
                {
                    ParticleManager.Instance.PlayEffect(ParticleEffectType.Collection, other.transform.position);
                    SoundManager.Instance.PlaySoundEffect("Money Collection");
                    ScoreManager.Instance.AddScore(moneyScript.Value);
                    moneyScript.Collect();
                }
            }
            else if (other.CompareTag("Traffic"))
            {
                ITrafficCar trafficCar = other.GetComponent<ITrafficCar>();
                if (trafficCar != null)
                {
                    ParticleManager.Instance.PlayEffect(ParticleEffectType.Collision, other.transform.position);
                    SoundManager.Instance.PlaySoundEffect("Car Blast");
                    ScoreManager.Instance.AddScore(-trafficCar.PlayerHitDeduction);
                }
            }
            else if (other.CompareTag("PlayArea"))
            {
                if (playerController)
                {
                    playerController.ResetCar();
                }
            }
        }
    }
}
