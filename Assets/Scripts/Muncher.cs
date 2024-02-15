using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muncher : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Apple aplle))
        {
            Destroy(aplle.gameObject);
            winPanel.SetActive(true);
        }
    }
}
