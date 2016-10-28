using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour
{

    public GameObject BackgroundOne;
    public GameObject BackGroundTwo;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;
    
    // Use this for initialization
    void Start()
    {
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
            BackgroundOne.transform.position = new Vector3(BackgroundOne.transform.position.x, BackGroundTwo.transform.position.y + SpriteHight, 0);
        }
        if (BackGroundTwo.transform.position.y + SpriteHight / 2 < BorderDown.transform.position.y)

        {

            BackGroundTwo.transform.position = new Vector3(BackGroundTwo.transform.position.x, (BackgroundOne.transform.position.y + SpriteHight), 0);
        }

    }


}
