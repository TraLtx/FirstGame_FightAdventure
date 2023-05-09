using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuSwitchTab : SwitchTab
{
    protected override void LoadTabs(){
        Transform tabContainer = transform.parent.Find("Canvas/Pnl_PageContent");//Debug.Log(tabContainer.name);
        foreach(Transform tab in tabContainer){
            this.tabs.Add(tab);
        }
    }
    protected override void SetTabDefault(){
        this.defaultTab = transform.parent.Find("Canvas/Pnl_PageContent/Levels");
        this.currentTab = this.defaultTab;

        foreach(Transform tab in tabs){
            if(this.defaultTab.name == tab.name){
                tab.gameObject.SetActive(true);
            }else{
                tab.gameObject.SetActive(false);
            }
        }
    }

    public override void ChangeToTab(string tabName){
        base.ChangeToTab(tabName);
        SystemTitle.Instance.ChangeContent(tabName);
    }
}
