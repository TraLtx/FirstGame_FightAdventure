using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Photon.Pun;

public class GameController : GameMonoBehaviour
{
    protected static GameController instance;
    public static GameController Instance {get => instance;}

    //---Game Object-------------------------------------------------------------
    [SerializeField] protected Camera camera;
    [SerializeField] protected Transform sceneChanger;

    [SerializeField] protected Transform playerPrefab;
    [SerializeField] protected Transform enemyPrefab;


    [SerializeField] protected Tilemap tileBackGround;
    public Tilemap TileBackGround {get => this.tileBackGround;}

    [SerializeField] protected Transform pnlYouDie;
    public Transform PnlYouDie => this.pnlYouDie;

    [SerializeField] protected PausePanel pnlPause;
    [SerializeField] protected PassLevelPanel pnlPassLevel;


    // [SerializeField] protected GameObject playerServerPrefab;
    // [SerializeField] protected GameObject playerClientPrefab;

    //---Variable--------------------------------------------------------------

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
        this.LoadPnlPause();
        this.LoadPnlPassLevel();
        this.LoadScreenRange();
        this.LoadCamera();
        this.LoadSceneChanger();
    }

    protected virtual void LoadTileBackGround(){
        if(this.tileBackGround != null) return;
        this.tileBackGround = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
    }

    protected virtual void LoadPnlYouDie(){
        this.pnlYouDie = GameObject.Find("MainCanvas").transform.Find("Pnl_YouDie");
        this.pnlYouDie.gameObject.SetActive(false);
    }

    protected virtual void LoadPnlPause(){
        if(this.pnlPause != null) return;
        this.pnlPause = GameObject.Find("MainCanvas").transform.Find("Pnl_Pause").GetComponent<PausePanel>();
    }

    protected virtual void LoadPnlPassLevel(){
        if(this.pnlPassLevel != null) return;
        this.pnlPassLevel = GameObject.Find("MainCanvas").GetComponentInChildren<PassLevelPanel>();
    }

    protected virtual void LoadScreenRange(){
        BoundsInt cellBounds = this.tileBackGround.cellBounds;

        Vector3Int amountCell = cellBounds.size;
        float tileSize = this.tileBackGround.GetSprite(cellBounds.position).bounds.size.x;
        float tileSizeOffset = tileSize / 2 - 0.5f;

        screenMinPoint = cellBounds.position - new Vector3(tileSizeOffset, tileSizeOffset, 0);
        screenMaxPoint = cellBounds.position + new Vector3(amountCell.x + tileSizeOffset, amountCell.y + tileSizeOffset, 0);
    }

    protected virtual void LoadCamera(){
        this.camera = Transform.FindObjectOfType<Camera>();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").transform;
    }
    
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
        BoxPowerSpawner.Instance.SpawnBoxPowerAllPoints();
    }

    //======PUBLIC METHODs===============================================================
    public virtual void ShowDieMenu(){
        this.pnlYouDie.gameObject.SetActive(true);
    }

    public virtual void RestartGame(){
        Time.timeScale = 1;
        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene(SceneManager.GetActiveScene().name);
    }

    public virtual void PauseGame(){
        Time.timeScale = 0;
        this.pnlPause.Show();
    }

    public virtual void ContinueGame(){
        Time.timeScale = 1;
        this.pnlPause.Hide();
    }

    public virtual void GotoSceneLevelMenu(){
        Time.timeScale = 1;
        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene(Constant.SCENE_LEVEL_MENU);
    }

    public virtual void PassLevel(){
        int coins = this.thisPlayer.GetComponent<PlayerCtrl>().GetCoinCollect();
        int coinTotal = EnemySpawner.Instance.CountSpawnPoint();
        this.pnlPassLevel.SetCoinsTotal(coins, coinTotal);
        this.pnlPassLevel.ShowPanel();
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
