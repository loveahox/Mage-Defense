using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellUsage : MonoBehaviour
{
    public GameObject lightningSpellPrefab;
    public GameObject fireballSpellPrefab;
    public GameObject earthquakeSpellPrefab;
    public GameObject glueTowerPrefab;

    public float lightningCooldown = 1f;
    public float lightningCooldownRate = 5f;
    public bool isLightningCooldown = false;

    public float fireballCooldown = 1f;
    public float fireballCooldownRate = 5f;
    public bool isFireballCooldown = false;

    public float earthquakeCooldown = 1f;
    public float earthquakeCooldownRate = 5f;
    public bool isEarthquakeCooldown = false;

    public float glueCooldown = 1f;
    public float glueCooldownRate = 5f;
    public bool isGlueCooldown = false;

    public Vector3 screenPosition;

    public Vector3 worldPosition;

    public float screenPositionDepth = 44f;

    // Start is called before the first frame updat
    void Start()
    {
        
    }
    //FIX ROTATION AND DEPTH
    void PlaceGlue()
    {
        if (Input.GetKeyDown(KeyCode.R) && worldPosition.x < 5 && worldPosition.x > -5 && worldPosition.z < 5 && worldPosition.z > -5 && !isGlueCooldown)
        {
            Instantiate(glueTowerPrefab, worldPosition, /*ROTATION GOES HERE PLEASE FIX IT*/ glueTowerPrefab.transform.rotation);
            isGlueCooldown = true;
            glueCooldown = 1f;
        }
        if (isGlueCooldown)
        {
            glueCooldown -= 1 / glueCooldownRate * Time.deltaTime;
            if (glueCooldown <= 0f)
            {
                glueCooldown = 0f;
                isGlueCooldown = false;
            }
        }
    }


    void CastLightning()
    {
        if (Input.GetKeyDown(KeyCode.Q) && worldPosition.x < 5 && worldPosition.x > -5 && worldPosition.z < 5 && worldPosition.z > -5 && !isLightningCooldown)
        {
            Instantiate(lightningSpellPrefab, worldPosition, lightningSpellPrefab.transform.rotation);
            isLightningCooldown = true;
            lightningCooldown = 1;
        }
        if(isLightningCooldown)
        {
            lightningCooldown -= 1 / lightningCooldownRate * Time.deltaTime;
            if(lightningCooldown <= 0f)
            {
                lightningCooldown = 0f;
                isLightningCooldown = false;
            }
        }
    }
    void CastFireball()
    {
        if (Input.GetKeyDown(KeyCode.W) && worldPosition.x < 5 && worldPosition.x > -5 && worldPosition.z < 5 && worldPosition.z > -5 && !isFireballCooldown)
        {
            Instantiate(fireballSpellPrefab, worldPosition, fireballSpellPrefab.transform.rotation);
            isFireballCooldown = true;
            fireballCooldown = 1f;
        }
        if (isFireballCooldown)
        {
            fireballCooldown -= 1 / fireballCooldownRate * Time.deltaTime;
            if (fireballCooldown <= 0f)
            {
                fireballCooldown = 0f;
                isFireballCooldown = false;
            }
        }
    }
    void CastEarthquake()
    {
        if (Input.GetKeyDown(KeyCode.E) && worldPosition.x < 5 && worldPosition.x > -5 && worldPosition.z < 5 && worldPosition.z > -5 && !isEarthquakeCooldown)
        {
            Instantiate(earthquakeSpellPrefab, worldPosition, earthquakeSpellPrefab.transform.rotation);
            isEarthquakeCooldown = true;
            earthquakeCooldown = 1f;
        }
        if (isEarthquakeCooldown)
        {
            earthquakeCooldown -= 1 / earthquakeCooldownRate * Time.deltaTime;
            if (earthquakeCooldown <= 0f)
            {
                earthquakeCooldown = 0f;
                isEarthquakeCooldown = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + screenPositionDepth;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;

        CastLightning();
        CastFireball();
        CastEarthquake();
        PlaceGlue();
    }
}
