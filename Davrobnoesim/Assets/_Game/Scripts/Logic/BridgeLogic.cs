using System.Collections;
using UnityEngine;

public class BridgeLogic : MonoBehaviour
{
    [SerializeField] private GameObject bridgeOn;
    [SerializeField] private GameObject bridgeOff;
    [SerializeField] private bool enableBridge;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enableBridge == true)
            {
                bridgeOn.SetActive(true);
                bridgeOff.SetActive(false);
            }
            else
            {
                bridgeOff.SetActive(true);
                bridgeOn.SetActive(false);
            }
        }
    }
}