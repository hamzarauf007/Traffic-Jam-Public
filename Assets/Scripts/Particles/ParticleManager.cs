using System;
using UnityEngine;

namespace Particles
{
    public enum ParticleEffectType { Collision, Collection }

    public class ParticleManager : MonoBehaviour, IParticleTrigger
    {
        public static ParticleManager Instance { get; private set; }

        [SerializeField] private GameObject collisionEffectPrefab;
        [SerializeField] private GameObject collectionEffectPrefab;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void PlayEffect(ParticleEffectType effectType, Vector3 position)
        {
            GameObject effectPrefab = null;
            switch (effectType)
            {
                case ParticleEffectType.Collision:
                    effectPrefab = collisionEffectPrefab;
                    break;
                case ParticleEffectType.Collection:
                    effectPrefab = collectionEffectPrefab;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
            }

            if (effectPrefab != null)
            {
                var effectInstance = Instantiate(effectPrefab, position, Quaternion.identity);
                Destroy(effectInstance, 5f);
            }
        }
    }
}