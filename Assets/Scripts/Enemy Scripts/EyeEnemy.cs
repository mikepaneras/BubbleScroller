using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] Collider2D areaOfEffect;
    [SerializeField] Animator animator;
    [SerializeField] float eyeOpenSpeed = 0.2f;
    [SerializeField] float eyeCloseSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        areaOfEffect.tag = "Death";
        animator.SetFloat("closing", eyeCloseSpeed);
        animator.SetFloat("opening", eyeOpenSpeed);
    }

    private void Update()
    {
        CheckEyeState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Eye saw the player");
    }

    void CheckEyeState()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("closing") != true){
            areaOfEffect.gameObject.SetActive(false);
        }
        else
        {
            areaOfEffect.gameObject.SetActive(true);
        }
    }

    #region AnimationEvents
    public void EnableCollider() => areaOfEffect.gameObject.SetActive(true);
    public void DisableCollider() => areaOfEffect.gameObject.SetActive(false);
    #endregion
}
