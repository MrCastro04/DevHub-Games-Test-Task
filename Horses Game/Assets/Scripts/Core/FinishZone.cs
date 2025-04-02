using System.Collections.Generic;
using Horses;
using UnityEngine;
using Utility;

namespace Core
{
    [RequireComponent(typeof(BoxCollider))]
    public class FinishZone : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        public Queue <HorseContoller> HorseQueue { get; private set; } = new();


        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            if (_boxCollider.enabled == false)
                _boxCollider.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HorseContoller horse))
            {
                HorseQueue.Enqueue(horse.GetComponent<HorseContoller>());

                EventManager.RaiseOnHorseGetsFinish(horse);

                WinHorseManager winHorseManager =
                    GameObject.FindGameObjectWithTag(Constants.WIN_HORSE_MANAGER_TAG)
                        .GetComponent<WinHorseManager>();

                horse.Movement.IsMoving = false;

                if (HorseQueue.Count == winHorseManager.Horses.Length)
                {
                    EventManager.RaiseOnAllHorsesFinish();
                }
            }
        }
    }
}
