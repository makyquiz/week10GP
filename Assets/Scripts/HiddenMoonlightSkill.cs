using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenMoonlightSkill : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int baseAttackSpeed = 1;
    public int boostedAttackSpeed = 5;
    public float invisibilityDuration = 2f;
    public float attackSpeedBoostDuration = 3f;

    private bool activeSkill = false;
    private bool isInvisible = false;
    private float abilityTime;
    private int currentAttackSpeed;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentAttackSpeed = baseAttackSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !activeSkill)
        {
            activeSkill = true;
            isInvisible = true;
            abilityTime = 0f;
            currentAttackSpeed = boostedAttackSpeed;

            HiddenMoonlight();
        }

        if (activeSkill)
        {
            abilityTime += Time.deltaTime;

            if (isInvisible && abilityTime >= invisibilityDuration)
            {
                EndInvisibility();
            }

            if (abilityTime >= attackSpeedBoostDuration)
            {
                ResetSkill();
            }
        }
    }

    void HiddenMoonlight()
    {
        meshRenderer.enabled = false;
    }

    void EndInvisibility()
    {
        meshRenderer.enabled = true;
        isInvisible = false;
    }

    void ResetSkill()
    {
        currentAttackSpeed = baseAttackSpeed;
        activeSkill = false;
    }
}
