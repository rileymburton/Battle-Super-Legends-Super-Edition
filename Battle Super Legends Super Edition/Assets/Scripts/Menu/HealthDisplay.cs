using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public CombinedMove Cm = new CombinedMove();
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    private GameObject[] inventorySlots;
    
    //storage ints
    public int[] inventory = new int[4];
    public int coin;
    public int metal;
    public int leather;
    public int wood;
    public int ether;

    //used for display
    //inventory
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private Slider healthBar;
    private Text healthDisplay;
    private Text coinDisplay;
    private Text metalDisplay;
    private Text leatherDisplay;
    private Text woodDisplay;
    private Text etherDisplay;

    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlots");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("inventory");

        healthBar.maxValue = Cm.maxHealth;
        coin    = 300;
        metal   = 23;
        leather = 65;
        wood    = 325890;
        ether   = 903;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text  = Cm.playerHealth+"/"+Cm.maxHealth;
        healthBar.value = Cm.playerHealth;

        coinDisplay.text    = coin.ToString();
        metalDisplay.text   = metal.ToString();
        leatherDisplay.text = leather.ToString();
        woodDisplay.text    = wood.ToString();
        etherDisplay.text   = ether.ToString();

        for (int i = 0; i > 4; i++)
        {
            switch (inventory[i]){
                case 0:
                    inventorySlots[i].spriteR.sprite = ;
                break;

                case 1:
                    
                break;

                case 2:
                    
                break;

                case 3:
                    
                break;

                case 4:
                    
                break;

                case 5:
                    
                break;

                case 6:
                    
                break;

                case 7:
                    
                break;

                case 8:
                    
                break;

                case 9:
                    
                break;

                default:
                    
                break;
            }
        }
    }
}
