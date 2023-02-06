using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
// Vertical sprite size in pixels.
// ****For proper operation , the height of the sprite must be greater  than height  of the camera.
// ****Yoy can use the Box collider to measure the height of the sprite.
[SerializeField] private float vertical_Size;
// Sprite up offset
private Vector2 _offset_Up;

// Method RepeatBackground
// Moves two sprites one after the other, creating an endless background
private void Update()
{
    // if the sprite is completely gone
    if(transform.position.y <- vertical_Size)
    {
        // Call the RepeatBackground method
        RepeatBackground();
    }
}
 
void RepeatBackground()
{
// Set the offset twice the height of the sprite .
_offset_Up= new Vector2(0,vertical_Size * 2f);
// Set a new position for the  sprite
transform.position=(Vector2)transform.position + _offset_Up;
} 

}
