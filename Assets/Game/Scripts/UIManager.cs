using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text AmmoCount = null;

    [SerializeField] private GameObject M16Diamond = null;
    [SerializeField] private GameObject AKDiamond = null;

    [SerializeField] private Image Crosshair = null;
    [SerializeField] private Color red;
    [SerializeField] private Color green;

    // Start is called before the first frame update
    void Start()
    {
        red.a = 1;
        green.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo(int count)
    {
        AmmoCount.text = "Ammo: " + count;
    }

    public void CollectedM16Diamond()
    {
        M16Diamond.SetActive(true);
    }

    public void RemoveM16Diamond()
    {
        M16Diamond.SetActive(false);
    }

    public void CollectedAKDiamond()
    {
        AKDiamond.SetActive(true);
    }

    public void RemoveAKDiamond()
    {
        AKDiamond.SetActive(false);
    }

    public void xHairRed()
    {
        Crosshair.color = red;
    }

    public void xHairGreen()
    {
        Crosshair.color = green;
    }
}
