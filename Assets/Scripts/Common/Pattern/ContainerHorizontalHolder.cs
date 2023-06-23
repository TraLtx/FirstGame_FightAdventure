using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContainerHorizontalHolder :  GameMonoBehaviour
{
    [SerializeField] protected List<Transform> containerList;
    [SerializeField] protected List<Vector2> placeList;
    [SerializeField] protected int size;

    [SerializeField] protected float distance;

    [SerializeField] protected bool isChangePlace = false;

    [SerializeField] protected bool isStart = false;
    [SerializeField] protected int deactiveAmount = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContainers();
    }

    protected virtual void Start(){Debug.Log("===METHOD: "+transform.name+" Start()");
        this.isStart = true;
        this.SetDistance();
        this.CreatePlace();
        this.Reload();
        // this.SortContainer();
        // this.PlaceContainer();
    }

    protected virtual void LoadContainers(){
        this.containerList.Clear();
        foreach (Transform container in this.transform)
        {
            this.containerList.Add(container);
        }
        this.size = this.containerList.Count;
    }

    protected abstract void SetDistance();
    protected virtual void CreatePlace(){Debug.Log("===METHOD: "+transform.name+" CreatePlace()");
        this.placeList.Add(this.containerList[0].GetComponent<RectTransform>().anchoredPosition);
        Debug.Log("Place_0: "+this.placeList[0]);
        for (int i = 1; i < this.size; i++){
            Vector2 place = new Vector2(this.placeList[0].x + (i * this.distance), this.placeList[0].y);
            placeList.Add(place);
            Debug.Log("Place_"+i+": "+place);
        }
        
        Debug.Log("PlaceListSize: "+this.placeList.Count);
    }

    protected virtual void PlaceContainer(){Debug.Log("===METHOD: "+transform.name+" PlaceContainer()");
        this.SetContainerWidth();

        int index = 0;
        foreach (Transform container in this.containerList)
        {
            container.GetComponent<RectTransform>().anchoredPosition = this.placeList[index];
            Debug.Log("Place_Container_"+index+": "+container.GetComponent<RectTransform>().anchoredPosition);
            index ++;
        }
    }

    protected virtual void SetContainerWidth(){Debug.Log("===METHOD: "+transform.name+" SetContainerWidth()");
        // float newWidth = this.distance * (this.size - 1)  + 
        //                 (this.containerList[0].GetComponent<RectTransform>().rect.width * this.size);

        Debug.Log("This.size: "+ this.size);
        foreach (Vector2 p in this.placeList)
        {
            Debug.Log(p);
        }

        float newWidth = this.placeList[this.size-1].x - this.placeList[0].x + 
                            this.containerList[0].GetComponent<RectTransform>().rect.width;

        RectTransform rectTransform = this.transform.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y); 
        Debug.Log("NewWidth: "+ newWidth);
    }

    protected virtual void SortContainer(){Debug.Log("===METHOD: "+transform.name+" SortContainer()");
        int currentIndex = 0;
        int currentDeactiveAmount = this.deactiveAmount;
        for(int i = 0; i < this.size-currentDeactiveAmount; i++){Debug.Log("Index "+currentIndex+": "+this.containerList[currentIndex].name);
            if(this.IsDisable(this.containerList[currentIndex])){
                Transform temp = containerList[currentIndex];
                containerList.RemoveAt(currentIndex);
                containerList.Insert(this.size - 1, temp);
                Debug.Log("Deactive item shop: " + temp.name);
                this.deactiveAmount ++;
            }else{
                currentIndex ++;
            }
        }

        this.isChangePlace = false;
        Debug.Log("===METHOD: "+transform.name+" SortContainer() --- DONE");
    }

    protected abstract bool IsDisable(Transform tranform);

    //---PUBLIC---
    public virtual void Reload(){
        if(!isStart) this.Start();
        if(this.isChangePlace == false) return;

        this.SortContainer();
        this.PlaceContainer();
    }

    public virtual void ResetSort(){
        this.deactiveAmount = 0;
    }

    public virtual void NotifyChangePlace(){
        this.isChangePlace = true;
    }
}
