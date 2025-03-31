namespace Horses.States
{
    public class AIChargeState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {
            horseContoller.Agent.speed += 10;
        }

        public override void UpdateState(HorseContoller horseContoller)
        {
           // чекає 40% пройденого шляху , і прискорюється
        }
    }
}