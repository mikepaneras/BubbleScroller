using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] Collider2D areaOfEffect;
    [SerializeField] Animator animator;
    [SerializeField] float eyeOpenSpeed = 0.2f;
    [SerializeField] float holdTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        areaOfEffect.tag = "Death";

        CheckEyeState();
    }

    private void Update()
    {
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
    public void EnableCollider() => areaOfEffect.gameObject.SetActive(true);
    public void DisableCollider() => areaOfEffect.gameObject.SetActive(false);
    #endregion
}
