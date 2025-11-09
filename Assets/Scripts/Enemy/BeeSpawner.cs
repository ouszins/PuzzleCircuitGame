/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject beePrefab;

    [SerializeField] private float beeInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBee(beeInterval, beePrefab));
        //tutorial for some reason inculded a big version of the bee. 
        //we do not *have* a big version of the enemy bee.


        //small enemy bee. (insert jerma beatbox)
    }

    // Update is called once per frame
    //   commenting out the following for now. gonna work on it more later.
    void IEnumerator spawnBee(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(beeInterval);
        GameObject newBee = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnBee(beeInterval, enemy));
    }
}

*/
