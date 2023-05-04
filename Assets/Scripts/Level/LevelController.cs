using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // [SerializeField]
    // private GameObject[] tilePrefabs;

    // [SerializeField]
    // private GameObject camera;

    // private Dictionary<Point, TileScrip> allTiles {get; set;}

    // // Start is called before the first frame update
    // void Start()
    // {
    //     CreateLevel();
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void CreateLevel(){

    //     float tileWidth = tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        
    //     string[] mapData = GetMapFromText("lv1");
    //     int mapSizeX = mapData[0].ToCharArray().Length;
    //     int mapSizeY = mapData.Length;

    //     Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height));
    //     //Toa do Top-Left of the Wolrd
    //     float wolrdMinX = worldStart.x;
    //     float wolrdMinY = worldStart.y - mapSizeY*tileWidth;
    //     //Toa do Bottom-Right of the world
    //     float wolrdMaxX = worldStart.x + mapSizeX*tileWidth;
    //     float wolrdMaxY = worldStart.y;

    //     camera.GetComponent<CameraMovement>().SetMoveRange(wolrdMinX, wolrdMinY, wolrdMaxX, wolrdMaxY);

    //     allTiles = new Dictionary<Point, TileScrip>();
    //     PlaceAllTile(mapData, mapSizeX, mapSizeY, worldStart, tileWidth);
        
    // }

    // private string[] GetMapFromText(string fileName){
    //     TextAsset bindData = Resources.Load(fileName) as TextAsset;
    //     string data = bindData.text.Replace(Environment.NewLine, string.Empty);

    //     return data.Split('-');
    // }

    // private void PlaceAllTile(string[] mapData, int mapSizeX, int mapSizeY, Vector3 worldStart, float tileWidth){

    //     for(int y = 0; y < mapSizeY; y++){
    //         char[] rowContent = mapData[y].ToCharArray();

    //         for(int x = 0; x < mapSizeX; x++){

    //             int tileIndex = int.Parse(rowContent[x].ToString());
    //             TileScrip newTileScrip = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScrip>();

    //             Vector3 newTileWorldPosition = new Vector3 (worldStart.x + x*tileWidth, worldStart.y - y*tileWidth, 0);
    //             Point newTilePoint = new Point(y,x);

    //             newTileScrip.CreateInWolrd(newTilePoint, newTileWorldPosition);

    //             allTiles.Add(newTilePoint, newTileScrip);
    //         }
    //     }
    // }
}