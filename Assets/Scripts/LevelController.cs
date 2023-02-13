using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves
{
    // Time when the wave will appear on the stage
    public float TimeToStart;
    // The Enemy Wave prefab to be spawed.
    public GameObject wave;
    // This wave after which the game will end.
    public bool is_last_wave;
}
public class LevelController : MonoBehaviour
{
    // Static Reference to the levelController 
    public static LevelController instance;
    // Array of player ships
    public GameObject[] playerShip;
    // Reference to the EnemyWaves.
    public EnemyWaves[] enemyWaves;

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

   private void Start()
   {
      // Create all enemy waves...
      for( int i = 0 ;i < enemyWaves.Length ; i++)
      {
         // Start CreateEnemyWave as a corautine.
         StartCoroutine(CreateEnemyWave(enemyWaves[i].TimeToStart, enemyWaves[i].wave));
      }
   }
   IEnumerator CreateEnemyWave ( float delay, GameObject Wave)
   {
      // if creation wave time ! = 0 and player is alive ... create a wave 
      if ( delay !=0)
      yield return new WaitForSeconds(delay);
      if(Player.instance != null)
      Instantiate(Wave);
   }
}
