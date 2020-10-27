using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
  public Slider slider;
  public AudioSource bg;
  float initVolume = 0.5f;

  void Start(){
    slider.value = initVolume;
  }

  public void UpdateSound(){
    bg.volume = slider.value;
  }
}
