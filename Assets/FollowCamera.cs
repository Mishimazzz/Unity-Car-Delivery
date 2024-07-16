using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{   
    // create a game object, then drag the car (in unity) to this object
    [SerializeField] GameObject thingToFollow; 
    // this things position (camera) should be the same as the car's position

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);//因为这个camera如果不加这个负值会一直贴着地面
    }
}
