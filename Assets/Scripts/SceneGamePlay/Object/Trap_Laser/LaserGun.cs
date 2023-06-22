using UnityEngine;

public class LaserGun : GameMonoBehaviour
{
    [SerializeField] protected DamSender damSender;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected Transform startVFX;
    [SerializeField] protected Transform endVFX;

    [SerializeField] protected float fireDistance = 50f;
    [SerializeField] protected int status = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamsender();
        this.LoadShootPoint();
        this.LoadLineRenderer();
        this.LoadStartVFX();
        this.LoadEndVFX();
    }
    protected virtual void LoadDamsender(){
        if(this.damSender != null) return;
        this.damSender = transform.GetComponentInChildren<DamSender>();
    }
    protected virtual void LoadShootPoint(){
        if(this.shootPoint != null) return;
        this.shootPoint = transform.Find("FirePoint");
    }
    protected virtual void LoadLineRenderer(){
        if(this.lineRenderer != null) return;
        this.lineRenderer = transform.GetComponentInChildren<LineRenderer>();
    }
    protected virtual void LoadStartVFX(){
        if(this.startVFX != null) return;
        this.startVFX = transform.Find("StartVFX");
    }
    protected virtual void LoadEndVFX(){
        if(this.endVFX != null) return;
        this.endVFX = transform.Find("EndVFX");
    }

    protected virtual void Start(){
        this.damSender.SetDamage(20);
    }
    protected virtual void Update(){
        if(this.status == 1){
            this.Shoot();
        }
    }

    protected virtual void Shoot(){
        RaycastHit2D _hit = Physics2D.Raycast(shootPoint.position, shootPoint.right);

        if(_hit){
            Draw2DRay(shootPoint.position, _hit.point);
            this.endVFX.position = _hit.point;
            endVFX.gameObject.SetActive(true);
            if(_hit.transform.tag == "Player"){
                this.damSender.Send(_hit.transform);
            }
        }else{
            Draw2DRay(shootPoint.position, shootPoint.transform.right * fireDistance);
            endVFX.gameObject.SetActive(false);
        }
    }
    void Draw2DRay(Vector2 startPoint, Vector2 endPoint){
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    public virtual void Fire(){
        this.status = 1;
        lineRenderer.enabled = true;
        startVFX.gameObject.SetActive(true);
    }

    public virtual void Stop(){
        this.status = 0;
        lineRenderer.enabled = false;
        startVFX.gameObject.SetActive(false);
        endVFX.gameObject.SetActive(false);
    }
}
