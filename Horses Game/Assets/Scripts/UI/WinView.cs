using UnityEngine;

namespace UI
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private EndPanelAnimation _animation;

        public void Enable()
        {
            gameObject.SetActive(true);
            _animation.Play();
        }
    }
}
