using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int amount;
        public float rate;


    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    private int nextWave = 0;

    public float timeBetweenWaves = 3f;
    public float waveCountdown = 0f;
    //UI
    public TextMeshProUGUI RoundsText;
    public TextMeshProUGUI underText;
    //Player death/respawn
    public GameObject player1;
    public GameObject player2;


    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Point reference");
        }

        waveCountdown = timeBetweenWaves;
    }


    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }


        void WaveCompleted()
        {
            Debug.Log("Wave Completed");
            RoundsText.text = "Wave Completed";

            state = SpawnState.COUNTING;
            waveCountdown = timeBetweenWaves;

            if (nextWave + 1 > waves.Length - 1)
            {
                nextWave = 0;
                Debug.Log("All waves Complete");
            }
            else
            {
                nextWave++;
            }

        }

        bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;
            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }


            return true;
        }

        IEnumerator SpawnWave(Wave _wave)
        {
           
            Debug.Log("Spawning Wave" + _wave.name);
            state = SpawnState.SPAWNING;

            
            
            

            for (int i = 0; i < _wave.amount; i++)
            {
                StartCoroutine(Showtext(_wave.name));
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(1f / _wave.rate);
                player1.SetActive(true);
                player2.SetActive(true);
                Setplayersactive(player1, player2);

            }

            state = SpawnState.WAITING;
            underText.text = "Kill all The Ghouls!";

            yield break;
        }

        IEnumerator Showtext(string wave)
        {
            RoundsText.text = wave;
            underText.text = "Spawning Ghouls";
            yield return new WaitForSeconds(2f);
            RoundsText.text = "";
            underText.text = "";
        }

        void SpawnEnemy(Transform _enemy)
        {

            Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];

            Instantiate(_enemy, _sp.position, _sp.rotation);
           
        }
        void Setplayersactive(GameObject p1, GameObject p2){

            PlayerHealth playerhealth = player1.GetComponent<PlayerHealth>();
            PlayerHealth playerhealth2 = player2.GetComponent<PlayerHealth>();

            p1.SetActive(true);
            p2.SetActive(true);
            playerhealth.curHealth = 100f;
            playerhealth2.curHealth = 100f;
        }
    }
}
