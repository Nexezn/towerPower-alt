using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] Turret parentTurret;

    [SerializeField] TextMeshProUGUI projectilesFired;
    [SerializeField] TextMeshProUGUI upgradesPurchased;
    [SerializeField] TextMeshProUGUI fireRate;
    [SerializeField] TextMeshProUGUI range;
    [SerializeField] TextMeshProUGUI rotationSpeed;


    private void OnEnable()
    {
        upgradeMenu.transform.position = Vector3.zero;
        projectilesFired.text = "Projectiles Fired: " + parentTurret.getProjectilesFired();
        upgradesPurchased.text = "Upgrades Purchased: " + parentTurret.getUpgradesPurchased();
        fireRate.text = "Fire Rate: " + parentTurret.getBps();
        range.text = "Range: " + parentTurret.getRange();
        rotationSpeed.text = "Rotation Speed: " + parentTurret.getRotationSpeed();
    }

    private void FixedUpdate()
    {
        projectilesFired.text = "Projectiles Fired: " + parentTurret.getProjectilesFired();
        upgradesPurchased.text = "Upgrades Purchased: " + parentTurret.getUpgradesPurchased();
        fireRate.text = "Fire Rate: " + parentTurret.getBps();
        range.text = "Range: " + parentTurret.getRange();
        rotationSpeed.text = "Rotation Speed: " + parentTurret.getRotationSpeed();
    }
    public void BackButtonPressed()
    {
        this.gameObject.SetActive(false);
    }
}
