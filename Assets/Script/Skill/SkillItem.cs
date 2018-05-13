using UnityEngine;
using System.Collections;

public enum PlayerType
{
    Warrior,
    FemaleAssassin,
};

public enum SkillType
{
    Basic,
    Skill,
}

public enum SkillPosType
{
    Basic,
    One,
    Two,
    Three,
}

public class SkillItem {

    int id;
    string skillName;
    string iconName;
    PlayerType playerType;
    SkillType skillType;
    SkillPosType skillPos;
    float coldTime;
    int basePower;
    int level = 1;

    #region protype
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string SkillName
    {
        get
        {
            return skillName;
        }

        set
        {
            skillName = value;
        }
    }

    public string IconName
    {
        get
        {
            return iconName;
        }

        set
        {
            iconName = value;
        }
    }

    public PlayerType PlayerType
    {
        get
        {
            return playerType;
        }

        set
        {
            playerType = value;
        }
    }

    public SkillType SkillType
    {
        get
        {
            return skillType;
        }

        set
        {
            skillType = value;
        }
    }

    public SkillPosType SkillPos
    {
        get
        {
            return skillPos;
        }

        set
        {
            skillPos = value;
        }
    }

    public float ColdTime
    {
        get
        {
            return coldTime;
        }

        set
        {
            coldTime = value;
        }
    }

    public int BasePower
    {
        get
        {
            return basePower;
        }

        set
        {
            basePower = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }
    #endregion
}
