using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static SkillTree;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int id;

    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{skillTree.SkillNames[id]}";
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.SkillPoint}/1 SP";

        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.yellow
             : skillTree.SkillPoint >= 1 ? Color.green : Color.white ;

        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0);
        }
    }

    public void Buy()
    {
        if (skillTree.SkillPoint < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        skillTree.SkillPoint -= 1;
        skillTree.SkillLevels[id]++;
        ApplySkillEffects();
        skillTree.UpdateAllSkillUI();
    }

    private void ApplySkillEffects()
    {
        // Apply specific effects based on skill ID
        switch (id)
        {
            case 1: // Health skill
                IncreaseHealth();
                break;
            case 2: // Mana skill
                IncreaseMana();
                break;
            case 3: // Armor skill
                ReduceDamage();
                break;
                // Add more cases for other skills if needed
        }
    }

    private void IncreaseHealth()
    {
        // Increase player's max health by 5
        PlayerHealth.Instance.IncreaseMaxHealth(5);
    }

    private void IncreaseMana()
    {
        // Increase player's max mana by 2
        PlayerMana.Instance.IncreaseMaxMana(2);
    }

    private void ReduceDamage()
    {
        // Reduce player's damage taken by 2
        PlayerHealth.Instance.IncreaseDamageReduction(2);
    }

}
