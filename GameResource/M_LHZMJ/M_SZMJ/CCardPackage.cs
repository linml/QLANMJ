using MahjongAlgorithmForLHZMJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_LHZMJ
{
    /// <summary>
    /// 牌包
    /// </summary>
    public class CCardPackage
    {
        /// <summary>
        /// 静态常量属性
        /// </summary>
        public byte[] m_ConstAllCard = new byte[LHZMJConstants.gCardCount_Package]
        {
            //万：
            0x01, 0x01, 0x01, 0x01,0x02, 0x02, 0x02, 0x02, 0x03, 0x03, 0x03, 0x03,
            0x04, 0x04, 0x04, 0x04, 0x05, 0x05, 0x05, 0x05, 0x06, 0x06, 0x06, 0x06,
            0x07, 0x07, 0x07, 0x07, 0x08, 0x08, 0x08, 0x08,0x09, 0x09, 0x09, 0x09,

            //筒：二筒~八筒
            0x11, 0x11, 0x11, 0x11,0x12, 0x12, 0x12, 0x12, 0x13, 0x13, 0x13, 0x13,
            0x14, 0x14, 0x14, 0x14, 0x15, 0x15, 0x15, 0x15, 0x16, 0x16, 0x16, 0x16,
            0x17, 0x17, 0x17, 0x17, 0x18, 0x18, 0x18, 0x18,0x19, 0x19, 0x19, 0x19,

            //条：二条~八条
            0x21, 0x21, 0x21, 0x21,0x22, 0x22, 0x22, 0x22, 0x23, 0x23, 0x23, 0x23,
            0x24, 0x24, 0x24, 0x24, 0x25, 0x25, 0x25, 0x25, 0x26, 0x26, 0x26, 0x26,
            0x27, 0x27, 0x27, 0x27, 0x28, 0x28, 0x28, 0x28,0x29, 0x29, 0x29, 0x29,

            //风：东、南、西、北
           // 0x31,0x31,0x31,0x31, 0x32,0x32,0x32,0x32, 0x33,0x33,0x33,0x33 ,0x34,0x34,0x34,0x34,

            //字：中、发、白
            0x35,0x35,0x35,0x35
            //春夏秋冬，梅兰竹菊(每个只有一张牌)
       //     0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48
        };



        /// <summary>
        /// 牌包数据
        /// </summary>
        private List<byte> m_cPackage = new List<byte>(LHZMJConstants.gCardCount_Package);

        //private List<byte> m_cPackage1 = new List<byte>(WWMJConstants.gCardCount_Package1);
        //private List<byte> m_cPackage2 = new List<byte>(WWMJConstants.gCardCount_Package2);

        /// <summary>
        /// 初始化牌包
        /// </summary>
        private void Init()
        {
            m_cPackage.Clear();
            m_cPackage.AddRange(m_ConstAllCard);
        }

        /// <summary>
        /// 牌包中是否还有可以发的牌，淮北麻将最后四张海底捞，直接发
        /// </summary>
        public bool haveCard { get { return m_cPackage.Count > 0; } }

        /// <summary>
        /// 剩余牌张数
        /// </summary>
        public int leftCardNum { get { return m_cPackage.Count; } }

        /// <summary>
        /// 洗牌：混乱牌包中的牌,0为无风
        /// </summary>
        public void WashCard()
        {
            Init();

            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            for (int i = 0; i < m_cPackage.Count; i++)
            {
                int r = rand.Next(i, m_cPackage.Count);
                //交换
                byte changeCard = m_cPackage[i];
                m_cPackage[i] = m_cPackage[r];
                m_cPackage[r] = changeCard;
            }
        }

        /// <summary>
        /// 抓牌
        /// </summary>
        /// <param name="pDest"></param>
        /// <returns></returns>
        public bool HoldCard(List<byte> pDest)
        {
            pDest.Clear();

            pDest.AddRange(m_cPackage.GetRange(0, MahjongDef.gCardCount_Active - 1));
            m_cPackage.RemoveRange(0, MahjongDef.gCardCount_Active - 1);
            return true;
        }

        /// <summary>
        /// 抓第一张牌
        /// </summary>
        /// <returns></returns>
        public byte HoldCard()
        {
            if (m_cPackage.Count() < 1)
            {
                return MahjongDef.gInvalidMahjongValue;
            }

            byte card = m_cPackage.ElementAt(0);
            m_cPackage.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// 从牌包中取一张指定的牌,如果牌包中没有这张牌的话根据后面的参数决定是否选用牌包中的第一张牌
        /// </summary>
        /// <param name="card">指定的牌</param>
        /// <returns></returns>
        public byte HoldCard(byte card)
        {
            if (m_cPackage.Count() < 1)
            {
                return MahjongDef.gInvalidMahjongValue;
            }

            if (m_cPackage.Contains(card))
            {
                m_cPackage.Remove(card);
                return card;
            }

            card = m_cPackage.ElementAt(0);
            m_cPackage.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// 从牌包中获取一张不在指定集合中的牌
        /// </summary>
        /// <param name="checkSource"></param>
        /// <returns></returns>
        public byte HoldCardNotInSrc(List<byte> src)
        {
            if ((m_cPackage.Count() < 1) || (null == src) || (0 == src.Count()))
            {
                return MahjongDef.gInvalidMahjongValue;
            }

            byte returnCard = MahjongDef.gInvalidMahjongValue;

            int idx = -1;
            for (int i = 0; i < m_cPackage.Count(); i++)
            {
                if (!src.Contains(m_cPackage[i]))
                {
                    returnCard = m_cPackage[i];
                    idx = i;
                    break;
                }
            }
            if ((returnCard != MahjongDef.gInvalidMahjongValue) && (idx >= 0))
            {
                m_cPackage.RemoveAt(idx);
            }

            return returnCard;
        }

        /// <summary>
        /// 从牌包中获取一张指定集合中的牌,如果没有就抓牌包中第一张牌
        /// </summary>
        /// <param name="checkSource"></param>
        /// <returns></returns>
        public byte HoldCardInSrc(List<byte> src)
        {
            if (m_cPackage.Count() < 1)
            {
                return MahjongDef.gInvalidMahjongValue;
            }
            if ((null == src) || (src.Count < 1))
            {
                return HoldCard();
            }

            int idx = -1;
            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            byte returnCard = MahjongDef.gInvalidMahjongValue;

            do
            {
                //获取要随机的牌
                idx = randObj.Next(0, src.Count);

                //检查牌包中是否有该牌
                if (m_cPackage.Contains(src[idx]))
                {
                    returnCard = src[idx];
                    m_cPackage.Remove(returnCard);
                }

                src.RemoveAt(idx);

            } while ((returnCard == MahjongDef.gInvalidMahjongValue) && (src.Count > 0));

            //如果牌包中没有指定集合中的牌,就抓第一张牌
            if (returnCard == MahjongDef.gInvalidMahjongValue)
            {
                return HoldCard();
            }

            //找到这张牌就返回
            return returnCard;
        }

        /// <summary>
        /// 返回某张牌在牌包里的剩余张数
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int GetCardLeftCount(byte card)
        {
            if (MahjongDef.gInvalidMahjongValue == card)
            {
                return 0;
            }
            return m_cPackage.FindAll(delegate(byte checkCard) { return checkCard == card; }).Count();
        }
    }
}
