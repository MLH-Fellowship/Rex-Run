using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    
    public bool isDead = false;
    public Text scoreText;
    public DeathMenu deathMenu;
    // // Start is called before the first frame update
    // void Start()
    // {
    // }

    // Update is called once per frame
    void Update()
    {
        
        if (isDead)
        return;

        if (score >= scoreToNextLevel) 
            LevelUp();
        // Update score
        score += Time.deltaTime * 2;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        // Update level
        scoreToNextLevel *= 4;
        difficultyLevel++;
        GetComponent<PlayerMotor>().SetSpeed (difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu (score);
        
    }
}
