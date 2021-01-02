using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float karakterHizi;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0;
    public float atesGecenSure;
    public Transform kursunneredencıksın;
    AudioSource audio;
    
    public GameObject Kursun;

    
    
    void Start ()
    {
        fizik = GetComponent<Rigidbody> ();
        audio = GetComponent<AudioSource>();
    }
     void Update()
    {
        if (Input.GetMouseButton(0) && Time.time>atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            Debug.Log(Instantiate(Kursun, kursunneredencıksın.position, Quaternion.identity));
            Instantiate(Kursun, kursunneredencıksın.position, Quaternion.identity);
            audio.Play();
        }
    }
    
      

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,0,vertical);

        fizik.velocity = vec*karakterHizi;

        fizik.position = new Vector3
        (
            Mathf.Clamp(fizik.position.x, minX, maxX),
       0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)
        );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * -egim);//uzay aracı sağa sola yatıyor
    }
}
