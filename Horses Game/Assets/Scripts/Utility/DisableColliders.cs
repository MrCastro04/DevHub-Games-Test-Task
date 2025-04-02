using UnityEngine;

namespace Utility
{
    public class DisableColliders : MonoBehaviour
    {
        void Start()
        {
            DisableCollidersRecursively(transform);
        }

        void DisableCollidersRecursively(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Collider[] colliders = child.GetComponents<Collider>();

                foreach (Collider collider in colliders)
                {
                    collider.enabled = false;
                }

                DisableCollidersRecursively(child);
            }
        }
    }
}