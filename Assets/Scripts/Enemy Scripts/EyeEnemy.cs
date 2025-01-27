using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] Collider2D areaOfEffect;
    [SerializeField] Image laserImage;
    [SerializeField] Animator animator;
    [SerializeField] float holdTime = 1f;
    AudioSource audioSource;
    [SerializeField] AudioClip attackSound;
    // Start is called before the first frame update
    void Start()
    {
        areaOfEffect.tag = "Death";
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        CheckEyeState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Eye saw the player");
    }

    void CheckEyeState()
    {
        StartCoroutine(HoldTimeCoroutine());
    }
    IEnumerator HoldTimeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(holdTime);
            animator.SetTrigger("state");
        }
    }

    #region AnimationEvents
    public void EnableCollider()
    {
        audioSource.PlayOneShot(attackSound);
        areaOfEffect.enabled = true;
        laserImage.enabled = true;
    }
    public void DisableCollider()
    {
        areaOfEffect.enabled = false;
        laserImage.enabled = false;
    }
    #endregion
}
