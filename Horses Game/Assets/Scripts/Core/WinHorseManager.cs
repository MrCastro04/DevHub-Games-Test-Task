using Horses;
using UnityEngine;
using Utility;

namespace Core
{
    public class WinHorseManager : MonoBehaviour
    {
        private HorseContoller[] _horses;
        private bool _hasWinner = false;

        public HorseContoller[] Horses => _horses;

        private void Start()
        {
            GameObject[] horseObjects = GameObject.FindGameObjectsWithTag(Constants.HORSE_TAG);

            _horses = new HorseContoller[horseObjects.Length];

            for (int i = 0; i < horseObjects.Length; i++)
            {
                _horses[i] = horseObjects[i].GetComponent<HorseContoller>();
            }
        }

        public void MarkRandomHorseWinHorse()
        {
            if(_hasWinner) return;

            HorseContoller randomHorse = GetRandomHorse();

            randomHorse.SetThisHorseWinHorse();

            _hasWinner = true;
        }

        public HorseContoller GetRandomHorse()
        {
            int index = Random.Range(0, _horses.Length);

            return _horses[index];
        }
    }
}