using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] turretPrefabs;

    private int selectedTurret = 0;

    private void Awake(){
        main = this;


    }

    public GameObject GetSelectedTower(){
        return turretPrefabs[selectedTurret];
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
