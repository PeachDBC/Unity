using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _powerupPrefab;
    [SerializeField]
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject _speedPowerupPrefab;
    private GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnSpeedBoostRoutine());
    }

    // Update is called once per frame


    IEnumerator SpawnEnemyRoutine()
    {
        
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
        while(_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newPowerup = Instantiate(_powerupPrefab, posToSpawn, Quaternion.identity);
            //newPowerup.transform.parent = _powerupContainer.transform;
            int randomTime = Random.Range(3, 8);
            yield return new WaitForSeconds(randomTime);
        }
    }
    IEnumerator SpawnSpeedBoostRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newSpeedPowerup = Instantiate(_speedPowerupPrefab, posToSpawn, Quaternion.identity);
            int randomTime = Random.Range(3, 8);
            yield return new WaitForSeconds(randomTime);
        }
            
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
