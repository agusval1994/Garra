using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoverGarra : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioSource sonidoMoverGarra;
    public AudioSource sonidoBajarGarra;
    public AudioSource sonidoVolverAlInicio;
    bool unSonido = true;

    [Header("Componentes")]
    public float alturaMaxima;
    public float alturaMinima;
    public float speed;    
    
    public GameObject Tubos;
    public GameObject Motor;
    public GameObject Gancho;

    public Animator animcaionGarra;

    public bool bajarGarra = false;
    public bool controlarGarra;

    bool volverAlInicio = false;
    bool unaVez = true;
    Rigidbody rigidBody;

    [Header("Limites")]
    public Transform AlturaGancho;
    public Transform limiteIzquierda;
    public Transform limiteDerecha;
    public Transform limiteAdelante;
    public Transform limiteAtras;

    void Start()
    {
        animcaionGarra = Gancho.gameObject.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        controlarGarra = true;
        volverAlInicio = false;
    }

    void FixedUpdate()
    {
        float moveH = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveV = CrossPlatformInputManager.GetAxis("Vertical");

        Motor.transform.position = new Vector3(transform.position.x, Motor.transform.position.y, transform.position.z);
        Tubos.transform.position = new Vector3(Tubos.transform.position.x, Tubos.transform.position.y, Motor.transform.position.z);

        if (volverAlInicio)
        {
            if (AlturaGancho.position.y <= alturaMaxima)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }

            if (transform.position.x >= limiteIzquierda.transform.position.x + 0.5f)
            {
                transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
            }

            if (transform.position.z >= limiteAdelante.transform.position.z + 0.5f)
            {
                transform.Translate(0, 0, speed * -1 * Time.deltaTime);
            }
        }




        if (controlarGarra)
        {
            transform.Translate(speed * moveH * Time.deltaTime, 0, 0);
            transform.Translate(0, 0, speed * moveV * Time.deltaTime);

            if (moveH != 0 || moveV != 0)
            {
                if (unSonido)
                {
                    sonidoMoverGarra.Play();
                    unSonido = false;
                }
            }
            else
            {
                sonidoMoverGarra.Stop();
                unSonido = true;
            }

            if (transform.position.x < limiteIzquierda.transform.position.x)
            {
                transform.position = new Vector3(limiteIzquierda.transform.position.x, transform.position.y, transform.position.z);
            }

            if (transform.position.x > limiteDerecha.transform.position.x)
            {
                transform.position = new Vector3(limiteDerecha.transform.position.x, transform.position.y, transform.position.z);
            }

            if (transform.position.z > limiteAtras.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limiteAtras.transform.position.z);
            }

            if (transform.position.z < limiteAdelante.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limiteAdelante.transform.position.z);
            }




            /* Para PC

            if (transform.position.x > limiteIzquierda.transform.position.x)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
                }
            }

            if (transform.position.x < limiteDerecha.transform.position.x)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }


            //Movimientos Adelante y Atras

            if (transform.position.z < limiteAtras.transform.position.z)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }

            if (transform.position.z > limiteAdelante.transform.position.z)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(0, 0, speed * -1 * Time.deltaTime);
                }
            }*/
        }


        if (AlturaGancho.position.y > alturaMinima)
        {
            if (bajarGarra)
            {
                transform.Translate(0, speed * -1 * Time.deltaTime, 0);

                if (unaVez)
                {
                    StartCoroutine(Esperar());
                    unaVez = false;
                }

            }
        }
    }

    IEnumerator Esperar()
    {
        controlarGarra = false;
        sonidoBajarGarra.Play();

        yield return new WaitForSeconds(2.0f);

        sonidoBajarGarra.Stop();
        CerrarGarra();
        bajarGarra = false;

        yield return new WaitForSeconds(2.0f);

        volverAlInicio = true;
        sonidoVolverAlInicio.Play();

        yield return new WaitForSeconds(3.0f);

        AbrirGarra();
        sonidoVolverAlInicio.Stop();

        yield return new WaitForSeconds(2.0f);

        unaVez = true;
        volverAlInicio = false;
        controlarGarra = true;
    }

    public void AbrirGarra()
    {
        animcaionGarra.SetBool("Abrir", true);
        animcaionGarra.SetBool("Cerrar", false);
    }

    public void CerrarGarra()
    {
        animcaionGarra.SetBool("Abrir", false);
        animcaionGarra.SetBool("Cerrar", true);
    }
}