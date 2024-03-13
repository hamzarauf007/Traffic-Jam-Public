using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] 
        private AudioSource effectsSource;
        [SerializeField] 
        private AudioSource musicSource;
        [SerializeField] 
        private AudioClip[] soundEffects; 
        [SerializeField] 
        private AudioClip[] musicTracks; 
        public static SoundManager Instance { get; private set; }

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

        public void PlaySoundEffect(string name)
        {
            AudioClip clip = GetSoundEffectByName(name);
            if (clip != null)
            {
                effectsSource.PlayOneShot(clip);
            }
        }

        public void PlayMusic(string name)
        {
            AudioClip clip = GetMusicByName(name);
            if (clip != null)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
        }

        public void SetEffectsVolume(float volume)
        {
            effectsSource.volume = volume;
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        private AudioClip GetSoundEffectByName(string name)
        {
            foreach (var clip in soundEffects)
            {
                if (clip.name == name) return clip;
            }
            Debug.LogWarning($"Sound effect '{name}' not found!");
            return null;
        }

        private AudioClip GetMusicByName(string name)
        {
            foreach (var clip in musicTracks)
            {
                if (clip.name == name) return clip;
            }
            Debug.LogWarning($"Music track '{name}' not found!");
            return null;
        }
    }
}