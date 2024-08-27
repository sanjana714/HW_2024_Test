using System.Collections;
using UnityEngine;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab; // The Pulpit prefab to spawn
    public Transform spawnPoint; // Where the Pulpits will spawn
    public GameObject doofus; // Reference to the Doofus object

    private Vector3 lastPosition;
    private GameSettings settings;

    void Start()
    {
        settings = FindObjectOfType<GameSettings>(); // Get the GameSettings instance
        lastPosition = spawnPoint.position;

        StartCoroutine(SpawnPulpits());
    }

    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            // Wait for the time defined by the pulpit_spawn_time in the JSON file
            yield return new WaitForSeconds(settings.gameData.pulpit_data.pulpit_spawn_time);

            // Spawn a new pulpit
            SpawnPulpit();

            // Check if there are more than 2 pulpits and remove the oldest one
            if (transform.childCount > 2)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }

    void SpawnPulpit()
    {
        // Determine a random adjacent position for the new pulpit
        Vector3 newPosition = GetRandomAdjacentPosition(lastPosition);

        // Instantiate the pulpit and set its parent to the spawner object
        GameObject pulpit = Instantiate(pulpitPrefab, newPosition, Quaternion.identity);
        pulpit.transform.parent = transform;

        // Set a random timer for the pulpit's destruction
        float destroyTime = Random.Range(settings.gameData.pulpit_data.min_pulpit_destroy_time, 
                                         settings.gameData.pulpit_data.max_pulpit_destroy_time);

        // Initialize the Pulpit with the destroyTime
        Pulpit pulpitScript = pulpit.GetComponent<Pulpit>();
        pulpitScript.Initialize(destroyTime);

        // Update the last position for the next pulpit to spawn near
        lastPosition = newPosition;
    }

    Vector3 GetRandomAdjacentPosition(Vector3 lastPosition)
    {
        float offset = 10f; // Adjust this value to set how far apart the pulpits should spawn
        float x = lastPosition.x + Random.Range(-offset, offset);
        float z = lastPosition.z + Random.Range(-offset, offset);

        return new Vector3(x, 0.5f, z); // Ensure y is set correctly so the pulpit appears above the ground
    }

    void Update()
    {
        // Keep the camera focused on Doofus and the pulpit
        Camera.main.transform.position = new Vector3(doofus.transform.position.x, 
                                                     Camera.main.transform.position.y, 
                                                     doofus.transform.position.z - 10f);
    }
}