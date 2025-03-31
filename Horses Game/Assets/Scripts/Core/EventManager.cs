using System;

namespace Core
{
    public static class EventManager
    {
        public static event Action OnPlayerConfirmChoose;
        public static event Action <float> OnShowTimeInMainCanvas;

        public static void RaiseOnPlayerConfirmChoose() => OnPlayerConfirmChoose?.Invoke();
        public static void RaiseOnShowTimeInMainCanvas(float time) => OnShowTimeInMainCanvas?.Invoke(time);
    }
}