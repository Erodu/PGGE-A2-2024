﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using PGGE;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public FSM mFsm = new FSM();
    public Animator mAnimator;
    public PlayerMovement mPlayerMovement;
    public AnimationClip attack1Clip;
    public int mCurrentAttackID;
    private PhotonView mPhotonView;

    [HideInInspector]
    public bool[] mAttackButtons = new bool[2];

    public int[] AttacksPerSecond = new int[2];
    bool[] mAttacking = new bool[2];

    [HideInInspector] public bool isRecharging = false;

    public TextMeshPro playerName;

    // Start is called before the first frame update
    void Start()
    {
        mPhotonView = GetComponentInParent<PhotonView>();

        mFsm.Add(new PlayerState_MOVEMENT(this));
        mFsm.Add(new PlayerState_ATTACK(this));
        mFsm.Add(new PlayerState_RECHARGE(this));
        mFsm.SetCurrentState((int)PlayerStateType.MOVEMENT);

        playerName.text = mPhotonView.Owner.NickName.ToString();
    }

    void Update()
    {
        if (!mPhotonView.IsMine) return;

        mFsm.Update();

        if (Input.GetButtonDown("Fire1"))
        {
            mAttackButtons[0] = true;
            mAttackButtons[1] = false;
            //mAttackButtons[2] = false;
        }
        else
        {
            mAttackButtons[0] = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = true;
            //mAttackButtons[2] = false;
        }
        else
        {
            mAttackButtons[1] = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && isRecharging == false)
        {
            //Debug.Log("Recharge Start");
            isRecharging = true;
            mFsm.SetCurrentState((int)PlayerStateType.RECHARGE);
        }

    }

    public void Move()
    {
        if (!mPhotonView.IsMine) return;
        mPlayerMovement.HandleInputs();
        mPlayerMovement.Move();
    }

    public void Recharge()
    {
        StartCoroutine(Coroutine_DelayRechargeSound());
    }

    IEnumerator Coroutine_DelayRechargeSound(float duration = 1.0f)
    {
        yield return new WaitForSeconds(duration);
    }
    public IEnumerator Coroutine_Attacking(int id, float frameLength)
    {
        mAttacking[id] = true;
        // Wait until animation is finished.
        yield return new WaitForSeconds(frameLength);
    }

    public void SetToMovement()
    {
        // This function is used in an Animation Event. Just in case the state doesn't transition back to movement IMMEDIATELY when the animation ends.
        mAnimator.SetBool("Attack" + (mCurrentAttackID+1), false);
        mFsm.SetCurrentState((int)PlayerStateType.MOVEMENT);
    }
}