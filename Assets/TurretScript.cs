using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TurretScript : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float shotsPerSecond = 1f;

    private Transform target;
    private float timeUntilShoot;

    private void OnDrawGizmosSelected() {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){
            FindTarget();
            return;
        }

        FaceTarget();

       if (!CheckTargetIsInRange()){
            target = null;
       }else{
        timeUntilShoot += Time.deltaTime;
        if(timeUntilShoot >= 1f/shotsPerSecond){
            Shoot();
            timeUntilShoot = 0f;
        }


       }

    }


    private void Shoot(){
       GameObject arrowObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
       Arrow arrowScript = arrowObj.GetComponent<Arrow>();
       arrowScript.SetTarget(target);
    }

    private void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0){
            target = hits[0].transform;
        }

    }

    private void FaceTarget(){
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool CheckTargetIsInRange(){
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

}
