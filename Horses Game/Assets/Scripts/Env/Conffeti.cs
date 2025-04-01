using Core;
using Horses;
using UnityEngine;

namespace Env
{
    public class Conffeti : MonoBehaviour
    {
       [SerializeField] private ParticleSystem _effect1;
       [SerializeField] private ParticleSystem _effect2;
       [SerializeField] private Vector3 _spawnOffset;

        private void OnEnable()
        {
            EventManager.OnHorseGetsFinish += HandleOnHorseGetsFinish;
        }

        private void OnDisable()
        {
            EventManager.OnHorseGetsFinish -= HandleOnHorseGetsFinish;
        }

        private void HandleOnHorseGetsFinish(HorseContoller horseContoller)
        {
            if (horseContoller.IsChosenByPlayer == false) return;

            Instantiate(_effect1, transform.position + _spawnOffset, Quaternion.identity);
            Instantiate(_effect2, transform.position - _spawnOffset, Quaternion.identity);
        }
    }
}
