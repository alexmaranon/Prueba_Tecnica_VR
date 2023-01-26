using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_parent
{
    //Al crear un Gun_parent a la hora de añadir armas con funcionalidades diferentes (un lanzagranadas por ejemplo) con crear otro float en el void inferior y otro script el cual contenga dicho float
    //Se podrá implementar de forma que las armas con el script Gun_1 no tengan dicha función.

    public static Gun_creator gun_data;
    protected float _Damage,_Distance,_CD;
    public Gun_parent(float Distance,float Damage, float CD)
    {
        _Damage = Damage;
        _Distance = Distance;
        _CD = CD;
    }
    public void give_data(float Distance, float Damage, float CD) //Dar los datos al script en el cual se ejecuta el Raycast. Este código será llamado desde la subclase correspondiente
    {
        gun_data.GetComponent<Gun_creator>().Damage= _Damage;
        gun_data.GetComponent<Gun_creator>().Distance= _Distance;
        gun_data.GetComponent<Gun_creator>().CD= _CD;
    }
  
    
}
