using System.Collections;
using UnityEngine;

public class MensajeEnemigoDerrotado : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private VidaEnemigo2D enemigo;
    [SerializeField] private GameObject textoDerrotado;

    [Header("Configuracion")]
    [SerializeField] private float duracionMensaje = 2f;

    private void OnEnable()
    {
        if (enemigo != null)
            enemigo.AlMorir += MostrarMensaje;
    }

    private void OnDisable()
    {
        if (enemigo != null)
            enemigo.AlMorir -= MostrarMensaje;
    }

    private void MostrarMensaje()
    {
        if (textoDerrotado != null)
        {
            textoDerrotado.SetActive(true);
            StartCoroutine(OcultarMensaje());
        }
    }

    private IEnumerator OcultarMensaje()
    {
        yield return new WaitForSeconds(duracionMensaje);
        textoDerrotado.SetActive(false);
    }
}