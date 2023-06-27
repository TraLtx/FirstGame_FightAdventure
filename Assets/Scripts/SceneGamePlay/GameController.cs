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

    [SerializeField] protected AudioSource _audioSource;

    //---Game Object-------------------------------------------------------------
    [SerializeField] protected Camera camera;
    [SerializeField] protected Transform sceneChanger;

    [SerializeField] protected Transform playerPrefab;
    [SerializeField] protected Transform enemyPrefab;


    [SerializeField] protected Tilemap tileBackGround;
    public Tilemap TileBackGround {get => this.tileBackGround;}

    [SerializeField] protected Transform pnlYouDie;
    [SerializeField] protected PanelDie pnlDie;
    [SerializeField] protected PausePanel pnlPause;
    [SerializeField] protected PassLevelPanel pnlPassLevel;
    [SerializeField] protected ParticleSystem passLevelParticle;


    // [SerializeField] protected GameObject playerServerPrefab;
    // [SerializeField] protected GameObject playerClientPrefab;


    //---Variable--------------------------------------------------------------

    [SerializeField] protected int playingLevel;
    //Set By Your Hand
    [SerializeField] protected AudioClip dieClip;
    [SerializeField] protected AudioClip passClip;
    //-------------------------------------------
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

    protected override void LoadComponents(){Debug.Log("Gamecontroller.LoadComponents()");
        base.LoadComponents();
        this.LoadAudioSource();
        this.LoadTileBackGround();
        this.LoadPnlYouDie();
        this.LoadPnlDie();
        this.LoadPnlPause();
        this.LoadPnlPassLevel();
        this.LoadParticlePassLevel();
        this.LoadScreenRange();
        this.LoadCamera();
        this.LoadSceneChanger();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }
    protected virtual void LoadTileBackGround(){
        if(this.tileBackGround != null) return;
        this.tileBackGround = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
    }
    protected virtual void LoadPnlYouDie(){
        this.pnlYouDie = GameObject.Find("MainCanvas").transform.Find("Pnl_YouDie");
        this.pnlYouDie.gameObject.SetActive(true);
    }
    protected virtual void LoadPnlDie(){
        if(this.pnlDie == null){
            this.pnlDie = GameObject.Find("MainCanvas").GetComponentInChildren<PanelDie>();
        }
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

    protected virtual void LoadParticlePassLevel(){
        if(this.passLevelParticle != null) return;
        this.passLevelParticle = GameObject.Find("PassLevelParticle").GetComponent<ParticleSystem>();
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
    
    protected virtual void Start(){Debug.Log("Gamecontroller.Start()");
        this.SetPlayingLevel();
        this.SpawnThisPlayer();
        this.SpawnEnemy();
        this.SpawnEnemyGrenade();
        this.SpawnObject();
        this._audioSource.PlayDelayed(1f);
        // Physics2D.IgnoreCollision(this.playerPrefab.GetComponent<Collider2D>(), this.enemyPrefab.GetComponent<Collider2D>(), true);
    }


    public virtual void SetPlayingLevel(){
        this.playingLevel = PlayerPrefs.GetInt(Constant.PLAYING_LEVEL);
    }

    protected virtual void SpawnThisPlayer(){Debug.Log("Gamecontroller.SpawnThisPlayer()");

        // if(!isOnlineState){
        //     thisPlayer = this.SpawnPlayerOffline();
        // }else{
        //     thisPlayer = this.SpawnPlayerOnline();
        // }

        PlayerSpawner playerSpawner = PlayerSpawner.Instance;
        
        if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 1){
            // thisPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Box_Char_Green");
            thisPlayer = playerSpawner.Spawn(PlayerSpawner.player_2, PlayerSpawner.spawnPointServer);
        }else if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 2){
            // thisPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Box_Char_Yellow");
            thisPlayer = playerSpawner.Spawn(PlayerSpawner.player, PlayerSpawner.spawnPointServer);
        }
        
        // thisPlayer.gameObject.SetActive(true);

        camera.GetComponent<CameraFollowTarget>().SetTarget(thisPlayer);
    }

    protected virtual void SpawnEnemy(){Debug.Log("Gamecontroller.SpawnEnemy()");
        EnemySpawner.Instance.SpawnEnemyAllPoints(); 
    }
    protected virtual void SpawnEnemyGrenade(){
        EnemyGrenadeSpawner.Instance.SpawnEnemyAllPoints(); 
    }

    protected virtual void SpawnObject(){
        BoxGunSpawner.Instance.SpawnBoxGunAllPoints(); 
        BoxHeartSpawner.Instance.SpawnBoxHeartAllPoints();
        BoxPowerSpawner.Instance.SpawnBoxPowerAllPoints();
    }

    //======PUBLIC METHODs===============================================================
    public virtual void Die(){Debug.Log("Die Then Save Data=========================");

        int coins = this.thisPlayer.GetComponent<PlayerCtrl>().GetCoinCollect();
        int playerCoins = PlayerPrefs.GetInt(Constant.SAVE_COINS);
        playerCoins += coins;
        PlayerPrefs.SetInt(Constant.SAVE_COINS, playerCoins);

        int boxGuns = this.thisPlayer.GetComponent<PlayerCtrl>().GetBoxGunCollect();
        int playerBoxGuns = PlayerPrefs.GetInt(Constant.SAVE_BOX_GUN);
        playerBoxGuns += boxGuns;
        PlayerPrefs.SetInt(Constant.SAVE_BOX_GUN, playerBoxGuns);

        int boxPowers = this.thisPlayer.GetComponent<PlayerCtrl>().GetBoxPowerCollect();
        int playerBoxPowers = PlayerPrefs.GetInt(Constant.SAVE_BOX_POWER);
        playerBoxPowers += boxPowers;
        PlayerPrefs.SetInt(Constant.SAVE_BOX_POWER, playerBoxPowers);

        this.ShowPanelYouDie();
        this.pnlDie.SetCoinsCollect(coins);
        this.pnlDie.SetBoxGunsCollect(boxGuns);
        this.pnlDie.SetBoxPowersCollect(boxPowers);

        this._audioSource.clip = this.dieClip;
        this._audioSource.volume = 1;
        this._audioSource.Play();
    }

    public virtual void ShowPanelYouDie(){
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

    public virtual void NextLevel(){
        Time.timeScale = 1;
        int nextLevel = this.playingLevel + 1;
        //NOT OFFICAL
        if(nextLevel == 4){
            this.GotoSceneLevelMenu();
            return;
        }
        //---------------
        PlayerPrefs.SetInt(Constant.PLAYING_LEVEL, nextLevel);

        Debug.Log("NextLevel: "+nextLevel);

        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene("Level_"+nextLevel);
    }

    public virtual void PassLevel(){
        Time.timeScale = 0;
        
        PlayerPrefs.SetInt(Constant.SAVE_UNLOCK_LEVEL, this.playingLevel + 1);

        int coins = this.thisPlayer.GetComponent<PlayerCtrl>().GetCoinCollect();
        int coinTotal = EnemySpawner.Instance.CountSpawnPoint() * 10; //10 = point of each coin
        coinTotal += EnemyGrenadeSpawner.Instance.CountSpawnPoint() * 10;
        this.pnlPassLevel.SetCoinsTotal(coins, coinTotal);
        int playerCoins = PlayerPrefs.GetInt(Constant.SAVE_COINS);
        playerCoins += coins;
        PlayerPrefs.SetInt(Constant.SAVE_COINS, playerCoins);

        int boxGuns = this.thisPlayer.GetComponent<PlayerCtrl>().GetBoxGunCollect();
        int boxGunTotal = BoxGunSpawner.Instance.CountSpawnPoint() * 10;
        this.pnlPassLevel.SetBoxGunsTotal(boxGuns, boxGunTotal);
        int playerBoxGuns = PlayerPrefs.GetInt(Constant.SAVE_BOX_GUN);
        playerBoxGuns += boxGuns;
        PlayerPrefs.SetInt(Constant.SAVE_BOX_GUN, playerBoxGuns);

        int boxPowers = this.thisPlayer.GetComponent<PlayerCtrl>().GetBoxPowerCollect();
        int boxPowerTotal = BoxPowerSpawner.Instance.CountSpawnPoint() * 10;
        this.pnlPassLevel.SetBoxPowersTotal(boxPowers, boxPowerTotal);
        int playerBoxPowers = PlayerPrefs.GetInt(Constant.SAVE_BOX_POWER);
        playerBoxPowers += boxPowers;
        PlayerPrefs.SetInt(Constant.SAVE_BOX_POWER, playerBoxPowers);

        this.PlayParticle();
        this.pnlPassLevel.ShowPanel();

        this._audioSource.clip = this.passClip;
        this._audioSource.volume = 1;
        this._audioSource.Play();
    }

    protected virtual void PlayParticle(){

        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        passLevelParticle.transform.position = new Vector3((topLeft.x + topRight.x)/2, topLeft.y, 0);
        passLevelParticle.Play();

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
