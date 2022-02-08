using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FIFA4
{
    public class MatchRecordChild : MonoBehaviour
    {
        [SerializeField] RectTransform m_rect;

        [Header("Name")]
        [SerializeField] TextMeshProUGUI m_meText;
        [SerializeField] TextMeshProUGUI m_otherText;

        [Header("Description")]
        [SerializeField] TextMeshProUGUI m_scoreText;
        [SerializeField] TextMeshProUGUI m_summaryText;
        [SerializeField] TextMeshProUGUI m_dateTimeText;

        public bool SetRecord(GameManager manager, MatchDTO match)
        {
            MatchDTO.MatchInfoDTO me = null;
            MatchDTO.MatchInfoDTO other = null;

            foreach (var matchInfo in match.matchInfos)
            {
                if (matchInfo.nickname == manager.UserInformation.nickname)
                    me = matchInfo;
                else
                    other = matchInfo;
            }

            if (me == null || other == null)
                return false;

            // Nickname.
            m_meText.text = me.nickname;
            m_otherText.text = other.nickname;

            // Description
            m_scoreText.text = string.Format("{0} : {1}", me.shoot.goalTotalDisplay, other.shoot.goalTotalDisplay);
            m_summaryText.text = (me.matchDetail.matchEndType == 0 ? me.matchDetail.matchResult : (me.matchDetail.matchEndType == 1 ? "몰수승" : "몰수패"));
            m_dateTimeText.text = match.matchDate.ToString("yyyy'년 'MM'월 'dd'일 'HH':'mm");

            return true;
        }
    }
}
