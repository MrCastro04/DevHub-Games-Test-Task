using UnityEngine;

namespace Horses
{
    [RequireComponent(typeof(AudioSource))]

    public class HorseAudioController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private HorseContoller _horseContoller;
        private bool _isPlayingSound = false;

        private void Awake()
        {
            _horseContoller = GetComponent<HorseContoller>();

            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_horseContoller.Movement.IsMoving && _isPlayingSound == false)
            {
                _isPlayingSound = true;

                _audioSource.Play();
            }
            else if (_horseContoller.Movement.IsMoving == false && _isPlayingSound)
            {
                _audioSource.Stop();
            }
        }
    }
}