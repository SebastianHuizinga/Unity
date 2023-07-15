using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers;

    private int selectedTurret = 0;

    private void Awake(){
        main = this;


    }

    public Tower GetSelectedTower(){
        return towers[selectedTurret];
    }

    public void SelectedTower(int _selectedTower){
        selectedTurret = _selectedTower;

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
