using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Robot.Alliance alliance;
    private Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Robot.AllianceColors[alliance];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
        animator.setBool("BeingShot", true);
    }
}
