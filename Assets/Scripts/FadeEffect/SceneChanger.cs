using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected string nextSceneName;

    protected override void LoadComponents(){
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    public virtual void ChangeScene(string nextSceneName){
        this.nextSceneName = nextSceneName;
        animator.SetTrigger("FadeIn");
    }

    public virtual void OnFadeInDone(){
        // MainMenuManager.Instance.LoadNextScene();
        SceneManager.LoadScene(nextSceneName);
    }
}
