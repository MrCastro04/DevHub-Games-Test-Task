using Horses;
using UnityEngine;

namespace Core
{
    public class MainCamera : MonoBehaviour
    {
        private HorseContoller _confirmedHorse;

        public void AttachCameraToConfirmedHorse(HorseContoller confirmedHorse)
        {
            _confirmedHorse = confirmedHorse;

            gameObject.transform.SetParent(_confirmedHorse.transform);
        }
    }
}