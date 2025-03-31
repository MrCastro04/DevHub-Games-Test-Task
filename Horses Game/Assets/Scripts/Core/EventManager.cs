using System;
using Horses;

namespace Core
{
    public static class EventManager
    {

        public static event Action OnPlayerConfirmChoose;
        public static event Action <float> OnShowTimeInMainCanvas;
        public static event Action <HorseContoller> OnAttachCameraToConfirmedHorse;

        public static void RaiseOnPlayerConfirmChoose() => OnPlayerConfirmChoose?.Invoke();
        public static void RaiseOnShowTimeInMainCanvas(float time) => OnShowTimeInMainCanvas?.Invoke(time);
        public static void RaiseOnAttachCameraToConfirmedHorse(HorseContoller confirmedHorse) =>
            OnAttachCameraToConfirmedHorse?.Invoke(confirmedHorse);
    }
}