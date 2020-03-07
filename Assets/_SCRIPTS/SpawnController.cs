using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private int qtdRats = 3;
    [SerializeField]
    private float waveRate;
    [SerializeField]
    private float initialSpawnRate;
    [SerializeField]
    private int qntRatsWave;

    public static List<Transform> spawnPoints = new List<Transform>();
    //public static Dictionary<Transform, bool> spawnPointsStatus = new Dictionary<Transform, bool>();

    public GameObject rat;

    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(GameManager.CONST_HOLE);

        foreach (GameObject point in gos)
        {
            spawnPoints.Add(point.transform);
            //spawnPointsStatus.Add(point.transform, true);
        }
        //SpawnRats();
        InvokeRepeating("StartWave", waveRate, waveRate);
    }

    public static void ChangeHoleStatus(Transform hole, bool status)
    {
        //SpawnController.spawnPointsStatus[hole] = status;
        if (status)
        {
            if (!spawnPoints.Contains(hole))
                spawnPoints.Add(hole);
        }
        else
        {
            spawnPoints.Remove(hole);
        }
    }

    void StartWave()
    {
        StartCoroutine(SpawnRats());
    }

    IEnumerator SpawnRats()
    {
        WaitForSeconds wait = new WaitForSeconds(initialSpawnRate);

        for (int x = 0; x < qtdRats; x++)
        {
            if (GameManager.Instance.gameOver)
            {
                CancelInvoke();
            }
            else
            {
                int hole = Random.Range(0, spawnPoints.Count);
                Instantiate(rat, spawnPoints[hole].position, Quaternion.identity);
            }
            yield return wait; 
        }

        
    }
}
