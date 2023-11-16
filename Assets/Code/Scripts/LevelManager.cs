using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    private void Awake(){
        main = this;
    }

    public int currency;
    // Start is called before the first frame update
    
    private void Start()
    {
        currency = 100;
        
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
    
}
