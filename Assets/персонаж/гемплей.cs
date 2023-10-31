using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class гемплей : MonoBehaviour 
{
    Animator Аниматор; //Аниматор 

    private void Start()
    {

        Аниматор = gameObject.GetComponent<Animator>();
    }





    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Аниматор.SetBool("IIIходьба", true);
        }



        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Аниматор.SetBool("IIIходьба", false);
        }



        if (Input.GetKey(KeyCode.Alpha2))
        {
            Аниматор.SetBool("IIIпрыжок", true);
        }




        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Аниматор.SetBool("IIIпрыжок", false);
        }



        if (Input.GetKey(KeyCode.Alpha3))
        {
            Аниматор.SetBool("IIIвысокийПрыжок", true);
        }




        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Аниматор.SetBool("IIIвысокийПрыжок", false);
        }



        if (Input.GetKey(KeyCode.Alpha4))
        {
            Аниматор.SetBool("IIIзахватРтом", true);
        }




        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Аниматор.SetBool("IIIзахватРтом", false);
        }




        if (Input.GetKey(KeyCode.Alpha5))
        {
            Аниматор.SetBool("IIIтолкать", true);
        }


        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Аниматор.SetBool("IIIтолкать", false);
        }




        if (Input.GetKey(KeyCode.Alpha6))
        {
            Аниматор.SetBool("IIIпадение", true);
        }


        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            Аниматор.SetBool("IIIпадение", false);
        }
    }




}
