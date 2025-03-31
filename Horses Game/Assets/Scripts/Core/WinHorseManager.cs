using Horses;
using UnityEngine;
using Utility;

namespace Core
{
    public class WinHorseManager : MonoBehaviour
    {
        public bool HasWinner => _hasWinner;

        private HorseContoller[] _horses;
        private bool _hasWinner = false;

        private void Start()
        {
            GameObject[] horseObjects = GameObject.FindGameObjectsWithTag(Constants.HORSE_TAG);

            _horses = new HorseContoller[horseObjects.Length];

            for (int i = 0; i < horseObjects.Length; i++)
            {
                _horses[i] = horseObjects[i].GetComponent<HorseContoller>();
            }
        }

        public void MarkWinnerChosen()
        {
            _hasWinner = true;
        }

        public HorseContoller GetRandomHorse()
        {
            int index = Random.Range(0, _horses.Length);

            return _horses[index];
        }
    }
}