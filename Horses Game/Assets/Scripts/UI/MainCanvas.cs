using System;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
 public class MainCanvas : MonoBehaviour
 {
  private TextMeshProUGUI _text;

  private void Awake()
  {
   _text = GetComponentInChildren<TextMeshProUGUI>();
  }

  private void OnEnable()
  {
   EventManager.OnLevelStart += HandleOnLevelStart;
  }

  private void OnDisable()
  {
   EventManager.OnLevelStart -= HandleOnLevelStart;
  }

  private void HandleOnLevelStart()
  {
   _text.enabled = true;
  }
 }
}
