using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Turret : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;

    //LayerMask prevents tiles be detected as targets.
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; //Bullets per second
    [SerializeField] private int baseUpgradeCost = 100;

    private float bpsBase;
    private float targetingRangeBase;

    private Transform target;
    private float timeUntilFire;

    private int level = 1;

    // Start is called before the first frame update
    private void Start()
    {
        bpsBase = bps;
        targetingRangeBase = targetingRange;

        upgradeButton.onClick.AddListener(Upgrade);
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null){
            FindTarget();
            return;
        }
        
        RotateTowardsTarget();

        if (!CheckTargetIsInRange()){
            target=null;
        }
        else{
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps){
                shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void shoot(){
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        bullet bulletScript = bulletObj.GetComponent<bullet>();
        bulletScript.setTarget(target);
    }

    private void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) 
        transform.position, 0f, enemyMask);

        if (hits.Length > 0){
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange(){
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget(){
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation,
        targetRotation, rotationSpeed * Time.deltaTime);
    }
    //Vid

    private void OnDrawGizmosSelected(){
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    public void OpenUpgradeUI(){
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI(){
        upgradeUI.SetActive(false);
    }

    public void Upgrade(){
        if (CalculateCost() > LevelManager.main.currency) return;

        LevelManager.main.spendCurrency(CalculateCost());
        level++;

        bps = CalculateBPS();
        targetingRange = CalculateRange();
        
        UIHandler.main.SetHoveringState(false);
        Debug.Log("New BPS: " + bps);
        Debug.Log("New Range: " + targetingRange);
        Debug.Log("New Cost: " + CalculateCost());
    }

    private float CalculateBPS(){
        return bpsBase * Mathf.Pow(level, 0.6f);
    }

    private int CalculateCost(){
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateRange(){
        return targetingRangeBase * Mathf.Pow(level, 0.4f);
    }

}
