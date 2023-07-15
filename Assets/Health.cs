using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]  
    [SerializeField] private int hitPoints =2;
    [SerializeField] private int deathValue = 50;

    private bool isDead = false;

    public void TakeDamage (int dmg){
        hitPoints -= dmg;

        if(hitPoints <= 0  && isDead == false){
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(deathValue);
            isDead = true;
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
