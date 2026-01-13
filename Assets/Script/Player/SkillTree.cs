using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;

    private void Start()
    {
        SkillPoint = 20;

        SkillLevels = new int[4];
        SkillCaps = new[] { 1, 5, 5, 5 };

        SkillNames = new[] { "Corruption", "Health", "Mana", "Armor" };
        SkillDescriptions = new[]
        {
            "Unlock Corrupt power",
            "Increase Health by 5",
            "Increase Mana by 2",
            "Reduce Damage by 2",
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] { 1, 2, 3 };

        UpdateAllSkillUI();
    }
      
    public void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList) skill.UpdateUI();
    }
}
