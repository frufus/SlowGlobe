using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundMovement : MonoBehaviour
{

    public List<Sprite> BackGroundSprites;
    public GameObject BackgroundOne;
    public GameObject BackgroundTwo;
	public GameObject BackgroundThree;
	public GameObject BackgroundFour;
	public GameObject BackgroundFive;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;

	float offset = 0.5f;
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
			bg.transform.position = new Vector3 (bg.transform.position.x,  ((bg.GetComponent<SpriteRenderer>().bounds.size.y ) + bg.GetComponent<SpriteRenderer>().bounds.size.y * (j)) * 0.88f, 0);
		}
       

    }

    // Update is called once per frame
    void Update()
    {
		MoveBackground (Layer1, 1f, true);
		MoveBackground (Layer2, offset, false);
	}

	void MoveBackground (GameObject[] bgs, float off, bool isBG)
	{
		SpriteHight = bgs[0].GetComponent<SpriteRenderer>().bounds.size.y;
		int index = allStages;
		foreach (GameObject bg in bgs) {
			int bonus = !isBG ? 1 : 0;
			bg.GetComponent<SpriteRenderer> ().sortingOrder = index * -1 + bgs.Length + bonus;
			print (Mathf.FloorToInt(offset*2f).ToString());
			bg.transform.Translate (Vector3.down * speed *off);
			if (bg.transform.position.y + SpriteHight / bgs.Length < BorderDown.transform.position.y) {
				
				bg.transform.position = new Vector3 (bg.transform.position.x, bg.transform.position.y + (SpriteHight * bgs.Length) * 0.88f, 0);
				if (isBG) {
					currentStage++;
					chooseEnemyKind(bg);
				}

			}
			index--;
		}

	}

	private void chooseEnemyKind(GameObject BackGroundGO)
	{
		if(currentStage <= GameController.Instance.DeepSeaNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[0];
			fishController.GetComponent<EnemyController>().EnableEnemies();

		}
		else if (currentStage <= GameController.Instance.MidseeNumber && currentStage > GameController.Instance.DeepSeaNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[1];
			fishController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage <= GameController.Instance.SeeNumber &&  currentStage > GameController.Instance.MidseeNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[2];
			fishController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage == GameController.Instance.SurfaceNumber) 
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[3];
			//fishController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage <= GameController.Instance.SkyeNumber && currentStage > GameController.Instance.SurfaceNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[4];
			thunderController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage <= GameController.Instance.DarkskyNumber && currentStage > GameController.Instance.SkyeNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[5];
			thunderController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage == GameController.Instance.SkyeToSpaceNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[6];
			thunderController.GetComponent<EnemyController>().EnableEnemies();
		}
		else if (currentStage >= GameController.Instance.SpaceNumber)
		{
			if (BackGroundSprites.Count != 0)
				BackGroundGO.GetComponent<SpriteRenderer>().sprite = BackGroundSprites[7];
			rocketController.GetComponent<EnemyController>().EnableEnemies();
		}

	}
}
