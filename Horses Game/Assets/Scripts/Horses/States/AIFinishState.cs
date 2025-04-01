namespace Horses.States
{
    public class AIFinishState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {
            horseContoller.Movement.IsMoving = false;

           horseContoller.Agent.speed = 0;
        }

        public override void UpdateState(HorseContoller horseContoller) { }
    }
}