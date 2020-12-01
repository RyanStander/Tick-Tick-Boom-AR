using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    private Transform playerTransform;

    //Shapes
    [SerializeField] private GameObject[] clouds=null;
    [SerializeField] private int minClouds;
    [SerializeField] private int maxClouds;
    [SerializeField] private int totalClouds=5;

    [SerializeField] private GameObject[] crowns = null;
    [SerializeField] private int minCrowns;
    [SerializeField] private int maxCrowns;
    [SerializeField] private int totalCrowns=5;

    [SerializeField] private GameObject[] shards = null;
    [SerializeField] private int minShards;
    [SerializeField] private int maxShards;
    [SerializeField] private int totalShards = 5;

    [SerializeField] private GameObject[] tubes = null;
    [SerializeField] private int minTubes;
    [SerializeField] private int maxTubes;
    [SerializeField] private int totalTubes = 5;

    [SerializeField] private float spawnDistance=5f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float collisionForce = 1f;
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnObjects();
    }
    private void SpawnObjects()
    {       
        for (int i = 0; i < totalShards; i++)
        {
            StartCoroutine(SpawnParams(shards[Random.Range(0, shards.Length)],true));
        }
        for (int i = 0; i < totalTubes; i++)
        {
            StartCoroutine(SpawnParams(tubes[Random.Range(0, tubes.Length)],true));
        }
        for (int i = 0; i < totalCrowns; i++)
        {
            StartCoroutine(SpawnParams(crowns[Random.Range(0, crowns.Length)],true));
        }
        for (int i = 0; i < totalClouds; i++)
        {
            StartCoroutine(SpawnParams(clouds[Random.Range(0, clouds.Length)],false));
        }
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

}
