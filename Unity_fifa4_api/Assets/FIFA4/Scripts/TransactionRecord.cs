using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FIFA4
{
    public class TransactionRecord : MonoBehaviour
    {
        [SerializeField] RectTransform m_rect;

        [Header("UI")]
        [SerializeField] Image m_playerImage;
        [SerializeField] Image m_seasonImage;

        [Space]
        [SerializeField] TextMeshProUGUI m_gradeText;
        [SerializeField] TextMeshProUGUI m_moneyText;
        [SerializeField] TextMeshProUGUI m_dateText;

        public DateTime Date { get; private set; }
        public RectTransform Rect { get { return m_rect; } }
        public bool IsPurchase { get; private set; }

        public void SetRecord(GameManager manager, TransactionRecords records, bool isPurchase)
        {
            IsPurchase = isPurchase;

            // Get season and player image.
            StartCoroutine(manager.RequestService.GetSeasonImageFromSpid((response) => m_seasonImage.sprite = response.data, records.spid));
            StartCoroutine(manager.RequestService.GetPlayerImage((response) => m_playerImage.sprite = response.data.Value, (response) => m_playerImage.sprite = response.data, records.spid));

            m_gradeText.text = string.Format("+{0}", records.grade);
            m_moneyText.text = string.Format("{0}{1} BP", isPurchase ? "-" : "", records.money.ToString("N0"));
            m_dateText.text = records.tradeDate.ToString("yyyy'년 'MM'월 'dd'일'");

            Date = records.tradeDate;
        }
    }
}
