using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> ItemsInInventory = new List<GameObject>(); // List to hold the inventory
    public Camera mainCamera; // Camera reference for raycasting
    public Vector3 spawnAreaMin = new Vector3(-10, 1, -10); // Minimum spawn position range
    public Vector3 spawnAreaMax = new Vector3(10, 1, 10);  // Maximum spawn position range

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Assign the main camera if it's not set
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse button click - add to inventory and remove from scene
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (!ItemsInInventory.Contains(clickedObject))
                {
                    ItemsInInventory.Add(clickedObject); // Add to inventory
                    clickedObject.SetActive(false); // Deactivate the object
                    Debug.Log("Added " + clickedObject.name + " to inventory and removed it from the scene.");
                }
            }
        }

        // Right mouse button click - randomly spawn an item from the inventory
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            if (ItemsInInventory.Count > 0)
            {
                // Choose a random object from the inventory
                int randomIndex = Random.Range(0, ItemsInInventory.Count);
                GameObject itemToSpawn = ItemsInInventory[randomIndex];

                // Reactivate and place it at a random position in the scene
                itemToSpawn.SetActive(true);
                itemToSpawn.transform.position = GetRandomSpawnPosition();

                // Remove the item from the inventory after spawning it
                ItemsInInventory.RemoveAt(randomIndex);
                Debug.Log("Spawned " + itemToSpawn.name + " back into the scene.");
            }
            else
            {
                Debug.Log("No items in inventory to spawn.");
            }
        }
    }

    // Generates a random position within the defined spawn area
    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        return new Vector3(randomX, randomY, randomZ);
    }
}
