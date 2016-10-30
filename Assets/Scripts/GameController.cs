using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float Timer = 0;
    public GameObject Bubble;
    public GameObject GameOverGO;
    public GameObject Background;
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

    private bool pauseTimer = false;
    public Text TimerText;


   

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
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pauseTimer)
        {
            Timer = Timer + Time.deltaTime;
        }
        TimerText.text = "Du hast die Babbel " + Timer.ToString("n2") +  "s vor Trouble beschützt.";

    }

    public void PauseTimer()
    {
        pauseTimer = true;
        
    }
}
