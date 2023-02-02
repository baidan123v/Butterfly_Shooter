using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
   // Static reference to the PlayerMoving ( Сможем менять скорость игрока из других скрпитов и сцен).
   public static PlayerMoving instance;
   // The speed at  which the player moves.
   public int speed_player = 5;
   // Reference private tp the Camera.
   private Camera _camera;
   // Saves the 2D coordinates (xy) where the player is moving
   private Vector2 _mouse_position;

   private void Awake (){
      // Setting up the references.
      if(instance == null){
         instance = this ;
      }
      else
      {
         Destroy(gameObject);
      }
      _camera = Camera.main;
   }

   private void Update(){
      // If the mouse button is down..
      if (Input.GetMouseButton(0)){
         // Get 2d coordinates (xy) click on screen 
         _mouse_position = _camera.ScreenToWorldPoint(Input.mousePosition); // Место нажатия по экрану
         // Move our player to the 2D coordinates clicks at a given speed.
         transform.position = Vector2.MoveTowards(transform.position, _mouse_position, speed_player * Time.deltaTime);
      }
   }
}
 