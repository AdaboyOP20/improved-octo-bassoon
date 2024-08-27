using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;


public class MovingPlatform : MonoBehaviour
{
    public GameObject platformPrefab;
    public Coordinates coordinateGenerator;
    public int platformCount;
    public Text scoreText;
    private GameObject currentPlatform;
    private GameObject previousPlatform;
    private int thingsRemoved;
    private int thingsAdded;


    void Start()
    {
        StartCoroutine(SpawnPlatform());
        StartCoroutine(DestroyPlatformRoutine(platformPrefab));
        StartCoroutine(Score());
    }
    
    private IEnumerator Score()
    {
        int count = 0;

        yield return new WaitForSeconds(2.5f);
        count += 1;
        scoreText.text = "Score: " + count.ToString();        
    }
    
    void Update()
    {
    }

    private IEnumerator SpawnPlatform()
    {
        // Get the spawn position using the coordinate generator
        Vector3 spawnPosition = coordinateGenerator.GetRandomEdgeCoordinate();
        yield return new WaitForSeconds(2.5f);
        if(platformCount == 1){
            if(thingsAdded == thingsRemoved){
                currentPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                coordinateGenerator.currentPlatform = spawnPosition;
                platformCount++;
            }
        }
        // Instantiate the new platform
        currentPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        coordinateGenerator.currentPlatform = spawnPosition;
        platformCount++;
        thingsAdded++;

        // Start the coroutine to destroy the previous platform after a delay
        if (currentPlatform != null)
        {
            StartCoroutine(DestroyPlatformRoutine(currentPlatform));
        }
    }

    private IEnumerator DestroyPlatformRoutine(GameObject platform)
    {
        // Wait for a random time between 4 and 5 seconds
        float randomTime = Random.Range(4f, 4f);
        yield return new WaitForSeconds(randomTime);

        // Destroy the platform
        Destroy(platform);
        Debug.Log("Platform");
        platformCount--;
        thingsRemoved++;
    }

}