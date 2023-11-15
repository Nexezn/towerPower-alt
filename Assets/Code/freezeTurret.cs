using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class freezeTurret : MonoBehaviour
{
    [Header("References")]

    //LayerMask prevents tiles be detected as targets.
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float attackPerSecond = 4f;
    [SerializeField] private float freezeTime = 1f;

    private float timeUntilFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / attackPerSecond){
            freezeEnemy();
            timeUntilFire = 0f;
        }
    }

    private void freezeEnemy(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) 
        transform.position, 0f, enemyMask);

        if (hits.Length > 0){
            for (int i = 0; i < hits.Length; i++){
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.updateSpeed(0.5f);

                StartCoroutine(resetEnemySpeed(em));
            }
        }
    }

    private IEnumerator resetEnemySpeed(EnemyMovement em){
        yield return new WaitForSeconds(freezeTime);

        em.resetSpeed();
    }
    private void OnDrawGizmosSelected(){
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

}
