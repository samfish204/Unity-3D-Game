using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16Diamond : MonoBehaviour
{
    [SerializeField] private AudioClip M16DiamondPickUp = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("Press E to pick up");

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player P = other.GetComponent<Player>();

                if (P != null)
                {
                    P.SetM16(true);

                    UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (UI != null)
                    {
                        UI.CollectedM16Diamond();
                    }

                    AudioSource.PlayClipAtPoint(M16DiamondPickUp, transform.position, 1.0f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
