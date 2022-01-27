using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    private Transform playerTransform;

    //Shapes
    [SerializeField] private GameObject[] clouds=null;
    [SerializeField] private int maxClouds=5;
    private int startingCloudsAmount;

    [SerializeField] private GameObject[] crowns = null;
    [SerializeField] private int maxCrowns=5;
    private int startingCrownsAmount;

    [SerializeField] private GameObject[] shards = null;
    [SerializeField] private int maxShards = 5;
    private int startingShardsAmount;

    [SerializeField] private GameObject[] tubes = null;
    [SerializeField] private int maxTubes = 5;
    private int startingTubesAmount;

    [SerializeField] private GameObject logoObject = null;

    [SerializeField] private float spawnDistance=5f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float collisionForce = 1f;

    private List<int> ShardPresetNumbers=new List<int>();
    private List<int> CloudPresetNumbers = new List<int>();
    private List<int> CrownPresetNumbers = new List<int>();
    private List<int> TubePresetNumbers = new List<int>();
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnObjects();
        InvokeRepeating("CheckMissingObjects", 10, Random.Range(10f, 20f));
    }
    private void SpawnObjects()
    {
        ShardPresetNumbers = StaticValues.GetShardPresetNumbers();
        CloudPresetNumbers = StaticValues.GetCloudPresetNumbers();
        CrownPresetNumbers = StaticValues.GetCrownPresetNumbers();
        TubePresetNumbers = StaticValues.GetTubePresetNumbers();

        maxShards = ShardPresetNumbers.Count;
        maxClouds = CloudPresetNumbers.Count;
        maxCrowns = CrownPresetNumbers.Count;
        maxTubes = TubePresetNumbers.Count;

        startingCloudsAmount = (int)(maxClouds * 0.75f);
        startingShardsAmount = (int)(maxShards * 0.75f);
        startingCrownsAmount = (int)(maxCrowns * 0.75f);
        startingTubesAmount = (int)(maxTubes * 0.75f);

        for (int i = 0; i < startingShardsAmount; i++)
        {
            StartCoroutine(SpawnParams(shards[ShardPresetNumbers[Random.Range(0, ShardPresetNumbers.Count)]-1],true));
        }
        for (int i = 0; i < startingTubesAmount; i++)
        {
            StartCoroutine(SpawnParams(tubes[TubePresetNumbers[Random.Range(0, TubePresetNumbers.Count)] - 1],true));
        }
        for (int i = 0; i < startingCrownsAmount; i++)
        {
            StartCoroutine(SpawnParams(crowns[CrownPresetNumbers[Random.Range(0, CrownPresetNumbers.Count)] - 1],true));
        }
        for (int i = 0; i < startingCloudsAmount; i++)
        {
            StartCoroutine(SpawnParams(clouds[CloudPresetNumbers[Random.Range(0, CloudPresetNumbers.Count)] - 1],false));
        }
        StartCoroutine(SpawnParams(logoObject, false));
    }

    IEnumerator SpawnParams(GameObject obj, bool hasAnimator)
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Quaternion spawnRotation = Random.rotation;
        Vector3 spawnPosition = Random.onUnitSphere * (spawnDistance) + playerTransform.position;
        obj = Instantiate(obj, spawnPosition, spawnRotation) as GameObject;
        FloatingObject floatTemp = obj.AddComponent<FloatingObject>();
        floatTemp.SetIdleSpeed(maxSpeed);
        floatTemp.SetCollisionForce(collisionForce);
        obj.GetComponent<Rigidbody>().useGravity = false;

        if(hasAnimator)
        {
            //Apply animator
            obj.AddComponent<ShapeAnimator>();
        }
    }

    private void CheckMissingObjects()
    {

        if (GameObject.FindGameObjectsWithTag("Shard").Length < maxShards)
        {
            StartCoroutine(SpawnParams(shards[ShardPresetNumbers[Random.Range(0, ShardPresetNumbers.Count)] - 1], true));
            return;            
        }
        if (GameObject.FindGameObjectsWithTag("Cloud").Length < maxClouds)
        {
            StartCoroutine(SpawnParams(clouds[CloudPresetNumbers[Random.Range(0, CloudPresetNumbers.Count)] - 1], false));
            return;
        }
        if (GameObject.FindGameObjectsWithTag("Crown").Length < maxCrowns)
        {
            StartCoroutine(SpawnParams(crowns[CrownPresetNumbers[Random.Range(0, CrownPresetNumbers.Count)] - 1], true));
            return;
        }
        if (GameObject.FindGameObjectsWithTag("Tube").Length < maxTubes)
        {
            StartCoroutine(SpawnParams(tubes[TubePresetNumbers[Random.Range(0, TubePresetNumbers.Count)] - 1], true));
            return;
        }

    }

}
