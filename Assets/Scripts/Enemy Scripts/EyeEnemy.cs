using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] Collider2D areaOfEffect;
    // Start is called before the first frame update
    void Start()
    {
        areaOfEffect.tag = "Death";
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Eye saw the player");
    }

    #region AnimationEvents
    public void EnableCollider() => areaOfEffect.gameObject.SetActive(true);
    public void DisableCollider() => areaOfEffect.gameObject.SetActive(false);
    #endregion
}
