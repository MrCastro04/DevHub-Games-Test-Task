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
        private Queue <HorseContoller> _horseQueue = new();

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
                WinHorseManager winHorseManager =
                    GameObject.FindGameObjectWithTag(Constants.WIN_HORSE_MANAGER_TAG)
                        .GetComponent<WinHorseManager>();

                horse.Movement.IsMoving = false;

                _horseQueue.Enqueue(horse.GetComponent<HorseContoller>());

                if (_horseQueue.Count == winHorseManager.Horses.Length)
                {
                    EventManager.RaiseOnAllHorsesFinish();
                }
            }
        }
    }
}
