using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 // The damage inflicted by each bullet.
 public int damage;
 // Is  the bullet of an  enemy or player.
 public bool is_Enemy_Bullet;
 


 private void Destruction()
 {
    Destroy(gameObject);
 }

private void OnTriggerEnter2D(Collider2D coll)
{
    // If the bullet belonges to an  enemy  and collides  with a player...
    if (is_Enemy_Bullet && coll.tag == "Player")
    {
        // Call the Player for the  method of taking  damage and deal damage to him 
        Player.instance.GetDamage(damage); 
        // Destruction bullet
        Destruction();
    }
    // If the bullet belonges to an  player  and collides  with a enemy...
    else if (!is_Enemy_Bullet && coll.tag == "Enemy")
    {
        // At the collider we find the enemy component and call the method for taking damage 
        coll.GetComponent<Enemy>().GetDamage(damage);
         // Destruction bullet
        Destruction();
    }
}
}
