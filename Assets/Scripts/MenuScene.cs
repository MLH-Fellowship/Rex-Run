using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene: MonoBehaviour {
  void Start() {
    gameObject.SetActive(true);
  }

  public void startGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}