using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coin;
    public int metal;
    public int wood;
    public int ether;
    public int leather;
    public ArrayList[] items = new ArrayList[4];

    public class weapon
    {
        public string name;
        public int value;
        public int damage;
        public int reqMetal;
        public int reqWood;
        public int reqEther;
        public int reqLeather;
    }

    public class armor
    {
        public string name;
        public int value;
        public int defense;
        public int reqMetal;
        public int reqWood;
        public int reqEther;
        public int reqLeather;
    }

    // Start is called before the first frame update
    void Start()
    {
        coin    = 0;
        metal   = 0;
        wood    = 0;
        ether   = 0;
        leather = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
