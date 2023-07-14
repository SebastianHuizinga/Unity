using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDmg = 1;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetTarget(Transform _target){
        target = _target;

    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction*bulletSpeed;


    }

    private void OnCollisionEnter2D(Collision2D other) {

        other.gameObject.GetComponent<Health>().TakeDamage(bulletDmg);
        Destroy(gameObject);
    }
}
