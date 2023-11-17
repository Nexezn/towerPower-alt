using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    //health system in here for now
    [SerializeField] private GameObject heartIcon1;
    [SerializeField] private GameObject heartIcon2;
    [SerializeField] private GameObject heartIcon3;
    [SerializeField] int lives = 3;

    //lose game
    [SerializeField] GameObject loseGameOverlay;

    //for winning the game
    [SerializeField] int levelsToWin = 5;
    private int levelNumber = 0;
    [SerializeField] GameObject winGameOverlay;
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] GameObject roundsToWinDisplay;
    [SerializeField] float timeToDisplay = 2f;


    private void Awake(){
        main = this;
    }

    public int currency;
    // Start is called before the first frame update
    
    private void Start()
    {
        currency = 100;
        DisplayRoundsToWin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseCurrency(int amount){
        currency += amount;
    }

    public bool spendCurrency(int amount){
        if (amount <= currency){
            currency -= amount;
            GameStatsManager.creditsSpent += amount;
            GameStatsManager.towersPurchased++;
            return true;

        }
        else{
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }
    
    public void loseLife()
    {
        lives--;
        switch(lives)
        {
            case 3: 
                break;
            
            case 2:
                heartIcon1.SetActive(false);
                break;
            
            case 1:
                heartIcon2.SetActive(false);
                break;
            
            default:
                break;
        }

        if ( lives <= 0) 
        {
            heartIcon3.SetActive(false);
            loseGame();
        }
    }

    private void loseGame()
    {
        Time.timeScale = 0f;

        if(loseGameOverlay != null)
        {
            loseGameOverlay.SetActive(true);
        }
    }

    public void increaseLevel()
    {
        levelNumber++;
        levelNumberText.text = "Round: " + levelNumber;
        
        if(levelNumber > levelsToWin)
        {
            winGame();
        }
    }

    public void PlayAgainButtonClicked(string sceneName)
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
    private void winGame()
    {
        Time.timeScale = 0f;

        if (winGameOverlay != null)
        {
            winGameOverlay.SetActive(true);
        }
    }

    private void DisplayRoundsToWin()
    {
        StartCoroutine(displayRoundsToWin());
    }

    IEnumerator displayRoundsToWin()
    {
        roundsToWinDisplay.GetComponentInChildren<TextMeshProUGUI>().text = "Complete " + levelsToWin + " rounds to win!";
        roundsToWinDisplay.SetActive(true); // Display the object

        // Wait for two seconds
        yield return new WaitForSeconds(timeToDisplay);

        roundsToWinDisplay.SetActive(false);
    }
}
