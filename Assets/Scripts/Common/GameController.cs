using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Photon.Pun;

public class GameController : GameMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance {get => instance;}

    //---Game Object-------------------------------------------------------------
    [SerializeField] protected Transform playerPrefab;
    [SerializeField] protected Transform enemyPrefab;


    [SerializeField] protected Tilemap tileBackGround;
    public Tilemap TileBackGround {get => this.tileBackGround;}

    [SerializeField] protected Transform pnlYouDie;
    public Transform PnlYouDie => this.pnlYouDie;

    [SerializeField] protected Camera camera;


    // [SerializeField] protected GameObject playerServerPrefab;
    // [SerializeField] protected GameObject playerClientPrefab;

    [SerializeField] protected Transform thisPlayer;
    public Transform ThisPlayer => this.thisPlayer;

    [SerializeField] public static Vector3 screenMinPoint; //Left_Bottom
    // public Vector3 ScreenMinPoint {get => this.screenMinPoint;}

    [SerializeField] public static Vector3 screenMaxPoint; //Right_Top
    // public Vector3 ScreenMaxPoint {get => screenMaxPoint;}

    [SerializeField] protected bool isOnlineState;
    public bool IsOnlineState => this.isOnlineState;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;

        this.isOnlineState = CheckIsOnline();
        Debug.Log("Game online status: " + this.isOnlineState);
    }

    protected virtual bool CheckIsOnline(){
        return PhotonNetwork.IsConnected;
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadTileBackGround();
        this.LoadPnlYouDie();
        this.LoadScreenRange();
        this.LoadCamera();
        // this.LoadPlayerSpawnerPoints();
    }

    protected virtual void LoadTileBackGround(){
        if(this.tileBackGround != null) return;

        this.tileBackGround = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        // Debug.Log(tileBackGround.cellBounds);
    }

    protected virtual void LoadPnlYouDie(){
        if(this.pnlYouDie != null) return;
        this.pnlYouDie = GameObject.Find("MainCanvas").transform.Find("Pnl_YouDie");
    }

    protected virtual void LoadScreenRange(){
        BoundsInt cellBounds = this.tileBackGround.cellBounds;

        Vector3Int amountCell = cellBounds.size;
        float tileSize = this.tileBackGround.GetSprite(cellBounds.position).bounds.size.x;
        float tileSizeOffset = tileSize / 2 - 0.5f;
        // if(tileSize % 2 == 0){
        //     tileSizeOffset = tileSize / 2 - 0.5f;
        // }else{
        //     tileSizeOffset = tileSize / 2;
        // }
        // Debug.Log("cellBounds: "+cellBounds);
        // Debug.Log("tileSize: "+tileSize);
        // Debug.Log("tileSize%2: "+tileSize%2);
        // Debug.Log("tileSize/2: "+tileSize/2);
        // Debug.Log("tileSizeOffset: "+tileSizeOffset);

        screenMinPoint = cellBounds.position - new Vector3(tileSizeOffset, tileSizeOffset, 0);
        screenMaxPoint = cellBounds.position + new Vector3(amountCell.x + tileSizeOffset, amountCell.y + tileSizeOffset, 0);
        // Debug.Log(tileSize);
        // Debug.Log("Range_Screen: "+screenMinPoint+", "+screenMaxPoint);
    }

    protected virtual void LoadCamera(){
        this.camera = Transform.FindObjectOfType<Camera>();
    }

    // protected virtual void LoadPlayerSpawnerPoints(){
    //     Transform pointsObject = GameObject.Find("PlayerSpawnPoints").transform;

    //     foreach (Transform point in pointsObject)
    //     {
    //         this.playerSpawnerPoints.Add(point);
    //     }
    // }
    
    protected override void Start(){
        this.SpawnThisPlayer();
        this.SpawnEnemy();
        this.SpawnObject();
        // Physics2D.IgnoreCollision(this.playerPrefab.GetComponent<Collider2D>(), this.enemyPrefab.GetComponent<Collider2D>(), true);
    }


    public virtual Transform GetThisPlayer(){
        return thisPlayer;
    }

    protected virtual void SpawnThisPlayer(){

        // if(!isOnlineState){
        //     thisPlayer = this.SpawnPlayerOffline();
        // }else{
        //     thisPlayer = this.SpawnPlayerOnline();
        // }

        PlayerSpawner playerSpawner = PlayerSpawner.Instance;
        thisPlayer = playerSpawner.Spawn(PlayerSpawner.player, PlayerSpawner.spawnPointServer);
        if(PlayerPrefs.GetInt("CharacterIndex") == 1){
            thisPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Box_Char_Green");
        }else if(PlayerPrefs.GetInt("CharacterIndex") == 1){
            thisPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Box_Char_Yellow");
        }
        
        // thisPlayer.gameObject.SetActive(true);

        
        camera.GetComponent<CameraFollowTarget>().SetTarget(thisPlayer);
    }

    protected virtual void SpawnEnemy(){
        EnemySpawner.Instance.SpawnEnemyAllPoints(); 
    }

    protected virtual void SpawnObject(){
        BoxGunSpawner.Instance.SpawnBoxGunAllPoints(); 
        BoxHeartSpawner.Instance.SpawnBoxHeartAllPoints();
    }

    public virtual void ShowDieMenu(){
        this.pnlYouDie.gameObject.SetActive(true);
    }

    public virtual void RestartGame(){
        SceneManager.LoadScene("MainPlay");
    }

    // protected virtual Transform SpawnPlayerOffline(){Debug.Log("SpawnPlayerOffline");
    //     return Instantiate(
    //         playerServerPrefab, 
    //         playerSpawnerPoints[0].position, 
    //         playerSpawnerPoints[0].rotation
    //         ).transform;
    // }

    // protected virtual Transform SpawnPlayerOnline(){Debug.Log("SpawnPlayerOnline");
    //     int playerIndex = 0;
    //     GameObject playerPrefab = playerServerPrefab;

    //     if(!PhotonNetwork.IsMasterClient){
    //         playerIndex = 1;
    //         playerPrefab = playerClientPrefab;
    //     }

    //     return PhotonNetwork.Instantiate(
    //         playerPrefab.name, 
    //         playerSpawnerPoints[playerIndex].position, 
    //         playerSpawnerPoints[playerIndex].rotation
    //         ).transform;
    // }
}
