using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour
{

    
	public GameObject BackgroundOne;
	public GameObject BackgroundTwo;
	public GameObject BackgroundThree;
	public GameObject BackgroundFour;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;
    int backgroundlayer = -4;
    int foregroundlayer = -3;
	float offset = 0.75f;

  
    
    // Use this for initialization
    void Start()
    {

        //SpriteHight = BackgroundOne.GetComponent<SpriteRenderer>().bounds.max.y / 2;
        
       

    }

    // Update is called once per frame
    void Update()
    {
		MoveBackground (BackgroundOne, BackgroundTwo, 1f);
		MoveBackground (BackgroundThree, BackgroundFour, offset);
		BackgroundOne.GetComponent<SpriteRenderer> ().sortingOrder = -4;
		BackgroundTwo.GetComponent<SpriteRenderer> ().sortingOrder = -3;
		BackgroundThree.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		BackgroundFour.GetComponent<SpriteRenderer> ().sortingOrder = -1;

    }


	void MoveBackground (GameObject bg1, GameObject bg2, float off)
	{
		SpriteHight = bg1.GetComponent<SpriteRenderer>().bounds.size.y * off;

		bg1.transform.Translate (Vector3.down * speed *off);
		bg2.transform.Translate (Vector3.down * speed *off);
		if (bg1.transform.position.y + SpriteHight / 2 < BorderDown.transform.position.y) {
			bg1.transform.position = new Vector3 (bg1.transform.position.x, bg2.transform.position.y + SpriteHight * 0.88f, 0);
		}
		if (bg2.transform.position.y + SpriteHight / 2 < BorderDown.transform.position.y) {
			bg2.transform.position = new Vector3 (bg2.transform.position.x, (bg1.transform.position.y + SpriteHight * 0.88f), 0);
		}
	}
}
