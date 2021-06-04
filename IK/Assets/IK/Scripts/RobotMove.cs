using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Transform[] FootTarget;
    public Transform[] Pole;
    public Transform Robot;
    public float Movespeed = 1.0f;
    public float Runspeed = 3.0f;
    public float RotateSpeed = 180f;
    private bool move = false;
    private bool run = false;
    public Animator anim;
    float originy;
    Vector3 origin;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        originy= FootTarget[0].position.y;
        origin = Robot.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        
        for (int i = 0; i < FootTarget.Length; i++)
        {
            var foot = FootTarget[i];
            var pole = Pole[i];
            var ray = new Ray(foot.transform.position + Vector3.up * 1f, Vector3.down);
            var hitInfo = new RaycastHit();
            if (Physics.SphereCast(ray, 0.05f, out hitInfo, 2f))
            {
                //foot.position = hitInfo.point + Vector3.up * 0.05f;
                Vector3 position = foot.position;
                if (hitInfo.transform.name != "Ground")
                {
                   
                    position.y = hitInfo.point.y;
                    foot.position = position + Vector3.up * 0.05f;
                     
                   
                }
                else
                {
                    Robot.position = new Vector3(Robot.position.x, origin.y, Robot.position.z); ;
                }
                position = pole.position;
                position.y = foot.position.y + 1f;
                pole.position = position;
            }
            
        }
        float average=100;
        for (int i = 0; i < FootTarget.Length; i++)
        {
            var foot = FootTarget[i];
            if (foot.transform.position.y - originy < average)
            {
                average = foot.transform.position.y - originy;
            }
           
            
        }
        Robot.position = new Vector3(Robot.position.x, origin.y + average, Robot.position.z);

    }
    private void Update()
    {
        move = false;
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            move = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                    run = true;
                
            }
            if (run)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Runspeed, Space.Self);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * Movespeed, Space.Self);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            move = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {

                run = true;

            }
            if (run)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Runspeed, Space.Self);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * Movespeed, Space.Self);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.y = eulerAngles.y - RotateSpeed * Time.deltaTime;
            eulerAngles.z = 0;
            transform.eulerAngles = eulerAngles;

        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.y = eulerAngles.y + RotateSpeed * Time.deltaTime;
            eulerAngles.z = 0;
            transform.eulerAngles = eulerAngles;

        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (!move)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
        if(run)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

       
        
   
}
