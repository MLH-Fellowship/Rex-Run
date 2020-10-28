using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController: MonoBehaviour {
  public Slider slider;
  public AudioSource bg;
  float initVolume = 0.5f;

  void Start() {
    slider.value = initVolume;
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

    // Save the volume setting
    if (objs.Length > 1) {
      initVolume = objs[0].GetComponent < AudioSource > ().volume;
      slider.value = initVolume;
      DontDestroyOnLoad(objs[1]);
      Destroy(objs[0]);
    }
    else {
      DontDestroyOnLoad(objs[0]);
    }

  }

  public void UpdateSound() {
    bg.volume = slider.value;
  }
}