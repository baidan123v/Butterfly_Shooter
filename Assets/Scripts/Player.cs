using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // Start reference  to the Player (can be used in other scripts).
   public static Player instance = null;
   // Player health.
   public int Player_health = 1;
   
   private void Awake()
   {
     if(instance == null){
         instance = this ;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   // Method of taking damage by the player 
   public void GetDamage(int damage)
   {
    // Reduce the health by the damage amount
    Player_health -= damage;
    // If the player does not have a health..
    if (Player_health <= 0)
    {
        // Call the player destruction method
        Destruction();
    }
   }
   // Method destruction player
   void Destruction()
   {
    // Destroy the current player object
    Destroy(gameObject);
   }
}
