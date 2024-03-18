using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKDiamond : MonoBehaviour
{

    [SerializeField] private AudioClip AKDiamondPickUp = null;

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

            Debug.Log("Press E to pick up");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player P = other.GetComponent<Player>();

                if (P != null)
                {
                    P.SetAK(true);

                    UIManager UI = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (UI != null)
                    {
                        UI.CollectedAKDiamond();
                    }

                    AudioSource.PlayClipAtPoint(AKDiamondPickUp, transform.position, 1.0f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
