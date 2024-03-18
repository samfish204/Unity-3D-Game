using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleCrate : MonoBehaviour
{
    [SerializeField] private GameObject CrateDestroyed = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCrate()
    {
        Instantiate(CrateDestroyed, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
