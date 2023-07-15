using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] TextMeshProUGUI moneyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;


    public void ToggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }
    private void OnGUI() {
        moneyUI.text = LevelManager.main.money.ToString();
    }
    // Start is called before the first frame update
  
    public void setSelected(){

    }   
    // Update is called once per frame  
   
}
