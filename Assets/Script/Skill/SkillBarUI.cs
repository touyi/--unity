using UnityEngine;
using System.Collections;

public class SkillBarUI : MonoBehaviour {
    
    UISprite skillOneSprite;
    UISprite skillTwoSprite;
    UISprite skillThreeSprite;

    UIButton skillOneBtn;
    UIButton skillTwoBtn;
    UIButton skillThreeBtn;
    UIButton upgradeBtn;
    UIButton closeBtn;

    UILabel skillNameLabel;
    UILabel skillDesLabel;

    SkillItem _nowSkill = null;

    private void Awake()
    {
        skillOneSprite = transform.Find("Skill_one").GetComponent<UISprite>();
        skillTwoSprite = transform.Find("Skill_two").GetComponent<UISprite>();
        skillThreeSprite = transform.Find("Skill_three").GetComponent<UISprite>();

        skillOneBtn = transform.Find("Skill_one").GetComponent<UIButton>();
        skillTwoBtn = transform.Find("Skill_two").GetComponent<UIButton>();
        skillThreeBtn = transform.Find("Skill_three").GetComponent<UIButton>();
        upgradeBtn = transform.Find("btn_upgrade").GetComponent<UIButton>();
        closeBtn = transform.Find("btn_close").GetComponent<UIButton>();

        skillNameLabel = transform.Find("Skill_nameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Skill_desLabel").GetComponent<UILabel>();

    }
    private void Start()
    {
        Init();
    }
    void Init() {
        SkillItem skillOne = SkillManager.Instance.GetSkill(SkillPosType.One);
        SkillItem skillTwo = SkillManager.Instance.GetSkill(SkillPosType.Two);
        SkillItem skillThree = SkillManager.Instance.GetSkill(SkillPosType.Three);

        skillOneSprite.spriteName = skillOne.IconName;
        skillTwoSprite.spriteName = skillTwo.IconName;
        skillThreeSprite.spriteName = skillThree.IconName;

        skillOneBtn.normalSprite = skillOneSprite.spriteName;
        skillTwoBtn.normalSprite = skillTwoSprite.spriteName;
        skillThreeBtn.normalSprite = skillThreeSprite.spriteName;

        skillOneBtn.gameObject.GetComponent<SkillData>().Skillitem = skillOne;
        skillTwoBtn.gameObject.GetComponent<SkillData>().Skillitem = skillTwo;
        skillThreeBtn.gameObject.GetComponent<SkillData>().Skillitem = skillThree;

        SkillItem item = SkillManager.Instance.GetSkill(SkillPosType.One);
        skillNameLabel.text = item.SkillName + " Lv." + item.Level;
        skillDesLabel.text = CreateSkillDescribe(item);

        EventDelegate ed = new EventDelegate(this, "OnClickUpgrade");
        upgradeBtn.onClick.Add(ed);

        _nowSkill = skillOne;
    }

    string CreateSkillDescribe(SkillItem item)
    {
        return "技能当前攻击力：" + item.BasePower * item.Level + " 下级攻击力：" + item.BasePower * (item.Level + 1) + " 升级所需金币：" + 500 * (item.Level + 1);
    }

    void OnClickSkill(SkillItem item)
    {
        _nowSkill = item;
        UpdateSkill();
        CheckAndSetUpgradeBtn();

    }

    void UpdateSkill()
    {
        skillNameLabel.text = _nowSkill.SkillName + " Lv." + _nowSkill.Level;
        skillDesLabel.text = CreateSkillDescribe(_nowSkill);
    }

    void OnClickUpgrade()
    {
        if (!PlayerInfo._instance.GetCoin((_nowSkill.Level + 1) * 500)) return;
        _nowSkill.Level += 1;
        UpdateSkill();
        CheckAndSetUpgradeBtn();
    }

    void CheckAndSetUpgradeBtn()
    {
        if ((_nowSkill.Level + 1) * 500 > PlayerInfo._instance.Coin || _nowSkill.Level >= PlayerInfo._instance.Level)
        {
            upgradeBtn.SetState(UIButtonColor.State.Disabled, true);
            // TODO 修改按钮文字
            
        }
        else
        {
            upgradeBtn.SetState(UIButtonColor.State.Normal, true);
            // TODO 修改按钮文字
        }
    }
}
