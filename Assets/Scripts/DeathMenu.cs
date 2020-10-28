using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu: MonoBehaviour {
  public Text scoreText, menuText;
  private bool isShowed = false;
  private float transition = 0.0f;

  // Start is called before the first frame update
  void Start() {
    gameObject.SetActive(false);

  }

  // Update is called once per frame
  void Update() {
    if (!isShowed) return;

    transition += Time.deltaTime;
  }

  public void ToggleEndMenu(float score) {
    gameObject.SetActive(true);
    
    menuText.text = ((int) score).ToString();
    scoreText.text = ((int) score).ToString();

    isShowed = true;
  }

  public void Restart() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  public void ToMenu() {
    SceneManager.LoadScene("Menu");
  }
}