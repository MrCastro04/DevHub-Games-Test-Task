namespace Horses.States
{
    public abstract class AIBaseState
    {
        public abstract void EnterState(HorseContoller horseContoller);
        public abstract void UpdateState(HorseContoller horseContoller);
    }
}