using UnityEngine;
using System.Collections;

public class SkillData : MonoBehaviour {

    SkillItem skillitem = null;

    public SkillItem Skillitem
    {
        get
        {
            return skillitem;
        }

        set
        {
            skillitem = value;
        }
    }

    private void Start()
    {
        EventDelegate ed = new EventDelegate(this, "OnClick");
        GetComponent<UIButton>().onClick.Add(ed);
    }

    void OnClick() {
        transform.parent.GetComponent<SkillBarUI>().SendMessage("OnClickSkill", skillitem);
    }
}
