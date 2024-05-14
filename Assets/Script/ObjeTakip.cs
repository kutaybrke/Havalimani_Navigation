using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeTakip : MonoBehaviour
{
    public Transform oyuncu;
    public Vector3 ofset;

    void Update()
    {
        // Karakterin arkasýndaki bir noktayý takip et
        Vector3 hedefPozisyon = oyuncu.position + ofset;

        // Kameranýn yumuþak bir þekilde karakteri takip etmesi için Lerp kullanýn
        transform.position = Vector3.Lerp(transform.position, hedefPozisyon, Time.deltaTime * 5f);

        // Kameranýn karakteri daima izlemesini saðlamak için karakterin yönüne bakýn
        transform.LookAt(oyuncu.position);
    }
}
