using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeTakip : MonoBehaviour
{
    public Transform oyuncu;
    public Vector3 ofset;

    void Update()
    {
        // Karakterin arkas�ndaki bir noktay� takip et
        Vector3 hedefPozisyon = oyuncu.position + ofset;

        // Kameran�n yumu�ak bir �ekilde karakteri takip etmesi i�in Lerp kullan�n
        transform.position = Vector3.Lerp(transform.position, hedefPozisyon, Time.deltaTime * 5f);

        // Kameran�n karakteri daima izlemesini sa�lamak i�in karakterin y�n�ne bak�n
        transform.LookAt(oyuncu.position);
    }
}
