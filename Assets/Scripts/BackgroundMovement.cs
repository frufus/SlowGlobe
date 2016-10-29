using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundMovement : MonoBehaviour
{

    public List<Sprite> BackGroundSprites;
    public GameObject BackgroundOne;
    public GameObject BackGroundTwo;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;
    int backgroundlayer = -2;
    int foregroundlayer = -1;

    private GameObject fishController;
    private GameObject thunderController;
    private GameObject rocketController;
    private int indexOfSprite = 0;
    private  int currentStage;

    // Use this for initialization
    void Start()
    {
        fishController = GameObject.Find("FishController");
        thunderController = GameObject.Find("ThunderController");
        rocketController = GameObject.Find("RocketController");
        //SpriteHight = BackgroundOne.GetComponent<SpriteRenderer>().bounds.max.y / 2;
        SpriteHight = BackgroundOne.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundOne.transform.Translate(Vector3.down * speed);
        BackGroundTwo.transform.Translate(Vector3.down * speed);
        if (BackgroundOne.transform.position.y + SpriteHight/2 < BorderDown.transform.position.y)
        {
            currentStage++;
            BackgroundOne.transform.position = new Vector3(BackgroundOne.transform.position.x, BackGroundTwo.transform.position.y + SpriteHight * 0.88f, 0);
            BackgroundOne.GetComponent<SpriteRenderer>().sortingOrder = backgroundlayer;
            BackGroundTwo.GetComponent<SpriteRenderer>().sortingOrder = foregroundlayer;
            fishController.GetComponent<EnemyController>().EnableEnemies();
            chooseEnemyKind(BackgroundOne);
        }
        if (BackGroundTwo.transform.position.y + SpriteHight / 2 < BorderDown.transform.position.y)
        {
            currentStage++;
            BackGroundTwo.GetComponent<SpriteRenderer>().sortingOrder = backgroundlayer;
            BackgroundOne.GetComponent<SpriteRenderer>().sortingOrder = foregroundlayer;
            BackGroundTwo.transform.position = new Vector3(BackGroundTwo.transform.position.x, (BackgroundOne.transform.position.y + SpriteHight * 0.88f), 0);
            chooseEnemyKind(BackGroundTwo);
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
