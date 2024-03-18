using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    // [SerializeField] private AudioSource M16ShopSound = null;

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
                    if (P.HasM16Diamond())
                    {
                        P.SetM16(false);

                        UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if (UI != null)
                        {
                            UI.RemoveM16Diamond();
                        }

                        AudioSource M16ShopSound = GetComponent<AudioSource>();

                        if (M16ShopSound != null) {
                            M16ShopSound.Play();
                        }
                        P.RemoveAK();
                        P.ShowM16();
                    }
                }
            }
        }
    }
}
