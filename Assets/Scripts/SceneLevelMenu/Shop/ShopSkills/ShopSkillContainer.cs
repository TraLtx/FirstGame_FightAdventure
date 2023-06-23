using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkillContainer : ContainerHorizontalHolder
{
    protected override void SetDistance()
    {
        this.distance = 120;
    }

    protected override bool IsDisable(Transform item)
    {
        Debug.Log("Item Check Active: "+item.transform.name);
        ShopItem shopItem = item.GetComponent<ShopItem>();
        if(shopItem == null) shopItem = item.GetComponentInChildren<ShopItem>();
        return !shopItem.IsActive();
    }
}
