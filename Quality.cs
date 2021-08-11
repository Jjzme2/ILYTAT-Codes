using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ILYTATTools
{
    public class Quality
    {
        public string QualityName;
        public Color QualityColor;

        public static Quality Legendary
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Legendary";
                q.QualityColor = ExtraColors.Gold;
                return q;
            }
        }

        public static Quality Mythical
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Mythical";
                q.QualityColor = ExtraColors.MediumVioletRed;
                return q;
            }
        }

        public static Quality Epic
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Epic";
                q.QualityColor = ExtraColors.Fuchsia;
                return q;
            }
        }

        public static Quality Rare
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Rare";
                q.QualityColor = Color.blue;
                return q;
            }
        }

        public static Quality Uncommon
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Uncommon";
                q.QualityColor = Color.green;
                return q;
            }
        }

        public static Quality Common
        {
            get
            {
                Quality q = new Quality();
                q.QualityName = "Common";
                q.QualityColor = Color.white;
                return q;
            }
        }

        public static Quality GetRandomQuality()
        {
            Quality q = null;

            int ran = UnityEngine.Random.Range(0, 10000);

            if(ran < 5)
            {
                q = Legendary;
            }else if (ran < 25)
            {
                q = Mythical;
            }else if (ran < 100)
            {
                q = Epic;
            }else if (ran < 1000)
            {
                q = Rare;
            }else if (ran < 3000)
            {
                q = Uncommon;
            }
            else
            {
                q = Common;
            }

            return q;
        }
    }
}