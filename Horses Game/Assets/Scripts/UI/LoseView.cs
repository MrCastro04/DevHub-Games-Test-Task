using UnityEngine;

namespace UI
{
    public class LoseView : MonoBehaviour
    {
        [SerializeField] private EndPanelAnimation _animation;

        public void Enable()
        {
            gameObject.SetActive(true);

            if (_animation != null)
                _animation.Play();
            else
                Debug.LogWarning("Animation не призначено у WinView!");
        }

    }
}
