using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ShootingSettings
{
    [Range(0,100)]
    public int shot_Chance;
    // Time interval within which the shot occurs.
    public float shot_time_min, shot_time_max;
}
public class Wave : MonoBehaviour
{
 // Reference to the ShootingSettings
 public ShootingSettings shooting_settings;
 [Space]
 // The enemy prefab to be spawned.
 public GameObject obj_Enemy;
 // Amount of enemies in one wave
 public int count_in_wave;
 // Speed 
 public float speed_Enemy;
 // Time between spawn enemy in wave 
 public float time_Spawn;
 // An array of waypoints along which the enemy  moves in a wave.
 public Transform[] path_Points;
// Destroy  the surviving enemies at the end of the path or send them to the begining of the path.
[SerializeField] private bool is_return;

[SerializeField] private int amountOfSmoothing;
private bool is_test_wave;
private FollowThePath follow_component;
private Enemy enemy_component_script;

private void Start()
{
    StartCoroutine(CreateEnemyWave());
}
IEnumerator CreateEnemyWave()
{
    // Create enemies...
    for (int i = 0; i < count_in_wave; i++)
    {
        GameObject new_enemy = Instantiate(obj_Enemy, obj_Enemy.transform.position, Quaternion.identity);
        // Try and find an FollowThePath script on the gameobject new_enemy.
        follow_component = new_enemy.GetComponent<FollowThePath>();
        // Specify the path that will move the new_enemy 
        follow_component.path_Points = path_Points;
        follow_component.speed_Enemy = speed_Enemy;
        follow_component.is_return = is_return;

        enemy_component_script = new_enemy.GetComponent<Enemy>();
        enemy_component_script.shot_Chance = shooting_settings.shot_Chance;
        enemy_component_script.shot_time_min = shooting_settings.shot_time_min;
        enemy_component_script.shot_time_max = shooting_settings.shot_time_max;
        new_enemy.SetActive(true);
        // Every time_Spawn seconds;
        yield return new WaitForSeconds(time_Spawn);
    }
    if (is_test_wave)
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(CreateEnemyWave());
    }
    // If is_return = false destroy the enemy at the end of the path
    if (!is_return)
        Destroy(gameObject);

}
// To make it easier to set up enemy waypoints, connect them with a line


 void OnDrawGizmos()
    {
        NewPositionByPath(path_Points);
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        //Права на данный курс принадлежат Дорофеевой Карине Олеговне, данный курс создавался для Udemy сайта
    void NewPositionByPath(Transform[] path)
    {
        Vector3[] path_Positions = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            path_Positions[i] = path[i].position;
        }
        //path_Positions = Smoothing(path_Positions);
        //path_Positions = Smoothing(path_Positions);
        //path_Positions = Smoothing(path_Positions);

        path_Positions = MultipleSmoothing(path_Positions, amountOfSmoothing);
        for (int i = 0; i < path_Positions.Length - 1; i++)
        {
            Gizmos.DrawLine(path_Positions[i], path_Positions[i + 1]);
        }
    }

private Vector3[] MultipleSmoothing (Vector3[] path_Positions, int amountOfSmoothing)
{
    for (int i = 0; i < amountOfSmoothing; i++)
    {
        path_Positions = Smoothing(path_Positions);
    }
    return path_Positions;
}

    Vector3[] Smoothing(Vector3[] path_Positions)
    {

        
        Vector3[] new_Path_Positions = new Vector3[(path_Positions.Length - 2) * 2 + 2];
        new_Path_Positions[0] = path_Positions[0];
        new_Path_Positions[new_Path_Positions.Length - 1] = path_Positions[path_Positions.Length - 1];

        int j = 1;
        for (int i = 0; i < path_Positions.Length - 2; i++)
        {
            new_Path_Positions[j] = path_Positions[i] + (path_Positions[i + 1] - path_Positions[i]) * 0.75f;
            new_Path_Positions[j + 1] = path_Positions[i + 1] + (path_Positions[i + 2] - path_Positions[i + 1]) * 0.25f;
            j += 2;
        }
        return new_Path_Positions;
    }
}
