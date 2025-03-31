namespace Horses
{
    public class AIChooseState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller) { }

        public override void UpdateState(HorseContoller horseContoller)
        {
            if (horseContoller.CanChoose == false) return;

            if (horseContoller.IsChosenByPlayer)
                ConfirmChoose(horseContoller);
        }

        private void ConfirmChoose(HorseContoller horseContoller)
        {
            horseContoller.SwitchState(horseContoller.PatrolState);
        }
    }
}