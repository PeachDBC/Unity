using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    //[SerializeField]
   // private GameObject _powerupPrefab;
    [SerializeField]
    private bool _stopSpawning = false;
    [SerializeField]
    //private GameObject _speedPowerupPrefab;
    private GameObject[] powerups;



    // Start is called before the first frame update

    void Start()
    {
        GameObject.Find("Player").GetComponent<AudioSource>();
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }

    }
    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        while(_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            //newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }
    //IEnumerator SpawnSpeedBoostRoutine()
    //{
    //    while (_stopSpawning == false)
    //    {
    //        Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
    //    //    GameObject newSpeedPowerup = Instantiate(_speedPowerupPrefab, posToSpawn, Quaternion.identity);
    //        int randomTime = Random.Range(3, 8);
    //        yield return new WaitForSeconds(randomTime);
    //    }
            
    //}

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
