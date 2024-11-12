using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    public PlayerMovement Playermovement { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public GameObject SA, SB, SC, SD;
    
    private bool SkinA;
    private bool SkinB;
    private bool SkinC;
    private bool SkinD;
    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        this.Playermovement = GetComponent<PlayerMovement>();
    }

    public void Start()
    {
        SA.SetActive(true);

        SkinA = SkinController.SkinA;
        SkinB = SkinController.SkinB;
        SkinC = SkinController.SkinC;
        SkinD = SkinController.SkinD;

        if (SkinA == true)
        {
            SA.SetActive(true);
            SB.SetActive(false);
            SC.SetActive(false);
            SD.SetActive(false);
        }

        if (SkinB == true)
        {
            SA.SetActive(false);
            SB.SetActive(true);
            SC.SetActive(false);
            SD.SetActive(false);
        }

        if (SkinC == true)
        {
            SA.SetActive(false);
            SB.SetActive(false);
            SC.SetActive(true);
            SD.SetActive(false);
        }

        if (SkinD == true)
        {
            SA.SetActive(false);
            SB.SetActive(false);
            SC.SetActive(false);
            SD.SetActive(true);
        }
    }
    private void Update()
    {
    }
    public void ResetState()
    {
        enabled = true;
        //spriteRenderer.enabled = true;
        collider.enabled = true;
        this.gameObject.SetActive(true);
        this.Playermovement.ResetRound();
    }
}