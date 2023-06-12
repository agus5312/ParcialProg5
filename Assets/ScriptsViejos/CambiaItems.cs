using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiaItems : MonoBehaviour
{
    bool moviendose;
    public List<GameObject> objetos;
    int i;
    public GameObject linterna;
    public GameObject camara;
    [SerializeField] GameObject nota;
    [SerializeField] Text contenido;
    CartelIndicador cartel;

    public List<TipoLllave> llaves;


    StarterAssets.FirstPersonController controlador;
    StarterAssets.StarterAssetsInputs imputs;

    AudioSource pasos;
    public AudioClip caminar;
    public AudioClip correr;

    private void Start()
    {
        cartel = FindObjectOfType<CartelIndicador>();
        controlador = FindObjectOfType<StarterAssets.FirstPersonController>();
        imputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        pasos = GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        i = 0;
        for (int a = 0; a < objetos.Count; a++)
        {
            objetos[a].SetActive(false);
        }
    }
    void Update()
    {
        Pasos();
        Items();
    }

    void Items()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            objetos[i].SetActive(false);
            i--;
            if (i < 0)
            {
                i = objetos.Count - 1;
            }
            objetos[i].SetActive(true);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            objetos[i].SetActive(false);
            i++;
            if (i > objetos.Count - 1)
            {
                i = 0;
            }
            objetos[i].SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                ObjetoEnSuelo tag = hitInfo.collider.GetComponent<ObjetoEnSuelo>();
                if (tag)
                {
                    switch (tag.type)
                    {
                        case TipoObjeto.NOTA:
                            contenido.text = hitInfo.collider.GetComponent<Notas>().contenido;
                            nota.SetActive(true);
                            break;
                        

                        case TipoObjeto.PUERTA:
                            GameObject puerta = hitInfo.collider.gameObject;
                            bool comprobar = true;
                            for (int i = 0; i < llaves.Count; i++)
                            {
                                if (llaves[i] == puerta.GetComponent<Puertas>().tipo)
                                {
                                    puerta.GetComponent<Puertas>().AbrirPuerta();
                                    comprobar = false;
                                }
                            }
                            if(comprobar)
                                cartel.Aparecer(puerta.GetComponent<Puertas>().texto);
                            break;

                        case TipoObjeto.PORTAL:
                            GameObject portal = hitInfo.collider.gameObject;
                            bool comprobar2 = true;
                            for (int i = 0; i < llaves.Count; i++)
                            {
                                if (llaves[i] == portal.GetComponent<Portal>().tipo)
                                {
                                    portal.GetComponent<Portal>().Cambio();
                                    comprobar = false;
                                }
                            }
                            if(comprobar2)
                                cartel.Aparecer(portal.GetComponent<Portal>().texto);
                            break;

                        case TipoObjeto.LLAVE:
                            llaves.Add(hitInfo.collider.gameObject.GetComponent<Llave>().type);
                            cartel.Aparecer(hitInfo.collider.gameObject.GetComponent<Llave>().texto);
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case TipoObjeto.LINTERNA:
                            objetos.Add(linterna);

                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        case TipoObjeto.CAMARA:
                            objetos.Add(camara);
                            camara.GetComponent<Flash>().AumentarTiros();
                            hitInfo.collider.gameObject.SetActive(false);
                            break;

                        default:
                            break;
                    }

                }

            }
        }
    }

    void Pasos()
    {
        if (imputs.move != new Vector2(0, 0) && controlador.Grounded)
        {
            if(moviendose == false)
            {
                pasos.Play();
            }
            moviendose = true;
        }
        else
        {
            pasos.Stop();
            moviendose = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pasos.clip = correr;
            pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            pasos.clip = caminar;
            pasos.Play();
        }
    }
}
