using UnityEngine;

namespace Particles
{
    public interface IParticleTrigger
    {
        void PlayEffect(ParticleEffectType effectType, Vector3 position);
    }
}