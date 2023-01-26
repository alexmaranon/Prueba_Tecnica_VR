using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float Max_Health;
    float Actual_Health;
    public Slider Health_slider;//Barra de vida hecha con slider
    public Transform cameras;
    private void Start()
    {
        Actual_Health = Max_Health;
        Health_slider.value = Actual_Health;
    }
    public void take_dmg(float Damage)//Función que será llamada desde el script Gun_creator para restar vida y actualizar la barra de vida
    {
        Actual_Health = Actual_Health - Damage;
        Health_slider.value = Actual_Health / Max_Health;//Actualizar Slider (barra de vida)
        if (Actual_Health <= 0) { Destroy(this.gameObject); } //Destruir objeto si la vida llega por debajo de 0
    }
    private void Update()
    {
        Health_slider.transform.LookAt(cameras); //Hacer que las barras de vida miren hacia la cámara 
    }
}
