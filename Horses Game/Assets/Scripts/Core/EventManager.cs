using System;

namespace Core
{
    public static class EventManager
    {

        public static event Action OnAllHorsesFinish;
        public static event Action OnHorsesStartRun;
        public static event Action OnPlayerConfirmChoose;
        public static event Action <float> OnShowTimeInMainCanvas;

        public static void RaiseOnAllHorsesFinish() => OnAllHorsesFinish?.Invoke();
        public static void RaiseOnHorsesStartRun() => OnHorsesStartRun?.Invoke();
        public static void RaiseOnPlayerConfirmChoose() => OnPlayerConfirmChoose?.Invoke();
        public static void RaiseOnShowTimeInMainCanvas(float time) => OnShowTimeInMainCanvas?.Invoke(time);
    }
}