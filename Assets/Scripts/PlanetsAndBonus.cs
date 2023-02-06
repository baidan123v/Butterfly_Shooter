using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonus : MonoBehaviour
{
// An array the planets prefab to be spawned
[SerializeField] private GameObject[] obj_Planets;
// How long between each planets spawn.
[SerializeField] private float time_Planet_Spawn;
// The speed at which  the Planets moves.
[SerializeField] private float speed_Planets;
// Planets List 
// We will use this list so that  the planets do not repeat.
List<GameObject> planetsList = new List<GameObject>();

private void Start()
{
    // Start function PlanetsCreation as a coroutine.
    StartCoroutine(PlanetsCreation());
}

IEnumerator PlanetsCreation()
{
    // Fill the list with planets
    for (int i = 0 ; i < obj_Planets.Length ; i++)
    {
        planetsList.Add(obj_Planets[i]);
    }
    // Wait 7 Seconds after the game started...
    yield return new WaitForSeconds(7);
    // Create planets...
    while (true)
    {
        // Select a random planet from the list.
        int randomIndex = Random.Range(0,planetsList.Count);
        // Create an instance of the  planet , taking into account the limits of the players movement width
        // The planet will be created  above  the camera's visibility 
        // The planet will move at an angle in the range of -25 to 25
        GameObject newPlanet = Instantiate(planetsList[randomIndex],
            new Vector3(Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX),
            PlayerMoving.instance.borders.maxY * 1.5f),
            Quaternion.Euler(0,0, Random.Range(-25,25)));

            // Remove  the selected planet from the list 
            planetsList.RemoveAt(randomIndex);
            // If the list is empty, fill it again
            if (planetsList.Count == 0)
            {
                for (int i = 0 ; i < obj_Planets.Length ; i++)
                {
                    planetsList.Add(obj_Planets[i]);
                }
            }
            // On the created planet we find  the  component MovingObjects and set the speed of movement 
            newPlanet.GetComponent<ObjMoving>().speed = speed_Planets;
            // Every time_Planet_Spawn seconds
            yield return new WaitForSeconds(time_Planet_Spawn); 
    }
}

}
