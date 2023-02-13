using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guns
{
    public GameObject obj_central_gun, obj_right_gun, obj_left_gun;
}
public class PlayerShooting : MonoBehaviour
{
  
// Start reference  to the Player (can be used in other scripts).
public static PlayerShooting instance ;
// Reference to the Guns;
public Guns guns;
// Maximum power level of guns 
[HideInInspector]
public int max_power_level_guns = 5;
// The Bullet prefab to be spawned.
public GameObject obj_bullet;
// How long betwwen each bullet spawn.
public float time_bullet_spawn = 0.3f;

[HideInInspector]
public float timer_shot;
// Current level of weapon strenght through the slider
[Range(1,5)]
public int cur_power_level_guns = 1;

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

private void Update()
{
// every timer_shot seconds we call the method MakeAShot 
if(Time.time > timer_shot)
{
    timer_shot = Time.time + time_bullet_spawn;
    // Call the method MakeAShot
    MakeAShot();
}
}
// Method CreateBullet. This method rotates the bullets in the z-axis 
private void CreateBullet(GameObject bullet, Vector3 position_Bullet, Vector3 rotation_Bullet)
{
    Instantiate(bullet, position_Bullet, Quaternion.Euler(rotation_Bullet));
}
// This method , dependenig on the cur_power_level_guns , changes the player's weapon shooting.
private void MakeAShot()
{
    switch (cur_power_level_guns)
    {
        //One gun shoot
        case 1:
            CreateBullet(obj_bullet,guns.obj_central_gun.transform.position, Vector3.zero);
            break;
        //Two guns shoot
        case 2:
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, Vector3.zero);
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, Vector3.zero);
            break;
        // Three guns shoots
        case 3:
             CreateBullet(obj_bullet,guns.obj_central_gun.transform.position, Vector3.zero);
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, new Vector3(0,0,-5));
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, new Vector3(0,0,5));
            break;
         case 4:
             CreateBullet(obj_bullet,guns.obj_central_gun.transform.position, Vector3.zero);
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, new Vector3(0,0,0));
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, new Vector3(0,0,5));
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, new Vector3(0,0,0));
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, new Vector3(0,0,-5));
            break;
         case 5:
             CreateBullet(obj_bullet,guns.obj_central_gun.transform.position, Vector3.zero);
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, new Vector3(0,0,-5));
             CreateBullet(obj_bullet,guns.obj_right_gun.transform.position, new Vector3(0,0,-15));
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, new Vector3(0,0,5));
             CreateBullet(obj_bullet,guns.obj_left_gun.transform.position, new Vector3(0,0,15));
            break;
        
    }
}
}
