using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demo_animator : MonoBehaviour {


    public Slider slider;
    public Text infoText;
    public GameObject asset;
    private Animator anim;

    private bool gunBarrelSpinning = false;

    public Material[] mats;

    private int currentTexIndex = 0;

    void Start () {
       
        anim = asset.GetComponent<Animator>();
        infoText.text = "";
    }	
	public void Walk1()
    {
        anim.SetTrigger("walk1");
        infoText.text = "Walk";
    }
    public void Run()
    {
        anim.SetTrigger("run");
        infoText.text = "Run";
    }
    public void Walk2()
    {
        anim.SetTrigger("walk2");
        infoText.text = "Walk 2";
    }
    public void Walk3()
    {
        anim.SetTrigger("walk3");
        infoText.text = "Walk 3";
    }
    public void Idle()
    {
        anim.SetTrigger("idle");
        infoText.text = "Idle";
    }
    public void Sit()
    {
        anim.SetTrigger("sit");
        infoText.text = "Sit/Crouch";
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
        infoText.text = "Jump";
    }
    public void Stand()
    {
        anim.SetTrigger("stand");
        infoText.text = "Stand";
    }

    public void SpeedSliderChange()
    {
        anim.speed = slider.value;
    }

    
    public void Die()
    {
        anim.SetTrigger("die");
        infoText.text = "die";
    }

    public void NextTexture()
    {
        currentTexIndex++;

        if(currentTexIndex >= mats.Length)
        {
            currentTexIndex = 0;
        }
      
        Renderer rend = asset.GetComponentInChildren<Renderer>();
        Debug.Log("hi");
        rend.material = mats[currentTexIndex];
        infoText.text = rend.material.name;
    }

    public void ToggleGunBarrel()
    {
        if (gunBarrelSpinning)
        {
            anim.SetTrigger("stopGunBarrelSpin");
            gunBarrelSpinning = false;
        }
        else
        {
            anim.SetTrigger("gunBarrelSpin");
            gunBarrelSpinning = true;
        }
        

    }

    //public void TogglePeripheral(string name)
    //{

    //    GameObject go = transform.Find(name).gameObject;

    //    MeshRenderer mr = go.GetComponent<MeshRenderer>();


    //    mr.enabled = !mr.enabled;

    //    if(name == "cap_right")
    //    {
    //        TogglePeripheral("cap_left");
    //    }
    //}


    //public void TogglePeripheral(string name)
    //{

    //    switch(name)
    //    {
    //        case "P1":
    //            Renderer rend1 = p1.GetComponent<Renderer>();
    //            rend1.enabled = !rend1.enabled;
    //            break;
    //        case "P2":
    //            Renderer rend2 = p2.GetComponent<Renderer>();
    //            rend2.enabled = !rend2.enabled;
    //            break;
    //        case "P3":
    //            Renderer rend3 = p3.GetComponent<Renderer>();
    //            rend3.enabled = !rend3.enabled;
    //            break;
    //        case "P4":
    //            Renderer rend4 = p4.GetComponent<Renderer>();
    //            rend4.enabled = !rend4.enabled;
    //            break;
    //        case "P5":
    //            Renderer rend5 = p5.GetComponent<Renderer>();
    //            rend5.enabled = !rend5.enabled;
    //            break;
    //    }
    //}

    //public void RandomiseColors()
    //{
    //    Color _primary = new Color(Random.value, Random.value, Random.value, 1.0f);
    //    Color _secondary = new Color(Random.value, Random.value, Random.value, 1.0f);
    //    Color _details = new Color(Random.value, Random.value, Random.value, 1.0f);

    //    primary.color = _primary;
    //    secondary.color = _secondary;
    //    details.color = _details;
    //}

    //public void ToggleTextured()
    //{
    //    Renderer rend = Textured.GetComponentInChildren<Renderer>();
    //    if (rend.enabled == true)
    //    {
    //        transform.position = new Vector3(0, 0, 0);
    //        Textured.GetComponentInChildren<Renderer>().enabled = false;
    //    }
    //    else
    //    {
    //        transform.position = leftPos.transform.position;
    //        Textured.GetComponentInChildren<Renderer>().enabled = true;
    //    }

    //}
}
