using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

  int rndNumberOfEnemyBirds;
  public List<GameObject> EnemyBirds;
  public bool BirdsCanMove = false;
  public GameObject enemy;
  private float spawnTime = 2f;

  private static BirdController instance = null;
  public static BirdController Instance
  {
    get
    {
      if (instance == null)
      {
        instance = GameObject.FindObjectOfType<BirdController>();
      }
      return instance;
    }
  }
  // Use this for initialization
  void Start () {
    CreateBirds();
    InvokeRepeating("EnableBirds", spawnTime, spawnTime);
    EnableBirds();
  }

  private void CreateBirds() {
    for (int i=0; i<50; i++) {
      EnemyBirds.Add(Instantiate(enemy));
      EnemyBirds[i].SetActive(false);
      EnemyBirds[i].GetComponent<EnemyMovement>().side = Random.Range(0,2);
    }
  }

  // Update is called once per frame
  void Update () {

  }

  public void EnableBirds()
  {
    rndNumberOfEnemyBirds = Random.Range(0, 5);
    int count = 0;
    for (int i = 0; i < EnemyBirds.Count; i++)
    {
      if (!EnemyBirds[i].activeInHierarchy) {
        Vector3 cp;
        if (EnemyBirds[i].GetComponent<EnemyMovement>().side == 0) {
          cp = new Vector3(0, Random.Range(Screen.height*2/3, Screen.height), 0);
        } else {
          cp = new Vector3(Screen.width, Random.Range(Screen.height*2/3, Screen.height), 0);
        }
        Vector3 wp = Camera.main.ScreenToWorldPoint(cp);
        wp.z = 0;
        EnemyBirds[i].transform.position = wp;
        EnemyBirds[i].SetActive(true);
        count++;
        if (count == rndNumberOfEnemyBirds) {
          break;
        }
      }
    }
  }
}
