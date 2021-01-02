using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour
{
    private bool m_IsOnGround;

    public bool IsOnGround
    {
        get
        {
            if(m_IsOnGround)
            {
                m_IsOnGround = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    void CollsionOnStay()
    {
        m_IsOnGround = true;
    }
}
