using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score: MonoBehaviour {
  private float score = 0.0f;
  private int difficultyLevel = 1, maxDifficultyLevel = 10, scoreToNextLevel = 10;
  public bool isDead = false;
  public Text scoreText;
  public DeathMenu deathMenu;

  // Update is called once per frame
  void Update() {
    if (isDead) return;
    if (score >= scoreToNextLevel) LevelUp();
    // Update score
    score += Time.deltaTime * 2;
    scoreText.text = ((int) score).ToString();
  }

  // Update level
  void LevelUp() {
    if (difficultyLevel == maxDifficultyLevel) return;
    scoreToNextLevel *= 4;
    difficultyLevel++;
    GetComponent < PlayerMotor > ().SetSpeed(difficultyLevel);
  }

  public void OnDeath() {
    isDead = true;
    deathMenu.ToggleEndMenu(score);
  }
}