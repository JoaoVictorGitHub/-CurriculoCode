using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator[] anim;
    public Animator camAnim;
    public Animator motoAnimator;

    private Vector3 movement;
    private Rigidbody rb;

    public GameObject normal, tattoo, graduaçao, jardinagem, geriatria, carteiro, auxiliar, limpezas, motoboy, cTT, Kaffa, terno;

    public GameObject tattooUI, graduaçaoUI, jardinagemUI, geriatriaUI, carteiroUI, auxiliarUI, limpezasUI, motoboyUI, cTTUI, KaffaUI, ternoUI;

    public GameObject[] jardinagemPS;

    public GameObject tattooMachine, diploma, cadeiraDeRodas, carta, dente, vassoura, moto, chavena;

    private int speed = 5;

    private bool stopWalking = false;

    private bool moveAuto = false;

    private StartGame startGame;

    public ParticleSystem smokePS;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentsInChildren<Animator>();



        normal.SetActive(true);
        tattoo.SetActive(false);
        graduaçao.SetActive(false);
        jardinagem.SetActive(false);
        geriatria.SetActive(false);
        carteiro.SetActive(false);
        auxiliar.SetActive(false);
        limpezas.SetActive(false);
        motoboy.SetActive(false);
        cTT.SetActive(false);
        Kaffa.SetActive(false);
        terno.SetActive(false);

        tattooUI.SetActive(false);
        graduaçaoUI.SetActive(false);
        jardinagemUI.SetActive(false);
        geriatriaUI.SetActive(false);
        carteiroUI.SetActive(false);
        auxiliarUI.SetActive(false);
        limpezasUI.SetActive(false);
        motoboyUI.SetActive(false);
        cTTUI.SetActive(false);
        KaffaUI.SetActive(false);
        ternoUI.SetActive(false);

        jardinagemPS[0].SetActive(false);
        jardinagemPS[1].SetActive(false);

        tattooMachine.SetActive(false);
        diploma.SetActive(false);
        carta.SetActive(false);
        cadeiraDeRodas.SetActive(false);
        dente.SetActive(false);
        vassoura.SetActive(false);
        moto.SetActive(false);
        chavena.SetActive(false);

        startGame = GameObject.Find("UIManager").GetComponent<StartGame>();

    }

// Update is called once per frame
void Update()
    {
        Move();

    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "tattoo")
        {
            normal.SetActive(false);
            tattoo.SetActive(true);
            Debug.Log("HEy");
            tattooUI.SetActive(true);

            tattooMachine.SetActive(true);

            smokePS.Play();

        }
        else if (other.tag == "graduaçao")
        {
            tattoo.SetActive(false);
            graduaçao.SetActive(true);

            graduaçaoUI.SetActive(true);
            tattooUI.SetActive(false);

            tattooMachine.SetActive(false);

            diploma.SetActive(true);

            smokePS.Play();
        }
        else if (other.tag == "jardinagem")
        {
            graduaçao.SetActive(false);
            jardinagem.SetActive(true);

            jardinagemPS[0].SetActive(true);
            jardinagemPS[1].SetActive(true);

            jardinagemUI.SetActive(true);

            graduaçaoUI.SetActive(false);

            diploma.SetActive(false);

            smokePS.Play();
        }
        else if (other.tag == "geriatria")
        {
            jardinagemPS[0].SetActive(false);
            jardinagemPS[1].SetActive(false);

            jardinagem.SetActive(false);
            geriatria.SetActive(true);

            geriatriaUI.SetActive(true);
            jardinagemUI.SetActive(false);

            cadeiraDeRodas.SetActive(true);

            smokePS.Play();
        }
        else if (other.tag == "carteiro")
        {
            geriatria.SetActive(false);
            carteiro.SetActive(true);

            carteiroUI.SetActive(true);
            geriatriaUI.SetActive(false);

            cadeiraDeRodas.SetActive(false);
            carta.SetActive(true);

            smokePS.Play();
        }
        else if (other.tag == "auxiliar")
        {
            carteiro.SetActive(false);
            auxiliar.SetActive(true);

            auxiliarUI.SetActive(true);
            carteiroUI.SetActive(false);

            carta.SetActive(false);
            dente.SetActive(true);

            smokePS.Play();
        }
        else if (other.tag == "limpezas")
        {
            auxiliar.SetActive(false);
            limpezas.SetActive(true);

            limpezasUI.SetActive(true);
            auxiliarUI.SetActive(false);

            dente.SetActive(false);
            vassoura.SetActive(true);

            smokePS.Play();
        }
        else if (other.tag == "motoboy")
        {
            limpezas.SetActive(false);
            motoboy.SetActive(true);

            motoboyUI.SetActive(true);
            limpezasUI.SetActive(false);

            vassoura.SetActive(false);
            moto.SetActive(true);
            motoAnimator.Play("motoAnim");

            smokePS.Play();
        }
        else if (other.tag == "cTT")
        {
            motoboy.SetActive(false);
            cTT.SetActive(true);

            cTTUI.SetActive(true);
            motoboyUI.SetActive(false);

            moto.SetActive(false);

            smokePS.Play();
        }

        else if(other.tag == "kaffa")
        {
            cTT.SetActive(false);
            cTTUI.SetActive(false);

            Kaffa.SetActive(true);
            KaffaUI.SetActive(true);

            chavena.SetActive(true);

            smokePS.Play();

        }

        else if (other.tag == "terno")
        {
            Kaffa.SetActive(false);


            terno.SetActive(true);

            camAnim.Play("CameraAnim");

            ternoUI.SetActive(true);
            KaffaUI.SetActive(false);


            moveAuto = true;

            smokePS.Play();
        }

        if(other.tag == "ParedesInv")
        {
            stopWalking = true;
            anim[8].SetTrigger("Wave");
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Space) && stopWalking == false)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
            anim[0].SetBool("Walk", true);
            anim[1].SetBool("Walk", true);
            anim[2].SetBool("Walk", true);
            anim[3].SetBool("Walk", true);
            anim[4].SetBool("Walk", true);
            anim[5].SetBool("Walk", true);
            anim[6].SetBool("Walk", true);
            anim[7].SetBool("Walk", true);
            anim[8].SetBool("Walk", true);
        }
        else
        {
            movement = new Vector3(0, 0, 0);
            anim[0].SetBool("Walk", false);
            anim[1].SetBool("Walk", false);
            anim[2].SetBool("Walk", false);
            anim[3].SetBool("Walk", false);
            anim[4].SetBool("Walk", false);
            anim[5].SetBool("Walk", false);
            anim[6].SetBool("Walk", false);
            anim[7].SetBool("Walk", false);
            anim[8].SetBool("Walk", false);
        }

        if (moveAuto == true && stopWalking == false)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
            anim[8].SetBool("Walk", true);

            startGame.remoteMenu = true;
        }

    }
}
