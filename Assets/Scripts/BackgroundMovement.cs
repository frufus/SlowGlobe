using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundMovement : MonoBehaviour
{

    public List<Sprite> BackGroundSprites;
	public List<Sprite> ParalaxDeepSea;
	public List<Sprite> ParalaxDeepToMid;
	public List<Sprite> ParalaxMidsee;
	public List<Sprite> ParalaxMidToSee;
	public List<Sprite> ParalaxSee;
	public List<Sprite> ParalaxSurface;
	public List<Sprite> ParalaxSky;
	public List<Sprite> ParalaxSkyeToSpace;
	public List<Sprite> ParalaxSpace;
    public GameObject BackgroundOne;
    public GameObject BackgroundTwo;
	public GameObject BackgroundThree;
	public GameObject BackgroundFour;
	public GameObject BackgroundFive;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;
    private bool canSpawnClouds = false;
	float offset = 0.75f;
	GameObject[] Layer1;
	GameObject[] Layer2;

    private GameObject fishController;
    private GameObject thunderController;
    private GameObject rocketController;
    private int indexOfSprite = 0;
    private  int currentStage;
	int allStages; 

    // Use this for initialization
    void Start()
    {

    }

	void Awake() {
		Debug.Log("Awake called.");
		Layer1 = new GameObject[]{BackgroundOne, BackgroundTwo};
		Layer2 = new GameObject[]{BackgroundThree, BackgroundFour, BackgroundFive};
		fishController = GameObject.Find("FishController");
		thunderController = GameObject.Find("ThunderController");
		rocketController = GameObject.Find("RocketController");
		//SpriteHight = BackgroundOne.GetComponent<SpriteRenderer>().bounds.max.y / 2;
		for (int i = 0; i < Layer1.Length; i++) {
			GameObject bg = Layer1 [i];
			allStages++;
			bg.transform.position = new Vector3 (bg.transform.position.x,  (bg.GetComponent<SpriteRenderer>().bounds.size.y * (i)) * 0.88f, 0);
		}
		for (int j = 0; j < Layer2.Length; j++) {
			GameObject bg = Layer2 [j];
			allStages++;
			if (bg.GetComponent<SpriteRenderer> ().sprite == null) {
				bg.GetComponent<SpriteRenderer> ().sprite = ParalaxDeepSea [Random.Range (0, ParalaxDeepSea.Count)];
			}

			bg.transform.position = new Vector3 (bg.transform.position.x, ((bg.GetComponent<SpriteRenderer> ().bounds.size.y) + bg.GetComponent<SpriteRenderer> ().bounds.size.y * (j)) * 0.88f, 0);
		}
	}

    // Update is called once per frame
    void Update()
    {
		MoveBackground (Layer1, 1f, true);
		MoveBackground (Layer2, offset, false);
	}


    private void chooseEnemyKind(GameObject BackGroundGO)
    {
        Debug.Log("CurrentStage: " + currentStage);
        if (currentStage <= GameController.Instance.DeepSeaNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[0];
            fishController.GetComponent<EnemyController>().EnableEnemies();

        }
        else if (currentStage <= GameController.Instance.DeepToMid && currentStage > GameController.Instance.DeepSeaNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[1];
            fishController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage <= GameController.Instance.MidseeNumber && currentStage > GameController.Instance.DeepToMid)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[2];
            fishController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage <= GameController.Instance.MidToSee && currentStage > GameController.Instance.MidseeNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[3];
            fishController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage <= GameController.Instance.SeeNumber && currentStage > GameController.Instance.MidToSee)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[4];
            fishController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage == GameController.Instance.SurfaceNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[5];
            //fishController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage <= GameController.Instance.SkyeNumber && currentStage > GameController.Instance.SurfaceNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[6];
            if(canSpawnClouds)
                thunderController.GetComponent<EnemyController>().EnableEnemies();
            canSpawnClouds = true;
        }

        else if (currentStage == GameController.Instance.SkyeToSpaceNumber)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[7];
            thunderController.GetComponent<EnemyController>().EnableEnemies();
        }
        else if (currentStage >= GameController.Instance.SpaceNumber && currentStage< GameController.Instance.SpaceNumber + 3)
        {
            if (BackGroundSprites.Count != 0)
                BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[8];
            rocketController.GetComponent<EnemyController>().EnableEnemies();
        }
        else
        {
            GameController.Instance.Bubble.GetComponent<Animator>().SetTrigger("CollidedWithEnemy");
            GameController.Instance.PauseTimer();
            StartCoroutine(StartGameOverStreen(.5f));
        }



    }
    private IEnumerator StartGameOverStreen(float waitseconds)
    {
        yield return new WaitForSeconds(waitseconds);
        GameController.Instance.Background.GetComponent<BackgroundMovement>().enabled = false;
        GameController.Instance.GameOverGO.SetActive(true);
        GameController.Instance.Win();
        Cursor.visible = true;
    }


    void MoveBackground (GameObject[] bgs, float off, bool isBG)
	{
		SpriteHight = bgs[0].GetComponent<SpriteRenderer>().bounds.size.y;
		int index = allStages;
		foreach (GameObject bg in bgs) {
			int bonus = !isBG ? 1 : 0;
			bg.GetComponent<SpriteRenderer> ().sortingOrder = index * -1 + bgs.Length + bonus;
			if (isBG) {
				Vector3 localspeed = Vector3.down * speed * off;
			} else {
				Vector3 localspeed = Vector3.down * speed * off * Random.Range (0.1f, 3f);
			}
				

			bg.transform.Translate (Vector3.down * speed *off);
			if (bg.transform.position.y + SpriteHight / bgs.Length < BorderDown.transform.position.y) {
				
				bg.transform.position = new Vector3 (bg.transform.position.x, bg.transform.position.y + (SpriteHight * bgs.Length) * 0.88f, 0);
				if (isBG) {
					currentStage++;
					chooseEnemyKind (bg);
				} else {
					changeParalax (bg);
				}

			}
			index--;
		}
	}

	void changeParalax(GameObject layer) {
		Sprite sprite = null;
		if (currentStage <= GameController.Instance.DeepSeaNumber) {
			sprite = ParalaxDeepSea [Random.Range (0, ParalaxDeepSea.Count)];
		} else if (currentStage <= GameController.Instance.DeepToMid && currentStage > GameController.Instance.DeepSeaNumber) {
			sprite = ParalaxDeepToMid [Random.Range (0, ParalaxDeepToMid.Count)];
		} else if (currentStage <= GameController.Instance.MidseeNumber && currentStage > GameController.Instance.DeepToMid) {
			sprite = ParalaxMidsee [Random.Range (0, ParalaxMidsee.Count)];
		} else if (currentStage <= GameController.Instance.MidToSee && currentStage > GameController.Instance.MidseeNumber) {
			sprite = ParalaxMidToSee [Random.Range (0, ParalaxMidToSee.Count)];
		} else if (currentStage <= GameController.Instance.SeeNumber && currentStage > GameController.Instance.MidToSee) {
			sprite = ParalaxSee [Random.Range (0, ParalaxSee.Count)];
		} else if (currentStage == GameController.Instance.SurfaceNumber) {
			sprite = ParalaxSurface [Random.Range (0, ParalaxSurface.Count)];
		} else if (currentStage <= GameController.Instance.SkyeNumber && currentStage > GameController.Instance.SurfaceNumber) {
			sprite = ParalaxSky[Random.Range(0, ParalaxSky.Count)];
		} else if (currentStage == GameController.Instance.SkyeToSpaceNumber) {
			sprite = ParalaxSky[Random.Range(0, ParalaxSky.Count)];
		} else if (currentStage >= GameController.Instance.SpaceNumber) {
			sprite = ParalaxSpace[Random.Range(0, ParalaxSpace.Count)];
		}

		if(sprite != null) {
			layer.GetComponent<SpriteRenderer> ().sprite = sprite;
			layer.GetComponent<SpriteRenderer> ().enabled = true;
		} else {
			layer.GetComponent<SpriteRenderer> ().enabled = false;
		}
	
	}
}
