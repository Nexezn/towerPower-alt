using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesDefeated;
    [SerializeField] TextMeshProUGUI projectilesFired;
    [SerializeField] TextMeshProUGUI creditsSpent;
    [SerializeField] TextMeshProUGUI towersUpgraded;
    [SerializeField] TextMeshProUGUI livesLost;
    [SerializeField] TextMeshProUGUI damageDone;
    [SerializeField] TextMeshProUGUI towersPurchased;
    [SerializeField] TextMeshProUGUI gameScoreText;

    private void OnEnable()
    {
        int gameScore = GameStatsManager.enemiesDefeated * 100 + GameStatsManager.towersPurchased * 10 - GameStatsManager.livesLost * 2500 + GameStatsManager.creditsSpent * 10;

        enemiesDefeated.text = "Enemies Defeated: " + GameStatsManager.enemiesDefeated.ToString();

        projectilesFired.text = "Projectiles Fired: " + GameStatsManager.projectilesFired.ToString();

        creditsSpent.text = "Credits Spent: " + GameStatsManager.creditsSpent.ToString();

        towersUpgraded.text = "Towers Upgraded: " + GameStatsManager.towersUpgraded.ToString();

        livesLost.text = "Lives Lost: " + GameStatsManager.livesLost.ToString();

        damageDone.text = "Damage Done: " + GameStatsManager.damageDone.ToString();

        towersPurchased.text = "Towers Purchased: " + GameStatsManager.towersPurchased.ToString();

        gameScoreText.text = "Game Score: " + gameScore;
    }
}
