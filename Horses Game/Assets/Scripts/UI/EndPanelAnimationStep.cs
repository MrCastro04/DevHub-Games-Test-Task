using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public struct EndPanelAnimationStep
    {
        [SerializeField] private Vector3 _scale;
        [SerializeField] private float _duration;

        public Vector3 Scale => _scale;
        public float Duration => _duration;
    }
}