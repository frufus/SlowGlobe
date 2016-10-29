using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

  int rndNumberOfEnemyBirds;
  public List<GameObject> EnemyBirds;
  public bool BirdsCanMove = false;
  public GameObject enemy;

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
    EnableBirds();
  }

  private void CreateBirds() {
    for (int i=0; i<100; i++) {
      EnemyBirds.Add(Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity));
      EnemyBirds[i].SetActive(false);
      EnemyBirds[i].GetComponent<EnemyMovement>().side = Random.Range(0,2);
    }
  }

  // Update is called once per frame
  void Update () {

  }

  public void EnableBirds()
  {
    rndNumberOfEnemyBirds = Random.Range(0, EnemyBirds.Count);
    for (int i = 0; i <= rndNumberOfEnemyBirds; i++)
    {
      Vector3 cp;
      if (EnemyBirds[i].GetComponent<EnemyMovement>().side == 0) {
        cp = new Vector3(0, Random.Range(0, Screen.height), 0);
      } else {
        cp = new Vector3(Screen.width, Random.Range(0, Screen.height), 0);
      }
      Vector3 wp = Camera.main.ScreenToWorldPoint(cp);
      wp.z = 0;
      EnemyBirds[i].transform.position = wp;
      EnemyBirds[i].SetActive(true);
    }
  }
}
