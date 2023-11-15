using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyAmount = 50;
    private bool isDestroyed = false;

    public void takeDamage(int dmg){
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed){
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.increaseCurrency(currencyAmount);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
