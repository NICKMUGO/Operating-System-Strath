using UnityEngine;
using System.Collections;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject Birdd; // Assign your sprite prefab in the Inspector
    public float spawnInterval = 2.0f; // Time interval for spawning sprites
    public float moveSpeed = 5.0f; // Speed at which the sprite moves

    private void Start()
    {
        // Start the coroutine to spawn sprites
        StartCoroutine(SpawnSprites());
    }

    private IEnumerator SpawnSprites()
    {
        while (true)
        {
            // Instantiate the sprite prefab at the spawner's position
            GameObject newSprite = Instantiate(Birdd, transform.position, Quaternion.identity);
            SpriteMover spriteMover = newSprite.GetComponent<SpriteMover>();

            if (spriteMover != null)
            {
                spriteMover.SetSpeed(moveSpeed); // Set the move speed
            }
            else
            {
                Debug.LogWarning("SpriteMover component not found on the instantiated sprite. Default speed will not be set.");
            }

            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }
}