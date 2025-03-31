using System;

namespace Core
{
    public static class EventManager
    {
        public static event Action OnLevelStart;

        public static void RaiseOnLevelStart() => OnLevelStart?.Invoke();
    }
}