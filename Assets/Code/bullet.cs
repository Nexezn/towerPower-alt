using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    //[SerializeField] private float timeToKill = 10f;

    private Transform target;
    //private float timeToLive = 0f;
    // Start is called before the first frame update

    public void setTarget(Transform _target){
        target = _target;
    }

    private void FixedUpdate(){
        if (!target){
            Destroy(gameObject);
            return;
        }

        //timeToLive++;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void Update(){
        /*
        timeToLive += Time.deltaTime;
        if (timeToLive > timeToKill){
            Destroy(gameObject);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<health>() != null)
        {
            other.gameObject.GetComponent<health>().takeDamage(bulletDamage);
            Destroy(gameObject);
        }

        //TODO: destroy game object if its not in play anymore
    }
}
