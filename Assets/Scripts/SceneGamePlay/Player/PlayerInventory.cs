using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : GameMonoBehaviour
{
    //Now it's used only for key, so...
    [SerializeField] protected bool haveKey = false;
    [SerializeField] public bool HaveKey => this.haveKey;
    
    [SerializeField] protected SpriteRenderer keyIconRenderer;

    protected override void LoadComponents(){
        this.LoadKeyIconRenderer();
    }

    protected virtual void LoadKeyIconRenderer(){
        if(this.keyIconRenderer != null) return;
        this.keyIconRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void StoreItem(){
        this.haveKey = true;
        var sprite = Resources.Load<Sprite>("ItemIcon/Key_Icon");
        keyIconRenderer.sprite = sprite;
    }

    public virtual void UseItem(){
        this.haveKey = false;
        keyIconRenderer.sprite = null;
    }
}
