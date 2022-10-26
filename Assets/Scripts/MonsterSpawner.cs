using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] monsterReferences;

    private GameObject spawnedMoster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0, monsterReferences.Length);
            randomSide = Random.Range(0,2);

            spawnedMoster = Instantiate(monsterReferences[randomIndex]);

            if(randomSide == 0)
            {
                spawnedMoster.transform.position = leftPos.position;
                spawnedMoster.GetComponent<Monster>().speed = Random.Range(4,10);
            }
            else
            {
                spawnedMoster.transform.position = rightPos.position;
                spawnedMoster.GetComponent<Monster>().speed = -Random.Range(4,10);
                spawnedMoster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
