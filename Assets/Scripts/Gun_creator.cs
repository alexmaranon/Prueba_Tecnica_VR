using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
public class Gun_creator : MonoBehaviour
{
    #region Get_Weapons_Components
    Gun_1 Gun_Low_Distance;
    Gun_1 Gun_High_Distance;
    public GameObject Canon_position;
    public GameObject canon_position_2;
    public float Distance, CD, Damage;
    #endregion
    
    #region Weapon_Position/Rotation
    Vector3 direction;
    Vector3 position;
    #endregion
    string Weapon_name;//Arma que cogemos con los controllers
    public Text weapon_in_hand;//Texto de arma equipada
    bool CanShoot = true;//Bool para la cadencia
    AudioSource Shot_source;
    private void Start()
    {
     

        Gun_Low_Distance = new Gun_1(30,20,2); //Asignamos valores a los 2 tipos de armas diferentes (Distancia, Daño, CD/Cadencia)
        Gun_High_Distance = new Gun_1(50, 5, 1);
        Gun_parent.gun_data = this; 

        weapon_in_hand.text = "";

     
    }


    public void Shot()
    {
        if (CanShoot == true)
        {
            StartCoroutine(CoolDown()); //Cadencia
            if(Weapon_name== "Gun_High_Distance")
            {
                Shot_source = canon_position_2.GetComponent<AudioSource>();
                direction = canon_position_2.transform.forward; //Cogemos el vector director del cañon debido a que es donde apunta nuestra arma
                position = canon_position_2.transform.position;
            }
            if (Weapon_name == "Gun_Low_Distance")
            {
                Shot_source = Canon_position.GetComponent<AudioSource>();
                direction = Canon_position.transform.forward; //Cogemos el vector director del cañon debido a que es donde apunta nuestra arma
                position = Canon_position.transform.position;
            }
            Shot_source.Play();

            RaycastHit hit;
            if (Physics.Raycast(position, direction, out hit, Distance)) //Raycast para detectar si hitea en enemigo
            {
                if (hit.transform.name == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<Enemy>().take_dmg(Damage); //Activamos la función que quitará vida al enemigo hiteado
                }

            }
            
        }
        
    }
   
    public void long_w() //Se ejecuta al coger el arma utilizando los eventos del arma desde unity
    {
        CanShoot = true; //Reiniciamos el CD al coger nueva arma
        Gun_High_Distance.give_data(Distance, Damage, CD); //Llamamos a la función para obtener los valores de dicha arma

        Weapon_name = "Gun_High_Distance"; //Guardar el tipo de arma que cogemos
        weapon_in_hand.text = "High_Distance"; //Mostrar en la mesa el tipo de arma q cogemos
    }
    public void short_w()
    {
        CanShoot = true;
        Gun_Low_Distance.give_data(Distance, Damage, CD);

        Weapon_name = "Gun_Low_Distance";
        weapon_in_hand.text = "Low_Distance";

    }

    IEnumerator CoolDown() //Cadencia
    {
        CanShoot = false;
        yield return new WaitForSeconds(CD);
        CanShoot = true;
    }
   

}
