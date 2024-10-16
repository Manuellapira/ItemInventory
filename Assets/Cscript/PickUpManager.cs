using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public int[] highScore = new int[10]; // Fixed-size array
    public List<int> highscore = new List<int>(); // Flexible list for high scores
    public List<GameObject> obj = new List<GameObject>(); // List for GameObjects

    // Start is called before the first frame update
    void Start()
    {
        // Fill the list with initial values from highScore array
        for (int i = 0; i < highScore.Length; i++)
        {
            highscore.Add(highScore[i]); // Add array values to list
        }

        // Iterate through highscore list
        for (int i = 0; i < highscore.Count; i++)
        {
            Debug.Log("High score at " + i + ": " + highscore[i]); // Access element
        }

        // Modify the list
        if (highscore.Count > 4)
        {
            highscore[4] = 0; // Modify element using index
            Debug.Log("Modified 5th high score to 0.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Your logic for updates, if necessary
    }
}
