using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyWalk : MonoBehaviour
{
 
[SerializeField] float sensitivity;
[SerializeField] Animator animator; 
[SerializeField] GameObject Walking;
[SerializeField] GameObject Idle; 
[SerializeField] GameObject Player; 
[SerializeField] float speed;
[SerializeField] GameObject head; 




    float mouseX;
    float mouseY; 



private void Start()
{
   
}

   void Update()
    {
        Move();    
    } 

    private void Move()
    {

         mouseX += Input.GetAxis("Mouse X") * sensitivity;
         mouseY += Input.GetAxis("Mouse Y") * sensitivity;

        transform.rotation = Quaternion.Euler(0, mouseX, 0);
        head.transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("Walk",true); 
            Player.transform.parent = Walking.transform;
            Player.transform.localPosition = Vector3.zero;
            Player.transform.localRotation = Quaternion.identity;
        }
        else 
        {
            animator.SetBool("Walk", false);
            Player.transform.parent = Idle.transform;
            Player.transform.localPosition = Vector3.zero;
            Player.transform.localRotation = Quaternion.identity;
        }
    
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime; 
        }
        }

        
       
    }




