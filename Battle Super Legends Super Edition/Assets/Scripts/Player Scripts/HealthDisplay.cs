using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //used to collect/display health
    CombinedMove Cm = new CombinedMove();
    public Text healthText;
    
    //storage ints
    public int[] inventory = new int[4];
    public int coin;
    public int metal;
    public int leather;
    public int wood;
    public int ether;

    //used for display
    public Text inventoryText;
    public Text coinText;
    public Text metalText;
    public Text leatherText;
    public Text woodText;
    public Text etherText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: "+Cm.playerHealth+"/"+Cm.maxHealth;

        coinText.text = "COINS: "+coin;
        metalText.text = "METAL: "+metal;
        leatherText.text = "LEATHER: "+leather;
        woodText.text = "WOOD: "+wood;
        etherText.text = "ETHER: "+ether;

        for (int i = 0; i > 4; i++)
        {
            if (inventory[i] == 0)
            {
                
            }
            if (inventory[i] == 1)
            {
                
            }
            if (inventory[i] == 2)
            {
                
            }
            if (inventory[i] == 3)
            {
                
            }
            if (inventory[i] == 4)
            {
                
            }
            if (inventory[i] == 5)
            {
                
            }
            if (inventory[i] == 6)
            {
                
            }
            if (inventory[i] == 7)
            {
                
            }
            if (inventory[i] == 8)
            {
                
            }
            if (inventory[i] == 9)
            {
                
            }
        }
    }
}
