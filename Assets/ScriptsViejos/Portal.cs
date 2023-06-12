using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public TipoLllave tipo;
    public string texto;
    [SerializeField] Vector3 puntoAparicion;
    [SerializeField] string scene;


    public void Cambio()
    {
        SceneManager.LoadScene(scene);
    }
}
