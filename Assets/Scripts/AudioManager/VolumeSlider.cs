using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(val => source.volume = val);
    }

}
