using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopTriggerCollider : MonoBehaviour
{
    [SerializeField] private ShopUI uiShop;

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("shop");
        ICustomerShop shopCustomer = collider.GetComponent<ICustomerShop>();
        if (shopCustomer != null){
            uiShop.Show(shopCustomer);
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        ICustomerShop shopCustomer = collider.GetComponent<ICustomerShop>();
        if (shopCustomer != null){
            uiShop.Hide();
        }
    }
}
