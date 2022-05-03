using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
  [SerializeField] private Toggle toggle;
    public void Toggle(){
      //toggle.onValueChanged.AddListener(delegate{
      AudioManager.Instance.ToggleSounds();
        //Debug.Log("Text"); });
     }
}
