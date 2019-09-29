using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 100;
    float lives;

    [SerializeField] int damage = 1;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - 30 * PlayerPrefsController.GetDifficulty();  //TODO figure out how to take away more than 0,1,2 (current)
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();            
        }
    }

    
}
