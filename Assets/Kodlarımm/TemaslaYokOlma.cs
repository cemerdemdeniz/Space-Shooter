using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOlma : MonoBehaviour
{
    public GameObject patlama;
    public GameObject Playerpatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;

     void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");

        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag!= "Sınır")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama,transform.position,transform.rotation);
            kontrol.ScoreArttir(10);
        }
        if (col.tag=="Player")
        {

            Instantiate(Playerpatlama, col.transform.position, col.transform.rotation);
            kontrol.GameOver();
        }
        
    }
}
