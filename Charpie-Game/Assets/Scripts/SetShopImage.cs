using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetShopImage : MonoBehaviour
{

    private ShopMenu shopMenu;
    public int buttonNumber;
    public Sprite[] imageList;

    // Start is called before the first frame update
    void Start()
    {
        shopMenu = GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = imageList[shopMenu.powerups[buttonNumber]];
    }
}
