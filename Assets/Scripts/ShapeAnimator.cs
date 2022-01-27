using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeAnimator : MonoBehaviour
{
    private Animator animator;
    private float animationTime=3f;

    // Start is called before the first frame update
    void Start()
    {
        //Gets relevant component
        animator = GetComponentInChildren<Animator>();

        //Animator enable
        animator.enabled = true;

        //Starting animation
        animator.SetBool("collided", false);
    }
    private void FixedUpdate()
    {
        //Coroutine to toggle after animation time
        if(animator.GetBool("collided"))
        {
            StartCoroutine(ToggleAnimationOff());
        }
    }
    IEnumerator ToggleAnimationOff()
    {
        //Yield that waits for animationTime
        yield return new WaitForSeconds(animationTime);

        //Toggle relevant bools
        animator.SetBool("collided", false);
    }

    //When colliding play the animation
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("collided", true);
    }
}
