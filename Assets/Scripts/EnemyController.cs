using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

  int rndNumberOfEnemyList;
  public List<GameObject> EnemyList;
  public bool EnemyCanMove = false;
  public GameObject enemy;

  private static EnemyController instance = null;
  public static EnemyController Instance
  {
    get
    {
      if (instance == null)
      {
        instance = GameObject.FindObjectOfType<EnemyController>();
      }
      return instance;
    }
  }
  // Use this for initialization
  void Start () {
    CreateEnemies();
  }

  private void CreateEnemies() {
    for (int i=0; i<50; i++) {
      EnemyList.Add(Instantiate(enemy));
      EnemyList[i].SetActive(false);
      EnemyList[i].GetComponent<EnemyMovement>().side = Random.Range(0,2);
    }
  }

  // Update is called once per frame
  void Update () {

  }

  public void EnableEnemies()
  {
    //InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
		SpawnEnemies();
	}

  private void SpawnEnemies() {
    rndNumberOfEnemyList = Random.Range(0, 5);
    int count = 0;
    for (int i = 0; i < EnemyList.Count; i++)
    {
      if (!EnemyList[i].activeInHierarchy) {
        if (count == rndNumberOfEnemyList) {
          break;
        }

        Vector3 cp;
        if (EnemyList[i].GetComponent<EnemyMovement>().side == 0) {
          cp = new Vector3(0, Random.Range(Screen.height*2/3, Screen.height - Screen.height*1/5), 0);
        } else {
          cp = new Vector3(Screen.width, Random.Range(Screen.height*2/3, Screen.height - Screen.height*1/5), 0);
        }
        Vector3 wp = Camera.main.ScreenToWorldPoint(cp);
        wp.z = 0;
        EnemyList[i].transform.position = wp;
        EnemyList[i].SetActive(true);
        count++;
      }
    }
  }
}
