using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Enemy Health.
  public int enemy_Health;

  // The Bullet prefab to be spawned
  public GameObject obj_Bullet;
  // Time interval within which the shot occurs.
  public float shot_time_min, shot_time_max;
  // The probability of the enemy shot
  public int shot_Chance;

 
  private void Start()
  {
  // Call the  OpenFire in the time interval betwen shot_time_min and shot_time_max
    Invoke("OpenFire", Random.Range(shot_time_min,shot_time_max));
  }
  
  private void OpenFire()
  {
    // If random value less than shot chance , making a shot
    if (Random.value < (float)shot_Chance / 100)
    {
    // Create an instance of the prefab obj_Bullet in the enemy position and withhout rotation.
    Instantiate(obj_Bullet, transform.position, Quaternion.identity);
    }
  }
  public void GetDamage(int damage)
  {
    // Reduce teh Health by the damage amount.
    enemy_Health -= damage;
    // If the enemy does not have a Health...
    if ( enemy_Health <= 0)
    {
        // Call the enemy destruction method
        Destruction();
    }

  }

private void  Destruction()
{
    // Destroy the current player object.
    Destroy(gameObject);
}
// if enemy collides player, Player gets the damage.
private void OnTriggerEnter2D(Collider2D coll)
{
    if (coll.tag == "Player")
    {
        GetDamage(1);
        Player.instance.GetDamage(1);
    } 
}
}
