using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller = null;
    private float speed = 5.0f;
    private float gravity = 9.81f;

    [SerializeField] private GameObject MuzzleFlash = null;
    [SerializeField] private GameObject AKMuzzleFlash = null;
    [SerializeField] private GameObject HitMarker = null;

    [SerializeField] private AudioSource M16Audio = null;
    [SerializeField] private AudioSource AKAudio = null;

    [SerializeField] private int maxAmmo = 50;
    [SerializeField] private int currentAmmo = 0;
    private bool isReloading = false;

    [SerializeField] private bool hasM16Diamond = false;
    [SerializeField] private bool hasAKDiamond = false;

    private UIManager UI = null;

    [SerializeField] private GameObject M16 = null;
    [SerializeField] private GameObject AK = null;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();

        controller = GetComponent<CharacterController>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        currentAmmo = maxAmmo;

        if (UI != null)
        {
            UI.UpdateAmmo(currentAmmo);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Shoot();
        AKShoot();

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine( Reload() );

            isReloading = true;
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 velocity = direction * speed;

        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime);
    }

    private void Shoot()
    {

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            // change color of crosshair here
            UI.xHairRed();
        } else
        {
            UI.xHairGreen();
        }

        if (M16.activeSelf && currentAmmo > 0 && Input.GetMouseButton(0))
        {

            MuzzleFlash.SetActive(true);
            if (!M16Audio.isPlaying)
            {
                M16Audio.Play();
            }

            currentAmmo--;
            if (UI != null) { 
                UI.UpdateAmmo(currentAmmo);
            }
            // Ray rayOrigin = Camera.main.ScreenPointToRay(
            //    new Vector3(Screen.width/2, Screen.height/2, 0f)); // change the y to match crosshair

            // Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                // Debug.Log("Raycast hit " + hitInfo.collider);
                GameObject Hit = Instantiate(HitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                Destroy(Hit, 1.0f);

                ColumnBreakScript Column = hitInfo.transform.GetComponent<ColumnBreakScript>();

                DestructibleCrate Crate = hitInfo.transform.GetComponent<DestructibleCrate>();

                if (Column != null)
                {
                    Column.BreakColumn();
                }

                if (Crate != null)
                {
                    Crate.DestroyCrate();
                }
            }
        } else
        {
            MuzzleFlash.SetActive(false);

            M16Audio.Stop();
        }
    }

    // Delete from here until next comment if all goes wrong

    private void AKShoot()
    {

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            // change color of crosshair here
        }

        if (AK.activeSelf && currentAmmo > 0 && Input.GetMouseButton(0))
        {

            AKMuzzleFlash.SetActive(true);
            if (!AKAudio.isPlaying)
            {
                AKAudio.Play();
            }

            currentAmmo--;
            if (UI != null)
            {
                UI.UpdateAmmo(currentAmmo);
            }
            // Ray rayOrigin = Camera.main.ScreenPointToRay(
            //    new Vector3(Screen.width/2, Screen.height/2, 0f)); // change the y to match crosshair

            // Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                // Debug.Log("Raycast hit " + hitInfo.collider);
                GameObject Hit = Instantiate(HitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                Destroy(Hit, 1.0f);

                ColumnBreakScript Column = hitInfo.transform.GetComponent<ColumnBreakScript>();

                DestructibleCrate Crate = hitInfo.transform.GetComponent<DestructibleCrate>();

                if (Column != null)
                {
                    Column.BreakColumn();
                }

                if (Crate != null)
                {
                    Crate.DestroyCrate();
                }
            }
        }
        else
        {
            AKMuzzleFlash.SetActive(false);

            AKAudio.Stop();
        }
    }

    // PROBABLY HAVE TO MAKE SECOND SHOOT METHOD FOR AK && Make Second shop script

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);

        currentAmmo = maxAmmo;

        if (UI != null)
        {
            UI.UpdateAmmo(currentAmmo);
        }

        isReloading = false;
    }

    public void SetM16(bool temp)
    {
        hasM16Diamond = temp;
    }

    public bool HasM16Diamond()
    {
        return hasM16Diamond;
    }

    public void SetAK(bool temp)
    {
        hasAKDiamond = temp;
    }

    public bool HasAKDiamond()
    {
        return hasAKDiamond;
    }

    public void ShowM16()
    {
        M16.SetActive(true);
    }

    public void RemoveM16()
    {
        M16.SetActive(false);
    }

    public void ShowAK()
    {
        AK.SetActive(true);
    }

    public void RemoveAK()
    {
        AK.SetActive(false);
    }
}
