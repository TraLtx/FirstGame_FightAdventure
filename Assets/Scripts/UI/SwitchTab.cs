using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchTab : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> tabs;
    [SerializeField] protected Transform currentTab;
    [SerializeField] protected Transform defaultTab;

    protected override void LoadComponents(){
        this.LoadTabs();
        this.SetTabDefault();
    }

    protected abstract void LoadTabs();
    protected abstract void SetTabDefault();

    public virtual void ChangeToTab(string tabName){
        Transform nextTab = this.GetTabByName(tabName);
        if(nextTab == null) {
            Debug.Log("TAB NOT FOUND");
            return;
        }

        this.currentTab.gameObject.SetActive(false);
        this.currentTab = nextTab;
        this.currentTab.gameObject.SetActive(true);
    }

    protected virtual Transform GetTabByName(string tabName){
        foreach(Transform tab in this.tabs){
            if(tabName == tab.name) return tab;
        }

        return null;
    }
}
