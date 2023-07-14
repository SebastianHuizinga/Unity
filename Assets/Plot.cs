using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
   [Header("References")]
   [SerializeField]private SpriteRenderer sr;
   [SerializeField]private Color hoverColor;
   
   
    private GameObject tower;
    private Color startColor;

    private void OnMouseEnter(){
        sr.color = hoverColor;

    }

    private void OnMouseExit() {
        sr.color = startColor;
    }
    private void OnMouseDown() {
        if(tower != null) return;

         GameObject towerTemp = BuildManager.main.GetSelectedTower();
         tower = Instantiate(towerTemp, transform.position, Quaternion.identity);   
    }
    // Start is called before the first frame update
    void Start()
    {
        startColor = sr.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
