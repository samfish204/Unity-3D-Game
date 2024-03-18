using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKShop : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            Debug.Log("Press E to purchase a weapon");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player P = other.GetComponent<Player>();

                if (P != null)
                {
                    if (P.HasAKDiamond())
                    {
                        P.SetAK(false);

                        UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if (UI != null)
                        {
                            UI.RemoveAKDiamond();
                        }

                        AudioSource AKShopSound = GetComponent<AudioSource>();

                        if (AKShopSound != null)
                        {
                            AKShopSound.Play();
                        }
                        P.RemoveM16();
                        P.ShowAK();
                    }
                }
            }
        }
    }
}
