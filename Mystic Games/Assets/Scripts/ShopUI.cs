using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ButtonUtil;

public class ShopUI : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private ICustomerShop shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Weapons.ItemType.Sword, Weapons.GetSprite(Weapons.ItemType.Sword), "DragonSlayer", Weapons.GetCost(Weapons.ItemType.Sword), 0);
        CreateItemButton(Weapons.ItemType.Sword, Weapons.GetSprite(Weapons.ItemType.Sword), "Batman", Weapons.GetCost(Weapons.ItemType.Sword), 1);

        Hide();
    }

    private void CreateItemButton(Weapons.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<ButtonPress>().ClickFunc = () => {
            // Clicked on shop item button
            BuyItem(itemType);
        };


    }

    public void BuyItem(Weapons.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void Show(ICustomerShop shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
