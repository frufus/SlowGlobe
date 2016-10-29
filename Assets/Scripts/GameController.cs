using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public int CurrentHeight;
    //Anzahl an Tiefseehintergründen, wie oft sie wiederholt werden sollen
    public int DeepSeaNumber;
    // Anzahl an Seehintergründen
    public int SeeNumber;
    // Oberfläche = 1
    public int SurfaceNumber = 1;
    // Himmel
    public int SkyeNumber;
    // Übergang Himmel zu Weltall
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
        SeeNumber = DeepSeaNumber + SeeNumber;
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
