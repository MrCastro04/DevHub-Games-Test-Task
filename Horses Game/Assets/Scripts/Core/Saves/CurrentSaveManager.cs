using UnityEngine;
using System.Collections;

namespace Core.Saves
{
    public class CurrentSaveManager : MonoBehaviour
    {
        public static CurrentSaveManager Instance { get; private set; }
        public SaveData CurrentSave { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            StartCoroutine(LoadSaveNextFrame());
        }

        private IEnumerator LoadSaveNextFrame()
        {
            yield return null;
            GetLastSave(SaveSystem.GetData());

            if (PlayerResources.Instance != null)
            {
                PlayerResources.Instance.GetMoneyFromSave(CurrentSave);
            }
            else
            {
                Debug.LogWarning("PlayerResources.Instance is null on save load!");
                StartCoroutine(WaitForPlayerResources());
            }
        }

        private IEnumerator WaitForPlayerResources()
        {
            float timeoutCounter = 0f;
            while (PlayerResources.Instance == null && timeoutCounter < 3f)
            {
                timeoutCounter += Time.deltaTime;
                yield return null;
            }

            if (PlayerResources.Instance != null)
            {
                PlayerResources.Instance.GetMoneyFromSave(CurrentSave);
            }
            else
            {
                Debug.LogError("PlayerResources.Instance still null after waiting!");
            }
        }

        private void OnEnable()
        {
            EventManager.OnPlayerGetMoney += HandleOnPlayerGetMoney;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerGetMoney -= HandleOnPlayerGetMoney;
        }

        private void GetLastSave(SaveData data)
        {
            CurrentSave = data;
        }

        private void HandleOnPlayerGetMoney(int playerCurrentMoneyAmount)
        {
            CurrentSave.Money = playerCurrentMoneyAmount;
            SaveSystem.SetData(CurrentSave);
        }
    }
}