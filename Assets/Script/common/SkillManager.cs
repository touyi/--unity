using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

public class SkillManager {

    public TextAsset skillText;
    List<SkillItem> skillItems = new List<SkillItem>();

    static SkillManager _instance = null;

    public static SkillManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SkillManager();
                _instance.InitSkill();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 初始化技能
    /// </summary>
    void InitSkill()
    {
        skillText = Resources.Load("txt/Skill         技能信息清单", typeof(TextAsset)) as TextAsset;
        string[] text = skillText.text.Split('\n');
        foreach (string line in text)
        {
            string[] infs = line.Split(',');

            if (infs.Length != 8)
            {
                Debug.LogError("Skill Initialize error:Configuration information error");
                return;
            }
            SkillItem item = new SkillItem();
            item.Id = int.Parse(infs[0]);
            item.SkillName = infs[1];
            item.IconName = infs[2];

            foreach (PlayerType tp in System.Enum.GetValues(typeof(PlayerType)))
            {
                if (tp.ToString().Equals(infs[3]))
                {
                    item.PlayerType = tp;
                }
            }

            foreach (SkillType tp in System.Enum.GetValues(typeof(SkillType)))
            {
                if (tp.ToString().Equals(infs[4]))
                {
                    item.SkillType = tp;
                }
            }

            foreach (SkillPosType tp in System.Enum.GetValues(typeof(SkillPosType)))
            {
                if (tp.ToString().Equals(infs[5]))
                {
                    item.SkillPos = tp;
                }
            }

            item.ColdTime = float.Parse(infs[6]);

            item.BasePower = int.Parse(infs[7]);
            item.Level = 1;
            skillItems.Add(item);
        }
    }
    /// <summary>
    /// 获得指定位置技能
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public SkillItem GetSkill(SkillPosType pos = SkillPosType.Basic)
    {
        PlayerType ptype = PlayerInfo._instance.PlayerType;
        foreach(SkillItem it in skillItems)
        {
            if(it.SkillPos == pos && it.PlayerType == ptype)
            {
                return it;
            }
        }
        return null;
    }
}
