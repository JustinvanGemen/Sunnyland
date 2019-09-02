using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   private void FixedUpdate(){
       transform.position += new Vector3(0.03f,0,0);
   }
}
