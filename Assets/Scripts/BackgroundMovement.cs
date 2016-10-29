using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour
{

    
	public GameObject BackgroundOne;
	public GameObject BackgroundTwo;
	public GameObject BackgroundThree;
	public GameObject BackgroundFour;
	public GameObject BackgroundFive;
    public GameObject BorderDown;
    public float speed;
    public float SpriteHight;
    private Sprite spriteOne;
    int backgroundlayer = -4;
    int foregroundlayer = -3;
	float offset = 0.75f;
	GameObject[] Layer1;
	GameObject[] Layer2;

  
    
    // Use this for initialization
    void Start()
    {
		Layer1 = new GameObject[]{BackgroundOne, BackgroundTwo};
		Layer2 = new GameObject[]{BackgroundThree, BackgroundFour, BackgroundFive};
        //SpriteHight = BackgroundOne.GetComponent<SpriteRenderer>().bounds.max.y / 2;
		for (int i = 0; i < Layer1.Length; i++) {
			GameObject bg = Layer1 [i];
			bg.transform.position = new Vector3 (bg.transform.position.x,  (bg.GetComponent<SpriteRenderer>().bounds.size.y * (i)) * 0.88f, 0);
		}
		for (int j = 0; j < Layer2.Length; j++) {
			GameObject bg = Layer2 [j];
			bg.transform.position = new Vector3 (bg.transform.position.x,  ((bg.GetComponent<SpriteRenderer>().bounds.size.y ) + bg.GetComponent<SpriteRenderer>().bounds.size.y * (j)) * 0.88f, 0);
		}
       

    }

    // Update is called once per frame
    void Update()
    {
		
		MoveBackground (Layer1, 1f);
		MoveBackground (Layer2, offset);
		BackgroundOne.GetComponent<SpriteRenderer> ().sortingOrder = -4;
		BackgroundTwo.GetComponent<SpriteRenderer> ().sortingOrder = -5;
		BackgroundThree.GetComponent<SpriteRenderer> ().sortingOrder = -1;
		BackgroundFour.GetComponent<SpriteRenderer> ().sortingOrder = -2;
		BackgroundFive.GetComponent<SpriteRenderer> ().sortingOrder = -3;

    }


	void MoveBackground (GameObject[] bgs, float off)
	{
		SpriteHight = bgs[0].GetComponent<SpriteRenderer>().bounds.size.y;

		foreach (GameObject bg in bgs) {
			bg.transform.Translate (Vector3.down * speed *off);
			if (bg.transform.position.y + SpriteHight / bgs.Length < BorderDown.transform.position.y) {
				bg.transform.position = new Vector3 (bg.transform.position.x, bg.transform.position.y + (SpriteHight * bgs.Length) * 0.88f, 0);
			}
		}

	}
}
