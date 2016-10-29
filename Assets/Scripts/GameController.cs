using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public int CurrentHeight;
    //Anzahl an Tiefseehintergründen, wie oft sie wiederholt werden sollen
    public int DeepSeaNumber;
    //deep to mid
    public int DeepToMid;
    // Midsee Number
    public int MidseeNumber;
    //mid to normal
    public int MidToSee = 1;
    // Anzahl an Seehintergründen
    public int SeeNumber;
    // Oberfläche = 1
    public int SurfaceNumber = 1;
    // Himmel
    public int SkyeNumber;
    // darkskye
    public int SkyeToSpaceNumber;
    // Weltall
    public int SpaceNumber;


   

    private static GameController instance = null;
    public static GameController Instance
    {
        get

        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameController>();
            }
            return instance;
        }
    }

    void Awake()
    {
        DeepToMid = DeepSeaNumber + DeepToMid;
        MidseeNumber = DeepToMid + MidseeNumber;
        MidToSee = MidseeNumber + MidToSee;
        SeeNumber = MidToSee + SeeNumber;
        SurfaceNumber = SeeNumber + SurfaceNumber;
        SkyeNumber = SurfaceNumber + SkyeNumber;
        SkyeToSpaceNumber = SkyeNumber + SkyeToSpaceNumber;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
