using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongAlgorithmForMGMJ
{
    /// <summary>
    /// 麻将通用算法
    /// </summary>
    public class MahjongGeneralAlgorithm
    {
        #region 取牌值相关

        /// <summary>
        /// 取麻将牌花色
        /// </summary>
        /// <param name="Card"></param>
        /// <returns>0万，1筒，2条，3字</returns>
        public static byte GetMahjongColor(byte Card)
        {
            return (byte)((Card & MahjongDef.gCardMask_color) >> 4);
        }
        /// <summary>
        /// 取花色数值,0x00万,0x10筒,0x20条
        /// </summary>
        /// <param name="Card"></param>
        /// <returns></returns>
        public static byte GetMahjongColorValue(byte Card)
        {
            return (byte)(Card & MahjongDef.gCardMask_color);
        }
        /// <summary>
        /// 取麻将牌值,1~9,一万==一筒==一条
        /// </summary>
        /// <param name="Card"></param>
        /// <returns></returns>
        public static byte GetMahjongValue(byte Card)
        {
            return (byte)(Card & MahjongDef.gCardMask_value);
        }
        /// <summary>
        /// 取麻将牌逻辑数值,取牌逻辑值:万<筒<条<字<花
        /// </summary>
        /// <param name="Card"></param>
        /// <returns></returns>
        public static byte GetMahjongLogicValue(byte Card)
        {
            return ((byte)(GetMahjongValue(Card) + GetMahjongColor(Card) * 10));
        }

        #endregion

        #region 权限检查

        /// <summary>
        /// 检查投票权限:是否可碰
        /// </summary>
        /// <param name="voteRight">投票权限</param>
        /// <returns>可以碰返回true,否则返回false</returns>
        public static bool CheckVoteRight_Peng(byte voteRight)
        {
            return (voteRight & MahjongDef.gVoteRightMask_Peng) > 0;
        }
        /// <summary>
        /// 检查投票权限:是否可杠
        /// </summary>
        /// <param name="voteRight">投票权限</param>
        /// <returns>可以杠返回true,否则返回false</returns>
        public static bool CheckVoteRight_Gang(byte voteRight)
        {
            return (voteRight & MahjongDef.gVoteRightMask_Gang) > 0;
        }
        /// <summary>
        /// 检查投票权限:是否可胡
        /// </summary>
        /// <param name="voteRight">投票权限</param>
        /// <returns>可以胡返回true,否则返回false</returns>
        public static bool CheckVoteRight_Hu(byte voteRight)
        {
            return (voteRight & MahjongDef.gVoteRightMask_Hu) > 0;
        }


        /// <summary>
        /// 检查操作权限:是否可杠
        /// </summary>
        /// <param name="operateRight">操作权限</param>
        /// <returns>可以返回true,否则返回false</returns>
        public static bool CheckOperateRight_Gang(byte operateRight)
        {
            return (operateRight & MahjongDef.gOperateRightMask_Gang) > 0;
        }
        /// <summary>
        /// 检查操作权限:是否可自摸
        /// </summary>
        /// <param name="operateRight">操作权限</param>
        /// <returns>可以返回true,否则返回false</returns>
        public static bool CheckOperateRight_Zimo(byte operateRight)
        {
            return (operateRight & MahjongDef.gOperateRightMask_Zimo) > 0;
        }

        #endregion

        #region 工具方法

        /// <summary>
        /// 取一个相对随机对象
        /// </summary>
        /// <returns></returns>
        public static Random GetRandomObject()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// 打乱一个数组
        /// </summary>
        /// <param name="ary"></param>
        public static void Upset(List<byte> ary)
        {
            if (ary.Count == 0)
            {
                return;
            }
            Random rand = GetRandomObject();

            for (int i = 0; i < ary.Count; i++)
            {
                int r = rand.Next(0, ary.Count);
                //交换
                byte changeCard = ary[i];
                ary[i] = ary[r];
                ary[r] = changeCard;
            }
        }

        /// <summary>
        /// 检查指定牌是否是将牌:2,5,8的非字牌
        /// </summary>
        /// <param name="checkCard"></param>
        /// <returns></returns>
        public static bool CheckIsJiangCard(byte checkCard)
        {
            if (MahjongDef.gMahjongColor_Zhi == MahjongGeneralAlgorithm.GetMahjongColor(checkCard))
            {
                return false;
            }

            if ((2 == MahjongGeneralAlgorithm.GetMahjongValue(checkCard)) ||
               (5 == MahjongGeneralAlgorithm.GetMahjongValue(checkCard)) ||
               (8 == MahjongGeneralAlgorithm.GetMahjongValue(checkCard)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否是幺九牌
        /// </summary>
        /// <param name="checkCard"></param>
        /// <returns></returns>
        public static bool CheckIs19Card(byte checkCard)
        {
            if (MahjongDef.gMahjongColor_Zhi == MahjongGeneralAlgorithm.GetMahjongColor(checkCard))
            {
                return false;
            }

            if ((1 == MahjongGeneralAlgorithm.GetMahjongValue(checkCard)) ||
               (9 == MahjongGeneralAlgorithm.GetMahjongValue(checkCard)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 根据花色分拣牌阵
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vectorWan"></param>
        /// <param name="vectorTong"></param>
        /// <param name="vectorTiao"></param>
        /// <param name="vectorZhi"></param>
        public static void SpiltHandCardByCardColor(List<byte> srcAry, List<byte> vectorWan, List<byte> vectorTong, List<byte> vectorTiao, List<byte> vectorZhi)
        {
            List<byte> vSrc = new List<byte>(srcAry);

            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            vectorWan.Clear();
            vectorTong.Clear();
            vectorTiao.Clear();
            vectorZhi.Clear();

            if (vSrc.Count < 1)
            {
                return;
            }
            for (short i = 0; i < vSrc.Count; i++)
            {
                //取这张牌的花色
                switch (GetMahjongColor(vSrc[i]))
                {
                    case MahjongDef.gMahjongColor_Wan://万
                        {
                            vectorWan.Add(vSrc[i]);
                            break;
                        }
                    case MahjongDef.gMahjongColor_Tong://筒
                        {
                            vectorTong.Add(vSrc[i]);
                            break;
                        }
                    case MahjongDef.gMahjongColor_Tiao://条
                        {
                            vectorTiao.Add(vSrc[i]);
                            break;
                        }
                    case MahjongDef.gMahjongColor_Zhi: //字
                        {
                            vectorZhi.Add(vSrc[i]);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 分割孤张
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vJDGuCard"></param>
        /// <param name="vXGGuCard"></param>
        /// <param name="vXDGuCard"></param>
        /// <param name="vPair"></param>
        /// <param name="vXLWrapper"></param>
        public static void SpiltGuCard(List<byte> srcAry, List<byte> vJDGuCard, List<byte> vXGGuCard, List<byte> vXDGuCard, List<byte> vPair, List<clsSpiltXLWrapper> vXLWrapper)
        {
            List<byte> vSrc = new List<byte>(srcAry);

            vJDGuCard.Clear();
            vXGGuCard.Clear();
            vXDGuCard.Clear();
            vPair.Clear();
            vXLWrapper.Clear();

            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            //如何不存在孤张就不用分
            if (vSrc.Count == 0)
            {
                return;
            }
            if (vSrc.Count < 2)
            {
                vJDGuCard.Add(vSrc[0]);
                return;
            }

            for (int i = 0; i < vSrc.Count; i++)
            {
                if (i == (vSrc.Count - 1))//如果是最后一个，检查完直接跳出循环
                {
                    //如果是字牌，就是绝对的孤张，否则再去检查是否与前一个牌成相邻关系
                    if (GetMahjongColor(vSrc[i]) == MahjongDef.gMahjongColor_Zhi)
                    {
                        vJDGuCard.Add(vSrc[i]);
                    }
                    else
                    {
                        //如果是值为1的牌，肯定是绝对孤张,否则再去检查是否可以与前一个组成相邻关系
                        if (GetMahjongValue(vSrc[i]) == 1)
                        {
                            vJDGuCard.Add(vSrc[i]);
                        }
                        else
                        {
                            if ((vSrc[i] - vSrc[i - 1]) == 1)
                            {
                                vXDGuCard.Add(vSrc[i]);
                            }
                            else
                            {
                                //是否相隔孤张
                                if (((vSrc[i] - vSrc[i - 1]) == 2) && (GetMahjongColor(vSrc[i]) == GetMahjongColor(vSrc[i - 1])))
                                {
                                    vXGGuCard.Add(vSrc[i]);
                                }
                                else
                                {
                                    vJDGuCard.Add(vSrc[i]);
                                }
                            }
                        }
                    }

                    break;
                }

                //检查对子
                if (i < (vSrc.Count - 1))
                {
                    if (vSrc[i] == vSrc[i + 1])
                    {
                        vPair.Add(vSrc[i]);
                        i += 1;
                        continue;
                    }
                }

                //检查相邻
                if ((GetMahjongColor(vSrc[i]) != MahjongDef.gMahjongColor_Zhi) && (i < (vSrc.Count() - 1)) && ((GetMahjongColor(vSrc[i + 1])) != MahjongDef.gMahjongColor_Zhi))//字牌不存在相邻关系
                {
                    if ((vSrc[i] + 1) == vSrc[i + 1])
                    {
                        if (i < (vSrc.Count - 2))//再排除这种情况：233
                        {
                            if (vSrc[i + 1] != vSrc[i + 2])
                            {
                                clsSpiltXLWrapper xlwp = new clsSpiltXLWrapper();
                                xlwp.Set(vSrc[i], vSrc[i + 1]);
                                vXLWrapper.Add(xlwp);
                                i += 1;
                                continue;
                            }
                        }
                        else
                        {
                            clsSpiltXLWrapper xlwp = new clsSpiltXLWrapper();
                            xlwp.Set(vSrc[i], vSrc[i + 1]);
                            vXLWrapper.Add(xlwp);
                            i += 1;
                            continue;
                        }
                    }
                }

                //只能是散牌，如果是非字牌，再去检查是否可以与前一个或是后一个组成相邻牌
                if (GetMahjongColor(vSrc[i]) == MahjongDef.gMahjongColor_Zhi)
                {
                    vJDGuCard.Add(vSrc[i]);
                }
                else
                {
                    //1、先检查能否与后一个组成相邻:[3]44
                    if ((vSrc[i] + 1) == vSrc[i + 1])
                    {
                        vXDGuCard.Add(vSrc[i]);
                        continue;
                    }
                    //2、再检查能否与前一个组成相邻:33[4]
                    if ((i > 0) && ((vSrc[i] - vSrc[i - 1]) == 1))
                    {
                        vXDGuCard.Add(vSrc[i]);
                        continue;
                    }
                    //3、与后一个组成相隔孤张
                    //是否相隔孤张
                    if (((vSrc[i] + 2) == vSrc[i + 1]) && (GetMahjongColor(vSrc[i]) == GetMahjongColor(vSrc[i + 1])))
                    {
                        vXGGuCard.Add(vSrc[i]);
                        continue;
                    }
                    //4、与前一个组成相隔孤张
                    if ((i > 0) && ((vSrc[i] - vSrc[i - 1]) == 2) && (GetMahjongColor(vSrc[i]) == GetMahjongColor(vSrc[i - 1])))
                    {
                        vXGGuCard.Add(vSrc[i]);
                        continue;
                    }
                    //5、只能是绝对孤张
                    vJDGuCard.Add(vSrc[i]);
                }
            }
        }

        /// <summary>
        /// 将源数组分拣成杠，刻，对，散
        /// </summary>
        /// <param name="vSrc">源牌阵</param>
        /// <param name="vGang">目标杠</param>
        /// <param name="vEcho">目标刻</param>
        /// <param name="vPair">目标对</param>
        /// <param name="vHash">目标散牌</param>
        public static void SpiltHandCardToGEPH(List<byte> srcAry, List<byte> vGang, List<byte> vEcho, List<byte> vPair, List<byte> vHash)
        {
            List<byte> vSrc = new List<byte>();
            vSrc.AddRange(srcAry);

            vGang.Clear();
            vEcho.Clear();
            vPair.Clear();
            vHash.Clear();

            if (vSrc.Count() < 1)
            {
                return;
            }

            if (vSrc.Count() == 1)
            {
                vHash.Add(vSrc[0]);
                return;
            }

            //剔除无效牌再排序一下
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            int wCount = vSrc.Count();
            for (int i = 0; i < wCount; i++)
            {
                //找杠
                if (i < (wCount - 3))
                {
                    if ((vSrc[i] == vSrc[i + 1]) && (vSrc[i] == vSrc[i + 2]) && (vSrc[i] == vSrc[i + 3]))
                    {
                        vGang.Add(vSrc[i]);
                        i += 3;
                        continue;
                    }
                }
                //找刻
                if (i < (wCount - 2))
                {
                    if ((vSrc[i] == vSrc[i + 1]) && (vSrc[i] == vSrc[i + 2]))
                    {
                        vEcho.Add(vSrc[i]);
                        i += 2;
                        continue;
                    }
                }
                //找对
                if (i < (wCount - 1))
                {
                    if (vSrc[i] == vSrc[i + 1])
                    {
                        vPair.Add(vSrc[i]);
                        i += 1;
                        continue;
                    }
                }
                //只能是散牌
                vHash.Add(vSrc[i]);
            }
        }

        /// <summary>
        /// 分析一副单一花色牌阵的权值
        /// </summary>
        /// <param name="srcAry"></param>
        /// <returns></returns>
        public static int AnalysisSignleColorCardWeightValue(List<byte> srcAry)
        {
            /**
             1、杠+100分
             2、刻+75
             3、顺+50
             4、对+30
             5、相邻孤张+20
             6、相对孤张+5
             7、相隔孤张+5
             8、绝对孤张-2
             */

            int weightValue = srcAry.Count;

            //1、先将牌阵分割成:杠，刻，对，散
            List<byte> gang = new List<byte>();
            List<byte> echo = new List<byte>();
            List<byte> pair = new List<byte>();
            List<byte> hash = new List<byte>();
            MahjongGeneralAlgorithm.SpiltHandCardToGEPH(srcAry, gang, echo, pair, hash);

            //2、将对和散撮合在一起，提取顺子
            List<byte> newSrc = new List<byte>();
            newSrc.AddRange(pair);
            newSrc.AddRange(pair);
            newSrc.AddRange(hash);

            //2、长度大于等于3
            List<List<byte>> vEchoOrFlash = new List<List<byte>>();
            //1、长度小于3时，不需要去顺去刻
            if (newSrc.Count >= 3)
            {
                //搜各种可能的顺或者刻
                SearchEchoOrFlash(newSrc, vEchoOrFlash);
                //去重复
                vEchoOrFlash = vEchoOrFlash.Distinct().ToList();
            }

            //3、将提取顺子之后的牌分割成对子和各种类型的孤张
            foreach (var flash in vEchoOrFlash)
            {
                foreach (var card in flash)
                {
                    newSrc.Remove(card);
                }
            }

            List<byte> vJDGuCard = new List<byte>();
            List<byte> vXGGuCard = new List<byte>();
            List<byte> vXDGuCard = new List<byte>();
            List<byte> vPair = new List<byte>();
            List<clsSpiltXLWrapper> vXLWrapper = new List<clsSpiltXLWrapper>();
            MahjongGeneralAlgorithm.SpiltGuCard(newSrc, vJDGuCard, vXGGuCard, vXDGuCard, vPair, vXLWrapper);

            //4、计算权值
            weightValue += gang.Count * 100 + echo.Count * 75 + vEchoOrFlash.Count * 50 + vPair.Count * 30 + vXLWrapper.Count * 20 + vXDGuCard.Count * 5 + vXGGuCard.Count * 5 - vJDGuCard.Count * 2;

            return weightValue;
        }

        /// <summary>
        /// 取一单张牌权值
        /// </summary>
        /// <param name="cCard"></param>
        /// <returns></returns>
        public static int GetSingleCardWeightValue(byte card)
        {
            if (MahjongDef.gInvalidMahjongValue == card)
            {
                return 0;
            }

            return (MahjongGeneralAlgorithm.GetMahjongValue(card) > 5 ? 10 - MahjongGeneralAlgorithm.GetMahjongValue(card) : MahjongGeneralAlgorithm.GetMahjongValue(card));
        }

        /// <summary>
        /// 根据权值排序
        /// </summary>
        public static void SortCardByWeightValue(List<byte> cardAry)
        {
            if (cardAry.Count < 2)
            {
                return;
            }

            for (int i = 0; i < cardAry.Count - 1; i++)
            {
                for (int j = i + 1; j < cardAry.Count; j++)
                {
                    if (GetSingleCardWeightValue(cardAry[i]) > GetSingleCardWeightValue(cardAry[j]))
                    {
                        byte temp = cardAry[i];
                        cardAry[i] = cardAry[j];
                        cardAry[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 取<=4张牌阵类型
        /// </summary>
        /// <param name="vectorCard"></param>
        /// <param name="cardWrapper"></param>
        public static void AnalysisCardCharacterWrapper(List<byte> srcCard, ref clsCardCharacterWrapper cardWrapper)
        {
            cardWrapper.clear();
            if ((srcCard.Count) > 4 || (srcCard.Count < 1))
            {
                return;
            }

            var cardAry = new List<byte>(srcCard);
            cardAry.RemoveAll(p => { return MahjongDef.gInvalidMahjongValue == p; });
            cardAry.Sort();

            if (cardAry.Count < 1)
            {
                return;
            }

            cardWrapper.cardData.AddRange(cardAry);

            switch (cardAry.Count)
            {
                case 1://散牌
                    {
                        cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_1_Hash;
                        return;
                    }
                case 2://对子，相邻，相隔,两张散牌
                    {
                        byte c1 = MahjongGeneralAlgorithm.GetMahjongColor(cardAry[0]);
                        byte c2 = MahjongGeneralAlgorithm.GetMahjongColor(cardAry[1]);

                        //对子
                        if (c1 == c2)
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_2_Pair;
                            return;
                        }
                        //相邻
                        if (Math.Abs(c1 - c2) == 1)
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_2_XL;
                            return;
                        }

                        //相隔
                        if ((Math.Abs(c1 - c2) == 2) && (MahjongGeneralAlgorithm.GetMahjongColor(cardAry[0]) == MahjongGeneralAlgorithm.GetMahjongColor(cardAry[1])))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_2_XG;

                            if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) >= MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[0]);
                            }

                            return;
                        }
                        //散牌
                        cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_2_Hash;
                        if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) >= MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                        {
                            cardWrapper.cardData.Clear();
                            cardWrapper.cardData.Add(cardAry[1]);
                            cardWrapper.cardData.Add(cardAry[0]);
                        }

                        return;
                    }
                case 3://刻，顺，对+散，相邻+散，相隔+散，散
                    {
                        byte c1 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[0]);
                        byte c2 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[1]);
                        byte c3 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[2]);

                        //刻
                        if ((c1 == c2) && (c1 == c3))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_Echo;
                            return;
                        }
                        //顺
                        if (((c2 - c1) == 1) && ((c3 - c2) == 1))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_Flash;
                            MahjongGeneralAlgorithm.SortCardByWeightValue(cardWrapper.cardData);
                            return;
                        }
                        //对+散牌
                        if ((c1 == c2) || (c2 == c3))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_PairAndHash;
                            if (c1 == c2)
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[0]);
                            }

                            return;
                        }
                        //相邻+散
                        if (((c2 - c1) == 1) || ((c3 - c2) == 1))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_XLAndHash;

                            if ((c2 - c1) == 1)
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[0]);
                            }
                            return;
                        }
                        //相隔+散
                        if ((((c2 - c1) == 2) && (MahjongGeneralAlgorithm.GetMahjongColor(cardAry[0]) == MahjongGeneralAlgorithm.GetMahjongColor(cardAry[1]))) ||
                            (((c3 - c2) == 2) && (MahjongGeneralAlgorithm.GetMahjongColor(cardAry[1]) == MahjongGeneralAlgorithm.GetMahjongColor(cardAry[2]))))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_XGAndHash;
                            if ((c2 - c1) == 2)
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[0]);
                            }
                            return;
                        }
                        cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_3_Hash;
                        MahjongGeneralAlgorithm.SortCardByWeightValue(cardWrapper.cardData);
                        return;

                    }
                case 4://杠，两对，一对+相邻，一对+相隔，一对+两散，刻+散，顺+散，散
                    {
                        byte c1 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[0]);
                        byte c2 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[1]);
                        byte c3 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[2]);
                        byte c4 = MahjongGeneralAlgorithm.GetMahjongLogicValue(cardAry[3]);

                        //杠
                        if (c1 == c4)
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_Gang;
                            return;
                        }
                        //两对
                        if ((c1 == c2) && (c3 == c4))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_TwoPair;
                            if ((MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1])) > (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2])))
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[3]);
                                cardWrapper.cardData.Add(cardAry[0]);
                                cardWrapper.cardData.Add(cardAry[1]);
                            }

                            return;
                        }
                        //一对+相邻
                        if (((c1 == c2) && ((c4 - c3) == 1)) || ((c3 == c4) && ((c2 - c1) == 1)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_PairAndXL;

                            if (((MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0])) + (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))) > ((MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2])) + (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))))
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[3]);
                                cardWrapper.cardData.Add(cardAry[0]);
                                cardWrapper.cardData.Add(cardAry[1]);
                            }
                            return;
                        }
                        //一对+相隔
                        if (((c1 == c2) && ((c4 - c3) == 2)) || ((c3 == c4) && ((c2 - c1) == 2)) || ((c2 == c3) && ((c4 - c1) == 2)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_PairAndXG;

                            if ((c1 == c2) && ((c4 - c3) == 2))
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                cardWrapper.cardData.Add(cardAry[0]);
                                cardWrapper.cardData.Add(cardAry[1]);
                            }
                            else if ((c3 == c4) && ((c2 - c1) == 2))
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[3]);
                            }
                            else
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[2]);
                            }

                            return;
                        }
                        //一对+两散
                        if (((c1 == c2) && ((c4 - c3) > 2)) || ((c3 == c4) && ((c2 - c1) > 2)) || ((c2 == c3) && ((c4 - c1) > 2)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_PairAndTwoHash;
                            if ((c1 == c2) && ((c4 - c3) == 2))
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                cardWrapper.cardData.Add(cardAry[0]);
                                cardWrapper.cardData.Add(cardAry[1]);
                            }
                            else if ((c3 == c4) && ((c2 - c1) == 2))
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[3]);
                            }
                            else
                            {
                                cardWrapper.cardData.Clear();

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[2]);
                            }

                            return;
                        }
                        //刻+散
                        if ((c1 == c3) || (c2 == c4))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_EchoAndHash;

                            if (c1 == c3)
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[3]);
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[2]);
                                cardWrapper.cardData.Add(cardAry[0]);
                            }
                            return;
                        }

                        //四张顺
                        if (((c4 - c3) == 1) && ((c3 - c2) == 1) && ((c2 - c1) == 1))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_Flash;
                            MahjongGeneralAlgorithm.SortCardByWeightValue(cardWrapper.cardData);
                            return;
                        }

                        //顺+散
                        if ((((c3 - c2) == 1) && ((c2 - c1) == 1)) || (((c4 - c3) == 1) && ((c3 - c2) == 1)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_FashAndHash;

                            if (((c3 - c2) == 1) && ((c2 - c1) == 1))//前三张一面
                            {
                                cardWrapper.cardData.Clear();
                                cardWrapper.cardData.Add(cardAry[3]);
                                cardWrapper.cardData.Add(cardAry[0]);
                                cardWrapper.cardData.Add(cardAry[1]);
                                cardWrapper.cardData.Add(cardAry[2]);
                            }
                            return;
                        }

                        //两个相邻
                        if (((c2 - c1) == 1) && ((c4 - c3) == 1))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_TwoXL;

                            cardWrapper.cardData.Clear();

                            if ((MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) + MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1])) > (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) + cardAry[3]))
                            {
                                //后两张在前面，前两张在后面
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);

                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                            }
                            else
                            {
                                //前两张在前面，后两张在后面
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }
                            }

                            return;
                        }

                        //两个相隔
                        if ((c2 - c1 == 2) && (c4 - c3 == 2) && (c3 - c2 > 1))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_TwoXG;

                            cardWrapper.cardData.Clear();

                            if ((MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) + MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1])) > (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) + cardAry[3]))
                            {
                                //后两张在前面，前两张在后面
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                            }
                            else
                            {
                                //前两张在前面，后两张在后面
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }
                            }

                            return;
                        }

                        //一个相隔，一个相邻
                        if ((((c2 - c1) == 2) && ((c4 - c3) == 1)) || (((c2 - c1) == 1) && ((c4 - c3) == 2)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_XLAndXG;
                            cardWrapper.cardData.Clear();

                            if (((c2 - c1) == 2) && ((c4 - c3) == 1))//前两个相隔，后两个相邻
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }
                            }
                            else//前两个相邻，后两个相隔
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                            }
                            return;
                        }

                        //一个相邻+两个散牌
                        if ((((c2 - c1) == 1) && ((c4 - c3) > 2)) || (((c4 - c3) == 1) && ((c2 - c1) > 2)) || (((c3 - c2) == 1) && ((c4 - c1) > 2)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_XLAndTwoHash;
                            cardWrapper.cardData.Clear();

                            if (((c2 - c1) == 1) && ((c4 - c3) > 2))//前两个相邻，后两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                            }
                            else if (((c4 - c3) == 1) && ((c2 - c1) > 2))//后两个相邻，前两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }
                            }
                            else//中间两个相邻，前后两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]))
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                            }
                            return;
                        }
                        //一个相隔+两个散牌
                        if ((((c2 - c1) == 2) && ((c4 - c3) > 2)) || (((c4 - c3) == 2) && ((c2 - c1) > 2)) || (((c3 - c2) == 2) && ((c4 - c1) > 2)))
                        {
                            cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_4_XGAndTwoHash;
                            cardWrapper.cardData.Clear();

                            if (((c2 - c1) == 2) && ((c4 - c3) > 2))//前两个相邻，后两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                            }
                            else if (((c4 - c3) == 2) && ((c2 - c1) > 2))//后两个相邻，前两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }
                            }
                            else//中间两个相邻，前后两个散牌
                            {
                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[0]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[3]))//前两张再进行比较
                                {
                                    cardWrapper.cardData.Add(cardAry[3]);
                                    cardWrapper.cardData.Add(cardAry[0]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[0]);
                                    cardWrapper.cardData.Add(cardAry[3]);
                                }

                                if (MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[1]) > MahjongGeneralAlgorithm.GetSingleCardWeightValue(cardAry[2]))
                                {
                                    cardWrapper.cardData.Add(cardAry[2]);
                                    cardWrapper.cardData.Add(cardAry[1]);
                                }
                                else
                                {
                                    cardWrapper.cardData.Add(cardAry[1]);
                                    cardWrapper.cardData.Add(cardAry[2]);
                                }
                            }
                            return;
                        }
                        //未知牌型
                        cardWrapper.cardWrapperType = enCardWrapperType.CardWrapperType_UnKnown;
                        MahjongGeneralAlgorithm.SortCardByWeightValue(cardWrapper.cardData);

                        return;

                    }
            }
        }

        #endregion

        #region 听牌、胡牌、取孤张

        /// <summary>
        /// 取孤张,此方法只将牌阵的相对孤张取出来
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vGuCards"></param>
        public static void GetCardListGuCards(List<byte> srcAry, List<byte> vGuCards, bool checkPair = false)
        {
            List<byte> vSrc = new List<byte>(srcAry);
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            vGuCards.Clear();
            if (vSrc.Count == 0)
            {
                return;
            }

            //1、分拣牌
            List<byte> vFigureCard = new List<byte>();//普通牌
            List<byte> vZhiCard = new List<byte>();//字牌
            //牌归牌，字牌归字牌
            for (short i = 0; i < vSrc.Count; i++)
            {
                switch (GetMahjongColor(vSrc[i]))
                {
                    case MahjongDef.gMahjongColor_Wan:	//万
                    case MahjongDef.gMahjongColor_Tong:	//筒
                    case MahjongDef.gMahjongColor_Tiao:	//条
                        {
                            vFigureCard.Add(vSrc[i]);
                            break;
                        }
                    case MahjongDef.gMahjongColor_Zhi:	//字
                        {
                            vZhiCard.Add(vSrc[i]);
                            break;
                        }
                }
            }

            //3、对各个花色牌取孤张
            List<byte> vFigureGuCard = new List<byte>();
            List<byte> vZhiGuCard = new List<byte>();

            if (vFigureCard.Count > 0)
            {
                //对一个单一花色的牌阵进行去顺去刻
                RemoveEchoAndFlashForCardList(vFigureCard, vFigureGuCard, true);
            }
            if (vZhiCard.Count > 0)
            {
                //对一个单一花色的牌阵进行去顺去刻
                RemoveEchoAndFlashForCardList(vZhiCard, vZhiGuCard, false);
            }

            if (checkPair && (vFigureGuCard.Count > 0))
            {
                List<byte> gang = new List<byte>();
                List<byte> echo = new List<byte>();
                List<byte> pair = new List<byte>();
                List<byte> hash = new List<byte>();
                SpiltHandCardToGEPH(vFigureGuCard, gang, echo, pair, hash);
                if (hash.Count > 0)
                {
                    for (int i = 0; i < hash.Count; i++)
                    {
                        if (srcAry.FindAll(delegate(byte checkCard) { return checkCard == hash[i]; }).Count == 2)
                        {
                            vFigureGuCard.Add(hash[i]);
                        }
                    }
                }
            }

            //4、合并各个花色牌的孤张，做为本次的孤张集返回
            vGuCards.AddRange(vFigureGuCard);
            vGuCards.AddRange(vZhiGuCard);
        }

        /// <summary>
        /// 检查指定牌阵能否听牌
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vectorTingCard"></param>
        /// <returns></returns>
        public static bool CheckIfCanTingCardArray(List<byte> srcAry, List<byte> vectorTingCard = null)
        {
            if (null != vectorTingCard)
            {
                vectorTingCard.Clear();
            }

            List<byte> vSrc = new List<byte>(srcAry);
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            //扑克复制
            List<byte> vTingSpecial = new List<byte>();
            List<byte> vTingNormal = new List<byte>();
            bool bTing = false;

            //1、判断是否特殊听牌
            if (CheckIfCanSpecialTing(vSrc))
            {
                bTing = true;
                if (null != vectorTingCard)
                {
                    //获取特殊听牌
                    vTingSpecial.Clear();
                    //获取特殊所听之牌
                    GetSpecialTingCard(vSrc, ref vTingSpecial);
                }
                else
                {
                    return true;
                }
            }

            //2、判断是否普通听牌
            if (CheckIfCanNormalTing(vSrc))
            {
                bTing = true;
                if (null != vectorTingCard)
                {
                    //获取普通听牌
                    vTingNormal.Clear();
                    //获取普通所听之牌
                    GetNormalTingCard(vSrc, ref vTingNormal);
                }
                else
                {
                    return true;
                }
            }
            if (null == vectorTingCard)
            {
                return bTing;
            }
            if ((vTingSpecial.Count == 0) && (vTingNormal.Count == 0))
            {
                return false;
            }
            //合并两个听牌集并剔除重复
            //合并两个听牌集
            vTingNormal = MergeVector(vTingNormal, vTingSpecial);
            //去除重复项
            vTingNormal = RemoveRepeat(vTingNormal);

            vectorTingCard.AddRange(vTingNormal);

            return vectorTingCard.Count > 0;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region 特殊听牌

        //是否特殊听牌
        public static bool CheckIfCanSpecialTing(List<byte> vSrc)
        {
            //听七对或是国士无双(十三幺)
            if (CheckIfTingSevenPair(vSrc))
            {
                return false;
            }
            return false;
        }

        //检查特殊听牌牌型：七对子，二色二顺
        private static bool CheckIfTingSevenPair(List<byte> vSrc)
        {
            return false;
            ////1、七对子必须门清，即13张牌
            //if (vSrc.Count != 13)
            //{
            //    return false;
            //}
            //七对子
            short wPairCount = 0;
            vSrc.Sort();

            byte cHashCard = 0;

            for (int i = 0; i < vSrc.Count - 1; i++)
            {
                if (vSrc[i] == vSrc[i + 1])
                {
                    i += 1;
                    wPairCount++;
                    continue;
                }
                else
                {
                    cHashCard = vSrc[i];
                }
            }
            if (wPairCount < 6)
            {
                return false;
            }

            List<byte> activeCard = new List<byte>(vSrc);
            activeCard.Add(cHashCard);
            activeCard.Sort();

            //1、排除二色二顺情况
            //112233,6677888
            List<byte> vCheckCard = new List<byte>();
            for (int i = 0; i < 7; i++)
            {
                vCheckCard.Add(activeCard[i * 2]);
            }
            List<byte> vFlash = new List<byte>();
            for (int i = 0; i < 7 - 2; i++)
            {
                if (((vCheckCard[i + 1] - vCheckCard[i]) == 1) && ((vCheckCard[i + 2] - vCheckCard[i + 1]) == 1))
                {
                    vFlash.Add(vCheckCard[i]);
                    i += 2;
                    continue;
                }
            }
            if (vFlash.Count == 2)
            {
                if (vFlash[0] != vFlash[1])
                {
                    return false;
                }
            }

            //2、排除三连杠情况
            //333,4444,5555,99
            List<byte> vEcho = new List<byte>();
            for (int i = 0; i < activeCard.Count - 2; i++)
            {
                if ((activeCard[i] == activeCard[i + 1]) && (activeCard[i] == activeCard[i + 2]))
                {
                    vEcho.Add(activeCard[i]);
                    i += 2;
                    continue;
                }
            }
            if (vEcho.Count == 3)
            {
                vEcho.Sort();
                if (((vEcho[1] - vEcho[0]) == 1) && ((vEcho[2] - vEcho[1]) == 1))
                {
                    return false;
                }
            }

            return wPairCount == 6;
        }




        //获取特殊所听牌之牌
        public static void GetSpecialTingCard(List<byte> vSrc, ref List<byte> vectorTingCard)
        {
            //1、七对子
            vectorTingCard.Clear();

            if (CheckIfTingSevenPair(vSrc))
            {
                //获取七对子所听之牌
                vectorTingCard.Clear();
                //七对子
                for (int i = 0; i < vSrc.Count - 1; i++)
                {
                    if (vSrc[i] == vSrc[i + 1])
                    {
                        i += 1;
                        continue;
                    }
                    else
                    {
                        vectorTingCard.Add(vSrc[i]);
                        return;
                    }
                }
                if (vectorTingCard.Count == 0)
                {
                    vectorTingCard.Add(vSrc[vSrc.Count - 1]);
                }
                return;
            }

            //2、十三烂
            //if (CheckIfTingShiSanLan(vSrc))
            //{
            //    //十三烂必须是门清
            //    if (13 != vSrc.Count)
            //    {
            //        return;
            //    }

            //    //字集合
            //    byte[] allZhi = new byte[7]
            //    {
            //        0x31,0x32,0x33,0x34,0x35,0x36,0x37
            //    };

            //    List<byte> handCard = new List<byte>();
            //    handCard.AddRange(vSrc);

            //    //1、先将玩家的牌分开
            //    List<byte> vWanCard = new List<byte>();
            //    List<byte> vTongCard = new List<byte>();
            //    List<byte> vTiaoCard = new List<byte>();
            //    List<byte> vZhiCard = new List<byte>();

            //    SpiltHandCardByCardColor(handCard, vWanCard, vTongCard, vTiaoCard, vZhiCard);

            //    //添加听字的牌
            //    if (vZhiCard.Count < 5)
            //    {
            //        for (int i = 0; i < 7; i++)
            //        {
            //            if (!vZhiCard.Contains(allZhi[i]))
            //            {
            //                vectorTingCard.Add(allZhi[i]);
            //            }
            //        }
            //    }

            //    //添加听万的牌
            //    if (vWanCard.Count == 2)
            //    {
            //        vectorTingCard.Add(getWanTongTiaoTing(vWanCard));
            //    }

            //    //添加听筒的牌
            //    if (vTongCard.Count == 2)
            //    {
            //        vectorTingCard.Add(getWanTongTiaoTing(vTongCard));
            //    }

            //    //添加听条的牌
            //    if (vTiaoCard.Count == 2)
            //    {
            //        vectorTingCard.Add(getWanTongTiaoTing(vTiaoCard));
            //    }
            //    return;
            //}
        }

        #endregion

        #region 普通听牌

        /// <summary>
        /// 分拣出一副牌阵中的所有成顺的牌
        /// </summary>
        /// <param name="src"></param>
        /// <param name="resultCardAry"></param>
        private static List<byte> SpiltFlashCard(List<byte> src)
        {
            if (src.Count < 3)
            {
                return null;
            }
            List<byte> cardAry = new List<byte>();
            cardAry.AddRange(src);

            List<byte> card_wan = new List<byte>();
            List<byte> card_tong = new List<byte>();
            List<byte> card_tiao = new List<byte>();
            List<byte> card_zhi = new List<byte>();

            SpiltHandCardByCardColor(cardAry, card_wan, card_tong, card_tiao, card_zhi);

            List<byte> flash_wan = new List<byte>();
            List<byte> flash_tong = new List<byte>();
            List<byte> flash_tiao = new List<byte>();

            if (card_wan.Count > 2)
            {
                SpiltFlashCardBySameColorCard(card_wan, flash_wan);
            }
            if (card_tong.Count > 2)
            {
                SpiltFlashCardBySameColorCard(card_tong, flash_tong);
            }
            if (card_tiao.Count > 2)
            {
                SpiltFlashCardBySameColorCard(card_tiao, flash_tiao);
            }

            List<byte> temp = new List<byte>();

            temp.AddRange(flash_wan);
            temp.AddRange(flash_tong);
            temp.AddRange(flash_tiao);

            return temp.Distinct().ToList();
        }

        /// <summary>
        /// 分拣出同一花色牌中的所有成顺的牌
        /// </summary>
        /// <param name="src"></param>
        /// <param name="resultCardAry"></param>
        private static void SpiltFlashCardBySameColorCard(List<byte> src, List<byte> resultCardAry)
        {
            resultCardAry.Clear();
            if (src.Count < 3)
            {
                return;
            }
            src.Sort();

            int idx1 = 0;
            int idx2 = 0;

            for (int i = 0; i < src.Count; i++)
            {
                idx1 = src.FindIndex(0, delegate(byte checkCard) { return (checkCard == (src[i] + 1)); });
                if (-1 != idx1)
                {
                    idx2 = src.FindIndex(0, delegate(byte checkCard) { return (checkCard == (src[i] + 2)); });
                    if (-1 != idx2)
                    {
                        //搜到顺了
                        resultCardAry.Add(src[i]);
                        resultCardAry.Add((byte)(src[i] + 1));
                        resultCardAry.Add((byte)(src[i] + 2));
                    }
                }
            }
        }

        //是否普通听牌
        public static bool CheckIfCanNormalTing(List<byte> vSrc)
        {
            vSrc.Sort();

            //1、按花色分拣牌
            List<byte> vectorWan = new List<byte>();
            List<byte> vectorTong = new List<byte>();
            List<byte> vectorTiao = new List<byte>();
            List<byte> vectorZhi = new List<byte>();
            SpiltHandCardByCardColor(vSrc, vectorWan, vectorTong, vectorTiao, vectorZhi);

            //2、得到各个花色牌的听牌类型
            short wWanTinType = (short)GetFigureCardTinType(vectorWan);
            short wTongTinType = (short)GetFigureCardTinType(vectorTong);
            short wTiaoTinType = (short)GetFigureCardTinType(vectorTiao);
            short wshortTinType = (short)GetCharFigureCardTinType(vectorZhi);


            //3、组合判断
            int wTinType = wWanTinType * wTongTinType * wTiaoTinType * wshortTinType;

            //有一个是Nothing，就不能听牌
            if (wTinType == 0)
            {
                return false;
            }

            //听牌只有两种可能
            /*
            1、一个四模式(TinType_OtherTriple = 7),其他均为3模式(TinType_Tirple = 1,)

            2、两个2模式(只要不都为TinType_NeedPair),其他均为3模式(TinType_Tirple = 1,)
            */
            if (wTinType == 7)
            {
                return true;
            }

            if ((wTinType == 25) || (wTinType == 10) || (wTinType == 15) || (wTinType == 4) || (wTinType == 6))
            {
                return true;
            }

            if (wTinType % 9 == 0)//NeedPair = 3,两个2模式都为NeedPair
            {
                return false;
            }

            return false;
        }

        //获取一个牌阵所听之牌
        public static void GetNormalTingCard(List<byte> vSrc, ref List<byte> vectorTingCard)
        {
            vectorTingCard.Clear();
            //1、按花色分拣牌
            //先排序
            vSrc.Sort();

            //再分拣

            //如果听牌,只可能两种情况:
            //1,必有一个四模式,其他都是成组的3模式
            //2,两个2模式,其他都是成组的3模式

            List<byte> vectorWan = new List<byte>();
            List<byte> vectorTong = new List<byte>();
            List<byte> vectorTiao = new List<byte>();
            List<byte> vectorZhi = new List<byte>();
            SpiltHandCardByCardColor(vSrc, vectorWan, vectorTong, vectorTiao, vectorZhi);

            ///判断1模式
            if (vectorZhi.Count % 3 == 1)
            {
                vectorZhi.Sort();
                Get1ModelTinCards(vectorZhi, ref vectorTingCard);
                return;
            }
            if (vectorWan.Count % 3 == 1)
            {
                vectorWan.Sort();
                Get1ModelTinCards(vectorWan, ref vectorTingCard);
                return;
            }
            if (vectorTong.Count % 3 == 1)
            {
                vectorTong.Sort();
                Get1ModelTinCards(vectorTong, ref vectorTingCard);
                return;
            }
            if (vectorTiao.Count % 3 == 1)
            {
                vectorTiao.Sort();
                Get1ModelTinCards(vectorTiao, ref vectorTingCard);
                return;
            }

            ///判断2模式(组合:1,字,万;2,字,筒;3,字,条;4,条,万;5,条,筒;6,筒,万;)

            if ((vectorZhi.Count % 3 == 2) && (vectorWan.Count % 3 == 2))//1、字,万
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorZhi, vectorWan);
                return;
            }

            if ((vectorZhi.Count % 3 == 2) && (vectorTong.Count % 3 == 2))//2、字,筒
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorZhi, vectorTong);
                return;
            }

            if ((vectorZhi.Count % 3 == 2) && (vectorTiao.Count % 3 == 2))//3、字,条
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorZhi, vectorTiao);
                return;
            }

            if ((vectorTiao.Count % 3 == 2) && (vectorWan.Count % 3 == 2))//4、条,万
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorTiao, vectorWan);
                return;
            }

            if ((vectorTiao.Count % 3 == 2) && (vectorTong.Count % 3 == 2))//5、条,筒
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorTiao, vectorTong);
                return;
            }

            if ((vectorTong.Count % 3 == 2) && (vectorWan.Count % 3 == 2))//6、筒,万
            {
                vectorTingCard = GetTwo2ModelTinCards(vectorTong, vectorWan);
                return;
            }
        }

        //得到两个2模式的所有听的牌,
        public static List<byte> GetTwo2ModelTinCards(List<byte> vectorCard1, List<byte> vectorCard2)
        {
            List<byte> vResult = new List<byte>();
            vResult.Clear();

            if (((vectorCard1.Count % 3) != 2) || ((vectorCard2.Count % 3) != 2)) //此牌阵非二模式
                return vResult;

            //牌阵一排序
            vectorCard1.Sort();
            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard1[0]) != MahjongGeneralAlgorithm.GetMahjongColor(vectorCard1[vectorCard1.Count - 1]))
                return vResult;

            //牌阵二排序
            vectorCard2.Sort();
            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard2[0]) != MahjongGeneralAlgorithm.GetMahjongColor(vectorCard2[vectorCard2.Count - 1]))
                return vResult;

            enTinType checkOutTinType1;///第一个2模式的听牌类型

            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard1[0]) < MahjongDef.gMahjongColor_Zhi)//万,筒,条
            {
                checkOutTinType1 = GetFigureCardTinType(vectorCard1);
            }
            else
            {
                checkOutTinType1 = GetCharFigureCardTinType(vectorCard1);
            }

            enTinType checkOutTinType2;///第二个2模式的听牌类型

            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard2[0]) < MahjongDef.gMahjongColor_Zhi)//万,筒,条
            {
                checkOutTinType2 = GetFigureCardTinType(vectorCard2);
            }
            else
            {
                checkOutTinType2 = GetCharFigureCardTinType(vectorCard2);
            }

            if ((checkOutTinType1 == enTinType.TinType_Nothing) || (checkOutTinType2 == enTinType.TinType_Nothing))
                return vResult;

            if ((checkOutTinType1 == enTinType.TinType_NeedPair) && (checkOutTinType2 == enTinType.TinType_NeedPair))
                return vResult;//不能都为NeedPair

            //1,两个中有一个为NeedPair,返回为NeedPair的听牌集
            if (checkOutTinType1 == enTinType.TinType_NeedPair)
                return Get2ModelTinCards(vectorCard1);
            if (checkOutTinType2 == enTinType.TinType_NeedPair)
                return Get2ModelTinCards(vectorCard2);

            /*******************************************************************************************
            * 2个2模式(A,B)之间的关系:
            * 
            * 1,消除NeedPair: 如果前一个2模式A为NeedPair,另一个2模式B为(FreePair,或者HavePair),结果为A的Round
            * 2,如果前一个2模式A为HavePair,另一个2模式B为(FreePair,或者HavePair),结果为A的Pair加B的Round和Pair
            * 3,如果前一个2模式A为FreePair,另一个2模式B为(FreePair,或者HavePair),结果为A的Pair加B的Round和Pair
            * ********************************************************************************************/

            //其他的情况将card2List1和card2List2听牌集合并返回即可
            //因为,HavePair的听牌集只可能为Pair,而FreePair的听牌集也只能够为Round

            return MergeVector(Get2ModelTinCards(vectorCard1), Get2ModelTinCards(vectorCard2));
        }

        //得到一个2模式的听牌集
        public static List<byte> Get2ModelTinCards(List<byte> vectorCard)
        {
            List<byte> vResult = new List<byte>();
            vResult.Clear();

            if ((vectorCard.Count % 3) != 2)
                return vResult;

            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard[0]) != MahjongGeneralAlgorithm.GetMahjongColor(vectorCard[vectorCard.Count - 1])) //此牌阵不为同一种花色牌
                return vResult;

            if (MahjongGeneralAlgorithm.GetMahjongColor(vectorCard[0]) < MahjongDef.gMahjongColor_Zhi)//万,筒,条
            {
                //2张
                if (vectorCard.Count == 2)
                {
                    //如果为HavePair(例:22,返回2),如果是NeedPair(例:23,返回14)
                    //不用担心,在递归去串过程中,不会将HavePair和NeedPair混淆.
                    List<byte> results = GetTwoCardsRound(vectorCard[0], vectorCard[1]);
                    return results;
                }

                List<byte> finalResults = new List<byte>();//结果集

                //(调用去顺,再递归)
                List<List<byte>> remLists = new List<List<byte>>();
                //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
                GetFigureCardListByRemoveTriple(ref vectorCard, ref remLists);

                if (remLists.Count == 0)
                    return vResult;
                for (int i = 0; i < remLists.Count; i++)
                {
                    //合并所有听牌集
                    List<byte> subResults = Get2ModelTinCards(remLists[i]);
                    finalResults = MergeVector(finalResults, subResults);
                }
                return finalResults;
            }
            else//字牌
            {
                //2张
                if (vectorCard.Count == 2)
                {
                    List<byte> results = new List<byte>();
                    if (vectorCard[0] == vectorCard[1])
                        results.Add(vectorCard[0]);

                    return results;
                }
                List<byte> finalResults = new List<byte>();//结果集

                //(调用去顺,再递归)
                List<List<byte>> remLists = new List<List<byte>>();
                GetCharCardsListsByRemoveTriple(vectorCard, remLists);

                if (remLists.Count == 0)
                    return vResult;

                for (int i = 0; i < remLists.Count; i++)
                {
                    //合并所有听牌集
                    List<byte> subResults = Get2ModelTinCards(remLists[i]);
                    finalResults = MergeVector(finalResults, subResults);
                }
                return finalResults;
            }
            return vResult;
        }

        //得到两个牌(两张牌必须为同一类型花色,且不为字牌)能够成为一个Triple的关联牌集
        public static List<byte> GetTwoCardsRound(byte card1, byte card2)
        {
            List<byte> list = new List<byte>();
            //花色不一，不能进行
            if (MahjongGeneralAlgorithm.GetMahjongColor(card1) != MahjongGeneralAlgorithm.GetMahjongColor(card2))
            {
                return list;
            }


            //排序,确保card2>card1
            if (card1 > card2)
            {
                byte change = card1;
                card1 = card2;
                card2 = change;
            }

            byte cTemp1 = (byte)MahjongGeneralAlgorithm.GetMahjongValue(card1);
            byte cTemp2 = (byte)MahjongGeneralAlgorithm.GetMahjongValue(card2);

            if (card2 == card1)
            {
                list.Add(card1);
                return list;
            }

            if ((card2 - card1) == 2)
            {
                list.Add((byte)((card2 + card1) / 2));
                return list;
            }

            if ((card2 - card1) == 1)//(例:89,56,12)合肥麻将无19
            {
                if (cTemp2 == 9)
                    list.Add((byte)(card1 - 1));
                else
                {
                    if (cTemp1 == 1)
                        list.Add((byte)(card2 + 1));
                    else
                    {
                        list.Add((byte)(card1 - 1));
                        list.Add((byte)(card2 + 1));
                    }
                }
                return list;
            }

            return list;
        }

        //获取一个1模式的所有听牌集合，必须为单花色且排序好的牌
        public static void Get1ModelTinCards(List<byte> cardVector, ref List<byte> vectorTingCard)
        {
            //数据初始化
            vectorTingCard.Clear();
            if ((cardVector.Count % 3) != 1)
                return;

            //排序
            cardVector.Sort();

            if (MahjongGeneralAlgorithm.GetMahjongColor(cardVector[0]) < MahjongDef.gMahjongColor_Zhi)//万,筒,条
            {
                //1张
                if (cardVector.Count == 1)
                {
                    vectorTingCard.Add(cardVector[0]);
                    return;
                }

                //4张
                if (cardVector.Count == 4)
                {
                    if (cardVector[0] == cardVector[3])//为4个头,返回null
                        return;

                    if (cardVector[2] == cardVector[0])///前三张为一刻
                    {
                        List<byte> results = new List<byte>();///结果集
                        results.Add(cardVector[3]);

                        List<byte> round = GetTwoCardsRound(cardVector[2], cardVector[3]);

                        vectorTingCard = MergeVector(results, round);
                        //排序
                        vectorTingCard.Sort();
                        return;
                    }
                    if (cardVector[3] == cardVector[1])///后三张为一刻
                    {
                        List<byte> results = new List<byte>();///结果集
                        results.Add(cardVector[0]);
                        List<byte> round = GetTwoCardsRound(cardVector[0], cardVector[1]);
                        vectorTingCard = MergeVector(results, round);
                        //排序
                        vectorTingCard.Sort();
                        return;
                    }
                    //两对
                    if (((cardVector[1] == cardVector[0])) && ((cardVector[3] == cardVector[2])))
                    {
                        vectorTingCard.Add(cardVector[0]);
                        vectorTingCard.Add(cardVector[3]);
                        return;
                    }
                    if ((cardVector[1] - cardVector[0]) == 0)///前两张为一对
                    {
                        vectorTingCard = GetTwoCardsRound(cardVector[2], cardVector[3]);
                        return;
                    }
                    if ((cardVector[2] - cardVector[1]) == 0)///中间两张为一对
                    {
                        vectorTingCard = GetTwoCardsRound(cardVector[0], cardVector[3]);
                        return;
                    }
                    if ((cardVector[3] - cardVector[2]) == 0)///后两张为一对
                    {
                        vectorTingCard = GetTwoCardsRound(cardVector[0], cardVector[1]);
                        return;
                    }
                    //单张
                    if ((cardVector[2] - cardVector[1]) > 1)///四张单张的中间两张不连张
                        return;
                    else
                    {
                        if ((cardVector[3] - cardVector[2]) == 1)//(例:2456)
                            vectorTingCard.Add(cardVector[0]);

                        if ((cardVector[1] - cardVector[0]) == 1)//(例:3457)
                            vectorTingCard.Add(cardVector[3]);
                        return;
                    }
                }

                //7,10,13递归
                //Vector_Byte finalResults;///结果集
                //(调用去顺,再递归)
                List<List<byte>> remLists = new List<List<byte>>();
                //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
                GetFigureCardListByRemoveTriple(ref cardVector, ref remLists);
                if (remLists.Count == 0)
                    return;

                for (int i = 0; i < remLists.Count; i++)
                {
                    ///合并所有听牌集
                    List<byte> subResults = new List<byte>();
                    Get1ModelTinCards(remLists[i], ref subResults);
                    vectorTingCard = MergeVector(vectorTingCard, subResults);
                }
                return;
            }
            else//字牌
            {
                //1张
                if (cardVector.Count == 1)
                {
                    vectorTingCard.Add(cardVector[0]);
                    return;
                }
                //4张
                if (cardVector.Count == 4)
                {
                    if (cardVector[0] == cardVector[3])//为4个头,返回null
                        return;
                    if (cardVector[2] == cardVector[0])///前三张为一刻
                    {
                        vectorTingCard.Add(cardVector[3]);
                        return;
                    }
                    if (cardVector[3] == cardVector[1])///后三张为一刻
                    {
                        vectorTingCard.Add(cardVector[0]);
                        return;
                    }
                    if (((cardVector[1] == cardVector[0])) && ((cardVector[3] == cardVector[2])))///字牌必为两对
                    {
                        vectorTingCard.Add(cardVector[0]);
                        vectorTingCard.Add(cardVector[3]);
                        return;
                    }
                }
                //7,10,13张
                //(调用去顺,再递归)
                List<List<byte>> remLists = new List<List<byte>>();
                GetCharCardsListsByRemoveTriple(cardVector, remLists);

                if (remLists.Count == 0)
                    return;

                for (int i = 0; i < remLists.Count; i++)
                {
                    ///合并所有听牌集
                    List<byte> subResults = new List<byte>();
                    Get1ModelTinCards(remLists[i], ref subResults);
                    vectorTingCard = MergeVector(vectorTingCard, subResults);
                }
                return;
            }
        }

        //对一个单一花色的牌阵进行去顺去刻
        public static void RemoveEchoAndFlashForCardList(List<byte> vSingleColorCardList, List<byte> vGu, bool bIsNumCard)
        {
            vGu.Clear();
            //1、长度小于3时，不需要去顺去刻
            if (vSingleColorCardList.Count < 3)
            {
                //容器间的数据复制，将后者的数据复制到前者
                vGu.AddRange(vSingleColorCardList);
                return;
            }
            //2、长度大于等于3
            List<List<byte>> vEchoOrFlash1 = new List<List<byte>>();
            //搜各种可能的顺或者刻
            SearchEchoOrFlash(vSingleColorCardList, vEchoOrFlash1);
            //排序
            //vEchoOrFlash1.Sort();
            //去重复
            List<List<byte>> vEchoOrFlash = vEchoOrFlash1.Distinct().ToList();
            //3、如果未搜到任何顺或者刻,则都是孤张,就将原始串返回
            if (vEchoOrFlash.Count == 0)
            {
                vGu.AddRange(vSingleColorCardList);
                return;
            }

            //4、搜到顺或者刻了，将所有的顺或者刻出现的牌从原始牌阵中删除，剩下的全部返回
            List<byte> tokenCardList = new List<byte>();
            for (short i = 0; i < vSingleColorCardList.Count; i++)
            {
                if (MahjongDef.gInvalidMahjongValue != vSingleColorCardList[i])
                {
                    tokenCardList.Add(vSingleColorCardList[i]);
                }
            }
            for (short i = 0; i < vEchoOrFlash.Count; i++)
            {
                if (vEchoOrFlash[i].Count > 0)
                {
                    for (short j = 0; j < vEchoOrFlash[i].Count; j++)
                    {
                        tokenCardList.Remove(vEchoOrFlash[i][j]);
                    }
                }
            }

            /*
            排除以下两种情况：
            11234,将1列为孤张
            34566,将6列为孤张
            */
            if (vSingleColorCardList.Count > 4)
            {
                byte c1 = MahjongDef.gInvalidMahjongValue;
                byte c2 = MahjongDef.gInvalidMahjongValue;
                byte c3 = MahjongDef.gInvalidMahjongValue;
                byte c4 = MahjongDef.gInvalidMahjongValue;
                byte c5 = MahjongDef.gInvalidMahjongValue;
                vSingleColorCardList.Sort();
                for (short i = 0; i < vSingleColorCardList.Count - 4; i++)
                {
                    if (MahjongGeneralAlgorithm.GetMahjongColor(vSingleColorCardList[i]) == MahjongDef.gMahjongColor_Zhi)
                    {
                        continue;
                    }
                    c1 = vSingleColorCardList[i];
                    c2 = vSingleColorCardList[i + 1];
                    c3 = vSingleColorCardList[i + 2];
                    c4 = vSingleColorCardList[i + 3];
                    c5 = vSingleColorCardList[i + 4];
                    //22345
                    if ((c1 == c2) && ((c2 + 1) == c3) && ((c3 + 1) == c4) && ((c4 + 1) == c5))
                    {
                        tokenCardList.Remove(c1);
                        i += 1;
                        continue;
                    }
                    //34566
                    if (((c1 + 1) == c2) && ((c2 + 1) == c3) && ((c3 + 1) == c4) && (c4 == c5))
                    {
                        tokenCardList.Remove(c5);
                        i += 2;
                        continue;
                    }
                }
            }

            vGu.AddRange(tokenCardList);
        }

        //搜各种可能的顺或者刻
        public static void SearchEchoOrFlash(List<byte> vSrc, List<List<byte>> vEchoOrFlash)
        {
            vEchoOrFlash.Clear();
            if (vSrc.Count > 2)
            {
                List<byte> vectorCur = new List<byte>();
                vectorCur.Clear();

                for (short i = 0; i < vSrc.Count - 2; i++)
                {
                    //搜刻
                    if (((vSrc[i] == vSrc[i + 1]) && (vSrc[i] == vSrc[i + 2])))//找到一个刻
                    {
                        //除了这个刻的牌，其他牌全部加入到序列集里
                        List<byte> vectorFind = new List<byte>();
                        vectorFind.Clear();
                        vectorFind.Add(vSrc[i]);
                        vectorFind.Add(vSrc[i + 1]);
                        vectorFind.Add(vSrc[i + 2]);
                        //如果这两个列表元素一样则不做处理
                        if (!IsSame(vectorCur, vectorFind))
                        {
                            vectorCur = vectorFind;
                            vEchoOrFlash.Add(vectorCur);
                        }
                        continue;
                    }
                    //注意字牌不存在顺
                    if (MahjongGeneralAlgorithm.GetMahjongColor(vSrc[i]) == MahjongDef.gMahjongColor_Zhi)
                    {
                        continue;
                    }

                    //搜顺
                    int next1Idx = 0;//顺的第二个索引
                    int next2Idx = 0;//顺的第三个索引
                    //寻找顺
                    for (int k = i + 1; k < vSrc.Count; k++)//(k从i的当前位置+1向后移)
                    {
                        if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vSrc[k]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vSrc[i])) == 1) && (next1Idx == 0))//找到第一个(例:从233456678中根据3找到4)
                            next1Idx = k;
                        if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vSrc[k]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vSrc[i])) == 2) && (next2Idx == 0))//找到第一个(例:从233456678中根据3找到4)
                            next2Idx = k;
                        if ((next1Idx != 0) && (next2Idx != 0))
                            break;
                    }
                    if ((next1Idx != 0) && (next2Idx != 0))///找到顺了
                    {
                        List<byte> remFlashList = new List<byte>();
                        remFlashList.Add(vSrc[i]);
                        remFlashList.Add(vSrc[next1Idx]);
                        remFlashList.Add(vSrc[next2Idx]);
                        ///将得到的列集加入可能的序列集
                        if (!(IsSame(vectorCur, remFlashList)))
                        {
                            vectorCur = remFlashList;
                            vEchoOrFlash.Add(remFlashList);
                        }
                    }
                }
            }

        }

        //判断两个集合是否一样,注：集合元素是byte类型
        public static bool IsSame(List<byte> array1, List<byte> array2)
        {
            if (array1.Count != array2.Count)
            {
                return false;
            }
            for (short i = 0; i < array1.Count; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        //获取一个单色牌的听牌类型,注意：传入的牌阵需要满足以下条件
        public static enTinType GetFigureCardTinType(List<byte> vectorCard)
        {
            //先排序
            vectorCard.Sort();

            //0张
            if (vectorCard.Count == 0)
            {
                return enTinType.TinType_Tirple;
            }

            //1张，单张调头
            if (vectorCard.Count == 1)
            {
                return enTinType.TinType_OtherTriple;
            }

            //2张
            if (vectorCard.Count == 2)
            {
                if (vectorCard[0] == vectorCard[1])//对子
                {
                    return enTinType.TinType_HavePair;
                }
                else
                {
                    if ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[1]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[0])) < 3)//连张
                    {
                        return enTinType.TinType_NeedPair;
                    }
                }
                //不连张
                return enTinType.TinType_Nothing;
            }

            //3张
            if (vectorCard.Count == 3)
            {
                if (vectorCard[0] == vectorCard[2])//一刻
                {
                    return enTinType.TinType_Tirple;
                }
                else
                {
                    if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[2]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[0])) == 2) && ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[2]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[1])) == 1))//一顺
                    {
                        return enTinType.TinType_Tirple;
                    }
                }

                return enTinType.TinType_Nothing;
            }

            //4张
            if (vectorCard.Count == 4)
            {
                if (vectorCard[0] == vectorCard[3])//为一杠，必为不听
                {
                    return enTinType.TinType_Nothing;
                }

                //含刻
                if ((vectorCard[0] == vectorCard[2]) || (vectorCard[1] == vectorCard[3]))
                {
                    return enTinType.TinType_OtherTriple;
                }
                //两对
                if ((vectorCard[0] == vectorCard[1]) && (vectorCard[2] == vectorCard[3]))//两对
                {
                    return enTinType.TinType_OtherTriple;
                }

                //前两张为一对
                if (vectorCard[0] == vectorCard[1])
                {
                    if ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[3]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[2])) < 3)//如果后两张是相邻或是相隔
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                    return enTinType.TinType_Nothing;
                }
                //中间两张为一对
                if (vectorCard[1] == vectorCard[2])
                {
                    if ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[3]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[0])) < 3)
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                    return enTinType.TinType_Nothing;
                }
                //后两张为一对
                if (vectorCard[2] == vectorCard[3])
                {
                    if ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[1]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[0])) < 3)
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                    return enTinType.TinType_Nothing;
                }

                //到这里，整个牌中就不含有对子了，再检查是否含有顺子情况
                if ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[2]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[1])) > 1)//四个散牌的中间两张不紧联，如：34 67
                {
                    return enTinType.TinType_Nothing;
                }

                //到这里，四个散牌的中间两张是紧联的，再看能否与左边或右边的一张凑成顺子
                if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[1]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[0])) < 2) || ((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[3]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorCard[2])) < 2))
                {
                    return enTinType.TinType_OtherTriple;
                }
                return enTinType.TinType_Nothing;
            }

            /*注：
            以下为大数递归,事实上,4张以上可以用递归的方法考察
            其中,6,9,12张就是3模式的递归;7,10,13张就是4模式的递归;5,8,11张就是2模式的递归,(以3取余)
            */

            List<List<byte>> vectorGet = new List<List<byte>>();
            //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
            GetFigureCardListByRemoveTriple(ref vectorCard, ref vectorGet);
            if (vectorGet.Count == 0)
            {
                return enTinType.TinType_Nothing;
            }

            //6，9，12张,可能的牌型为Nothing或Triple
            if (vectorCard.Count % 3 == 0)
            {
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    if (GetFigureCardTinType(vectorGet[i]) == enTinType.TinType_Tirple)
                    {
                        return enTinType.TinType_Tirple;
                    }
                }
                return enTinType.TinType_Nothing;
            }

            //7，10，13张
            if (vectorCard.Count % 3 == 1)
            {
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    if (GetFigureCardTinType(vectorGet[i]) == enTinType.TinType_OtherTriple)
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                }
                return enTinType.TinType_Nothing;
            }

            //5,8,11张
            if (vectorCard.Count % 3 == 2)
            {
                //检查听牌的结果,这里存放枚举值
                List<enTinType> mapCheckResult = new List<enTinType>();

                //将处理后的子序列全部判型一下,取最好的情况
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    enTinType type = GetFigureCardTinType(vectorGet[i]);
                    mapCheckResult.Add(type);
                }
                //优先判断FreePair,例如,345666678解析子项345666时返回FreePair
                if (mapCheckResult.Contains(enTinType.TinType_FreePair))
                    return enTinType.TinType_FreePair;

                //如果此牌阵即可NeedPair又可HavePair,即为FreePair
                if ((mapCheckResult.Contains(enTinType.TinType_NeedPair)) && (mapCheckResult.Contains(enTinType.TinType_HavePair)))
                    return enTinType.TinType_FreePair;

                //如果只是NeedPair或者HavePair
                if (mapCheckResult.Contains(enTinType.TinType_HavePair))
                    return enTinType.TinType_HavePair;

                //剩下只有NeedPair了
                if (mapCheckResult.Contains(enTinType.TinType_NeedPair))
                    return enTinType.TinType_NeedPair;

                ///如果什么也没有
                return enTinType.TinType_Nothing;
            }

            return enTinType.TinType_Unknown;
        }

        //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
        public static void GetFigureCardListByRemoveTriple(ref List<byte> vectorSourceCard, ref List<List<byte>> vectorReturn)
        {
            //初始化一下
            vectorReturn.Clear();

            if (vectorSourceCard.Count < 3)
            {
                return;
            }

            List<byte> vectorCur = new List<byte>();
            vectorCur.Clear();

            for (int i = 0; i < vectorSourceCard.Count - 2; i++)
            {
                //搜刻
                if (((vectorSourceCard[i] == vectorSourceCard[i + 1]) && (vectorSourceCard[i] == vectorSourceCard[i + 2])))//找到一个刻
                {
                    //除了这个刻的牌，其他牌全部加入到序列集里
                    List<byte> vectorFind = new List<byte>();
                    vectorFind.Clear();
                    for (int j = 0; j < vectorSourceCard.Count; j++)
                    {
                        if ((j < i) || (j > (i + 2)))
                        {
                            vectorFind.Add(vectorSourceCard[j]);
                        }
                    }
                    if (!IsSame(vectorCur, vectorFind))
                    {
                        vectorCur = vectorFind;
                        vectorReturn.Add(vectorCur);
                    }
                }

                //搜顺
                int next1Idx = 0;//顺的第二个索引
                int next2Idx = 0;//顺的第三个索引
                for (int k = i + 1; k < vectorSourceCard.Count; k++)//(k从i的当前位置+1向后移)
                {
                    if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorSourceCard[k]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorSourceCard[i])) == 1) && (next1Idx == 0))//找到第一个(例:从233456678中根据3找到4)
                        next1Idx = k;
                    if (((MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorSourceCard[k]) - MahjongGeneralAlgorithm.GetMahjongLogicValue(vectorSourceCard[i])) == 2) && (next2Idx == 0))//找到第一个(例:从233456678中根据3找到4)
                        next2Idx = k;
                    if ((next1Idx != 0) && (next2Idx != 0))
                        break;
                }
                if ((next1Idx != 0) && (next2Idx != 0))///找到顺了
                {
                    //注意字牌不存在顺
                    List<byte> remFlashList = new List<byte>();
                    for (int j = 0; j < vectorSourceCard.Count; j++)//(例:2333577789,)
                    {
                        if ((j != i) && (j != next1Idx) && (j != next2Idx))
                        {
                            remFlashList.Add(vectorSourceCard[j]);
                        }
                    }
                    ///将得到的列集加入可能的序列集
                    if (!(IsSame(vectorCur, remFlashList)))
                    {
                        vectorCur = remFlashList;
                        vectorReturn.Add(remFlashList);
                    }
                }
            }
        }

        //获取字牌的听牌类型,注意：传入的牌阵需要满足以下条件：
        public static enTinType GetCharFigureCardTinType(List<byte> vCard)
        {
            //先排序
            vCard.Sort();

            //==============================================
            //
            //					0~3张
            //
            //==============================================

            ///0张,当一个花色为0张时
            if (vCard.Count == 0)
                return enTinType.TinType_Tirple;
            ///单张调头
            if (vCard.Count == 1)
                return enTinType.TinType_OtherTriple;
            ///2张
            if (vCard.Count == 2)
            {
                if (vCard[0] == vCard[1])//为一对
                    return enTinType.TinType_HavePair;
                else
                    return enTinType.TinType_Nothing;
            }
            ///3张
            if (vCard.Count == 3)
            {
                if ((vCard[0] == vCard[1]) && (vCard[0] == vCard[2]))//为一刻
                    return enTinType.TinType_Tirple;
                else
                    return enTinType.TinType_Nothing;
            }

            //==============================================
            //
            //					4张
            //
            //==============================================

            if (vCard.Count == 4)
            {
                if (vCard[0] == vCard[3])//为一杠，必为不听
                {
                    return enTinType.TinType_Nothing;
                }
                else
                {
                    //含有一刻
                    if ((vCard[0] == vCard[2]) || (vCard[1] == vCard[3]))
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                    //两对
                    if ((vCard[0] == vCard[1]) && (vCard[2] == vCard[3]))
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                    return enTinType.TinType_Nothing;
                }
            }

            //==============================================
            //
            //					 6,9,12张
            //
            //==============================================

            List<List<byte>> vectorGet = new List<List<byte>>();
            GetCharCardsListsByRemoveTriple(vCard, vectorGet);


            if (vectorGet.Count == 0)
            {
                return enTinType.TinType_Nothing;
            }

            if ((vCard.Count % 3) == 0)
            {
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    if (GetCharFigureCardTinType(vectorGet[i]) == enTinType.TinType_Tirple)
                    {
                        return enTinType.TinType_Tirple;
                    }
                }
                return enTinType.TinType_Nothing;
            }

            //==============================================
            //
            //					 7,10,13张
            //
            //==============================================
            if (vCard.Count % 3 == 1)
            {
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    if (GetCharFigureCardTinType(vectorGet[i]) == enTinType.TinType_OtherTriple)
                    {
                        return enTinType.TinType_OtherTriple;
                    }
                }
                return enTinType.TinType_Nothing;
            }

            //==============================================
            //
            //				 5,8,11张
            //
            //==============================================
            //东，南，西，中，中，发，发，发
            if (vCard.Count % 3 == 2)
            {
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    if (GetCharFigureCardTinType(vectorGet[i]) == enTinType.TinType_HavePair)
                    {
                        return enTinType.TinType_HavePair;
                    }
                }
                return enTinType.TinType_Nothing;
            }

            return enTinType.TinType_Unknown;
        }

        //针对字牌，以各种情况移除一个组后得到的所有可能的序列
        public static void GetCharCardsListsByRemoveTriple(List<byte> vectorSourceCard, List<List<byte>> vectorReturn)
        {
            vectorReturn.Clear();

            if (vectorSourceCard.Count < 3)
            {
                return;
            }

            List<byte> vectorCur = new List<byte>();
            vectorCur.Clear();

            for (int i = 0; i < vectorSourceCard.Count - 2; i++)
            {
                //搜刻
                if (((vectorSourceCard[i] == vectorSourceCard[i + 1]) && (vectorSourceCard[i] == vectorSourceCard[i + 2])))//找到一个刻
                {
                    //除了这个刻的牌，其他牌全部加入到序列集里
                    List<byte> vectorFind = new List<byte>();
                    vectorFind.Clear();
                    for (int j = 0; j < vectorSourceCard.Count; j++)
                    {
                        if ((j < i) || (j > (i + 2)))
                        {
                            vectorFind.Add(vectorSourceCard[j]);
                        }
                    }
                    if (!IsSame(vectorCur, vectorFind))
                    {
                        vectorCur = vectorFind;
                        vectorReturn.Add(vectorCur);
                    }
                }
            }
        }

        #endregion

        //===============================================
        //
        //					胡牌检查
        //
        //===============================================

        //是否胡七对子结构
        public static bool IsHuSevenPairStruct(List<byte> vSrc)
        {
            //1、七对子结构，必须门清
            //if (vSrc.Count != MahjongDef.gCardCount_Active)
            //{
            //    return false;
            //}
            short wPairCount = 0;
            for (short i = 0; i < vSrc.Count - 1; i++)
            {
                if (MahjongDef.gInvalidMahjongValue == vSrc[i])
                {
                    return false;
                }
                if (vSrc[i] == vSrc[i + 1])
                {
                    ++wPairCount;
                    i += 1;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return wPairCount == 7;
        }



        //合并后剔除重复
        public static List<byte> MergeVector(List<byte> vectorCard1, List<byte> vectorCard2)
        {
            if (vectorCard2.Count == 0)
                return vectorCard1;

            for (int i = 0; i < vectorCard2.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < vectorCard1.Count; j++)
                {
                    if (vectorCard1[j] == vectorCard2[i])
                        count++;
                }
                if (count == 0)
                    vectorCard1.Add(vectorCard2[i]);
            }
            vectorCard1.Sort();
            return vectorCard1;
        }



        //将一个牌阵中重复的删除只保留一个
        public static List<byte> RemoveRepeat(List<byte> vSource)
        {
            //如果长度小于2，直接返回
            if (vSource.Count < 2)
            {
                return vSource;
            }
            List<byte> vReturn = new List<byte>();
            vReturn.Clear();

            short wFindCount = 0;
            for (short i = 0; i < vSource.Count; i++)
            {
                wFindCount = 0;
                if (vReturn.Count == 0)
                {
                    vReturn.Add(vSource[i]);
                }
                else
                {
                    for (short j = 0; j < vReturn.Count; j++)
                    {
                        if (vReturn[j] == vSource[i])
                        {
                            ++wFindCount;
                            break;
                        }
                    }
                    if (0 == wFindCount)
                    {
                        vReturn.Add(vSource[i]);
                    }
                }
            }
            return vReturn;
        }
        #endregion

        #region 合肥麻将

        /// <summary>
        /// 取孤张,此方法只将牌阵的相对孤张取出来
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vGuCards"></param>
        public static void GetCardListGuCardsForWHMJ(List<byte> srcAry, clsFixedCard srcFixedCard, List<byte> vGuCards, bool checkPair = false)
        {

            List<byte> vSrc = new List<byte>(srcAry);
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            //胡牌基础判断准备完毕
            vGuCards.Clear();
            if (vSrc.Count == 0)
            {
                return;
            }

            //1、分拣牌
            List<byte> vFigureCard = new List<byte>();//普通牌
            List<byte> vZhiCard = new List<byte>();//字牌
            //牌归牌，字牌归字牌
            for (short i = 0; i < vSrc.Count; i++)
            {
                switch (GetMahjongColor(vSrc[i]))
                {
                    case MahjongDef.gMahjongColor_Wan:	//万
                    case MahjongDef.gMahjongColor_Tong:	//筒
                    case MahjongDef.gMahjongColor_Tiao:	//条
                        {
                            vFigureCard.Add(vSrc[i]);
                            break;
                        }
                    case MahjongDef.gMahjongColor_Zhi:	//字
                        {
                            vZhiCard.Add(vSrc[i]);
                            break;
                        }
                }
            }

            //3、对各个花色牌取孤张
            List<byte> vFigureGuCard = new List<byte>();
            List<byte> vZhiGuCard = new List<byte>();

            if (vFigureCard.Count > 0)
            {
                //对一个单一花色的牌阵进行去顺去刻
                RemoveEchoAndFlashForCardList(vFigureCard, vFigureGuCard, true);
            }
            if (vZhiCard.Count > 0)
            {
                //对一个单一花色的牌阵进行去顺去刻
                RemoveEchoAndFlashForCardList(vZhiCard, vZhiGuCard, false);
            }

            if (checkPair && (vFigureGuCard.Count > 0))
            {
                List<byte> gang = new List<byte>();
                List<byte> echo = new List<byte>();
                List<byte> pair = new List<byte>();
                List<byte> hash = new List<byte>();
                SpiltHandCardToGEPH(vFigureGuCard, gang, echo, pair, hash);
                if (hash.Count > 0)
                {
                    for (int i = 0; i < hash.Count; i++)
                    {
                        if (srcAry.FindAll(delegate(byte checkCard) { return checkCard == hash[i]; }).Count == 2)
                        {
                            vFigureGuCard.Add(hash[i]);
                        }
                    }
                }
            }
            //4、合并各个花色牌的孤张，做为本次的孤张集返回
            vGuCards.AddRange(vFigureGuCard);
            vGuCards.AddRange(vZhiGuCard);
        }

        /// <summary>
        /// 检查指定牌阵能否听牌
        /// </summary>
        /// <param name="vSrc"></param>
        /// <param name="vectorTingCard"></param>
        /// <returns></returns>
        public static bool CheckIfCanTingCardArrayForWHMJ(List<byte> srcAry, List<byte> vectorTingCard = null)
        {
            if (null != vectorTingCard)
            {
                vectorTingCard.Clear();
            }

            //胡牌基础判断准备完毕
            List<byte> vSrc = new List<byte>(srcAry);
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            //扑克复制
            List<byte> vTingSpecial = new List<byte>();
            List<byte> vTingNormal = new List<byte>();
            bool bTing = false;

            //1、判断是否特殊听牌
             if (CheckIfCanSpecialTing(vSrc))
                 {
                     bTing = true;
                     if (null != vectorTingCard)
                     {
                         //获取特殊听牌
                         vTingSpecial.Clear();
                         //获取特殊所听之牌
                         GetSpecialTingCard(vSrc, ref vTingSpecial);
                     }
                     else
                     {
                         return true;
                     }
                 }

            //2、判断是否普通听牌
            if (CheckIfCanNormalTing(vSrc))
            {
                bTing = true;
                if (null != vectorTingCard)
                {
                    //获取普通听牌
                    vTingNormal.Clear();
                    //获取普通所听之牌
                    GetNormalTingCard(vSrc, ref vTingNormal);
                }
                else
                {
                    return true;
                }
            }

            if (null == vectorTingCard)
            {
                return bTing;
            }
            if ((vTingSpecial.Count == 0) && (vTingNormal.Count == 0))
            {
                return false;
            }
            //合并两个听牌集并剔除重复
            //合并两个听牌集
            vTingNormal = MergeVector(vTingNormal, vTingSpecial);
            //去除重复项
            vTingNormal = RemoveRepeat(vTingNormal);
            //for (int i = vTingNormal.Count - 1; i >= 0; i--)
            //{
            //    if (!SpecialForWHMJ.CheckHuBase(allCard, vTingNormal[i]))
            //        vTingNormal.RemoveAt(i);
            //}
            vectorTingCard.AddRange(vTingNormal);

            return vectorTingCard.Count > 0;

        }

        /// <summary>
        /// 检查一副牌是否可以胡牌
        /// </summary>
        /// <param name="vSrc"></param>
        /// <returns></returns>
        public static bool CheckIfCanHuCardArrayForWHMJ(List<byte> srcAry)
        {
            List<byte> vSrc = new List<byte>(srcAry);

            //1、先决条件必须满足:胡牌的牌张数必须满%3==2，否则不可以胡
            if ((vSrc.Count % 3) != 2)
            {
                return false;
            }

            //if (!SpecialForWHMJ.CheckHuBase(allCard))
            //{
            //    return false;
            //}
            //2、胡牌分三种情况：
            /*
                2.1)、国世无双
                2.2)、七对子
                2.3)、对+刻/顺
            */
            /*    if (IsHuShiSanLan(vSrc))
                {
                    return true;
                }

                if (IsHuSevenPairStruct(vSrc))
                {
                    return true;
                }*/
            if (IsHuNormalStruct(vSrc))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 13不靠
        //检查听牌是否为十三烂
        public static bool CheckIfTingShiSanLan(List<byte> vSrc)
        {
            //十三烂必须是门清
            if (13 != vSrc.Count)
            {
                return false;
            }

            List<byte> handCard = new List<byte>();
            handCard.AddRange(vSrc);

            //1、先将玩家的牌分开
            List<byte> vWanCard = new List<byte>();
            List<byte> vTongCard = new List<byte>();
            List<byte> vTiaoCard = new List<byte>();
            List<byte> vZhiCard = new List<byte>();

            SpiltHandCardByCardColor(handCard, vWanCard, vTongCard, vTiaoCard, vZhiCard);

            //检查万筒条是否满足条件
            if (!CheckValueBiggerTwo(vWanCard) || !CheckValueBiggerTwo(vTongCard) || !CheckValueBiggerTwo(vTiaoCard))
            {
                return false;
            }

            //检查字是否满足条件
            if (!CheckZhiIsSame(vZhiCard))
            {
                return false;
            }

            //检查万筒条的个数是否满足条件(个数必须是8或者9)
            if (vWanCard.Count + vTongCard.Count + vTiaoCard.Count < 8)
            {
                return false;
            }

            //检查每个花色的值属性（1、4、7属性为0， 2、5、8属性为1， 3、6、9属性为2）
            byte wanFlag;
            byte tongFlag;
            byte tiaoFlag;
            wanFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vWanCard[0]));
            tongFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vTongCard[0]));
            tiaoFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vTiaoCard[0]));

            if (wanFlag == tongFlag || wanFlag == tiaoFlag || tongFlag == tiaoFlag)
            {
                return false;
            }

            return true;
        }

        //检查万筒条的花色的值是否间隔大于2,并且值是1、4、7或者是2、5、8或者是3、6、9
        private static bool CheckValueBiggerTwo(List<byte> card)
        {
            List<byte> colorCard = new List<byte>();
            colorCard.Clear();
            colorCard.AddRange(card);

            colorCard.Sort();
            if (colorCard.Count > 3 || colorCard.Count < 2)
            {
                return false;
            }

            for (int i = colorCard.Count - 1; i > 0; i--)
            {
                if (colorCard[i] - colorCard[i - 1] < 3)
                {
                    return false;
                }
            }

            if (!IsEquleValue(colorCard))
            {
                return false;
            }

            return true;
        }

        //检查牌值是否为1、4、7或者是2、5、8或者是3、6、9
        private static bool IsEquleValue(List<byte> card)
        {
            switch (MahjongGeneralAlgorithm.GetMahjongValue(card[0]))
            {
                case 1:
                case 4:
                case 7:
                    for (int i = 0; i < card.Count; i++)
                    {
                        if (1 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 4 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 7 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]))
                        {
                            return false;
                        }
                    }
                    break;

                case 2:
                case 5:
                case 8:
                    for (int i = 0; i < card.Count; i++)
                    {
                        if (2 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 5 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 8 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]))
                        {
                            return false;
                        }
                    }
                    break;

                case 3:
                case 6:
                case 9:
                    for (int i = 0; i < card.Count; i++)
                    {
                        if (3 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 6 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]) && 9 != MahjongGeneralAlgorithm.GetMahjongValue(card[i]))
                        {
                            return false;
                        }
                    }
                    break;

                default: break;
            }

            return true;
        }

        //检查字是否满足条件
        private static bool CheckZhiIsSame(List<byte> zhiCard)
        {
            List<byte> card = new List<byte>();
            card.Clear();
            card.AddRange(zhiCard);

            card.Sort();
            for (int i = card.Count - 1; i > 0; i--)
            {
                if (card[i] - card[i - 1] < 1)
                {
                    return false;
                }
            }

            return true;
        }

        //检查每个花色的值属性（1、4、7属性为0， 2、5、8属性为1， 3、6、9属性为2）
        private static byte CheckValueFlag(byte card)
        {
            switch (card)
            {
                case 1:
                case 4:
                case 7:
                    return 0;
                    break;

                case 2:
                case 5:
                case 8:
                    return 1;
                    break;

                case 3:
                case 6:
                case 9:
                    return 2;
                    break;

                default: break;
            }

            return 255;
        }

        //是否胡十三烂
        public static bool IsHuShiSanLan(List<byte> vSrc)
        {
            if (vSrc.Count != MahjongDef.gCardCount_Active)
            {
                return false;
            }

            List<byte> card = new List<byte>();
            card.Clear();
            card.AddRange(vSrc);

            List<byte> vWanCard = new List<byte>();
            List<byte> vTongCard = new List<byte>();
            List<byte> vTiaoCard = new List<byte>();
            List<byte> vZhiCard = new List<byte>();

            vWanCard.Clear();
            vTongCard.Clear();
            vTiaoCard.Clear();
            vZhiCard.Clear();

            //分拣牌
            SpiltHandCardByCardColor(card, vWanCard, vTongCard, vTiaoCard, vZhiCard);

            //检查万筒条是否满足条件
            if (!CheckValueIsRight(vWanCard) || !CheckValueIsRight(vTongCard) || !CheckValueIsRight(vTiaoCard))
            {
                return false;
            }

            //检查字是否满足条件
            if (!CheckZhiIsSame(vZhiCard))
            {
                return false;
            }

            //检查每个花色的值属性（1、4、7属性为0， 2、5、8属性为1， 3、6、9属性为2）
            byte wanFlag;
            byte tongFlag;
            byte tiaoFlag;
            wanFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vWanCard[0]));
            tongFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vTongCard[0]));
            tiaoFlag = CheckValueFlag(MahjongGeneralAlgorithm.GetMahjongValue(vTiaoCard[0]));

            if (wanFlag == tongFlag || wanFlag == tiaoFlag || tongFlag == tiaoFlag)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取两个时间之间相隔的秒数
        /// </summary>
        /// <param name="preTime"></param>
        /// <param name="NextTime"></param>
        /// <returns></returns>
        public static int GetSecondsInTwoTime(DateTime preTime, DateTime NextTime)
        {
            TimeSpan Ts = NextTime - preTime;
            return Ts.Minutes * 60 + Ts.Seconds;
        }

        //检查万筒条的花色的值是否满足条件
        private static bool CheckValueIsRight(List<byte> card)
        {
            List<byte> colorCard = new List<byte>();
            colorCard.Clear();
            colorCard.AddRange(card);

            colorCard.Sort();
            if (colorCard.Count != 3)
            {
                return false;
            }

            if (!IsEquleValue(colorCard))
            {
                return false;
            }

            return true;
        }
        //获取万筒条听牌
        private static byte getWanTongTiaoTing(List<byte> card)
        {

            card.Sort();
            switch (MahjongGeneralAlgorithm.GetMahjongColorValue(card[0]))
            {
                case 0x00:
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 4)
                    {
                        return 7;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 4;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 4 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 1;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 5)
                    {
                        return 8;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 5;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 5 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 2;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 6)
                    {
                        return 9;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 6;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 6 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 3;
                    }
                    break;

                case 0x10:
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 4)
                    {
                        return 7 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 4 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 4 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 1 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 5)
                    {
                        return 8 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 5 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 5 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 2 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 6)
                    {
                        return 9 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 6 + 16;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 6 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 3 + 16;
                    }
                    break;

                case 0x20:
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 4)
                    {
                        return 7 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 1 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 4 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 4 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 7)
                    {
                        return 1 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 5)
                    {
                        return 8 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 2 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 5 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 5 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 8)
                    {
                        return 2 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 6)
                    {
                        return 9 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 3 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 6 + 32;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongValue(card[0]) == 6 && MahjongGeneralAlgorithm.GetMahjongValue(card[1]) == 9)
                    {
                        return 3 + 32;
                    }
                    break;

                default: break;
            }
            return 0;
        }
        #endregion


        //-------------------------------------------听牌 宝牌-----------------------------

        /// <summary>
        /// 获取0-9万列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> Get029Wan()
        {
            List<byte> wan = new List<byte>();
            byte wan1 = 0x01;
            for (int i = 0; i < 9; i++)
            {
                wan.Add((byte)(wan1 + i));
            }
            return wan;
        }
        /// <summary>
        /// 获取0-9筒列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> Get029Tong()
        {
            List<byte> tong = new List<byte>();
            byte tong1 = 0x11;
            for (int i = 0; i < 9; i++)
            {
                tong.Add((byte)(tong1 + i));
            }
            return tong;
        }
        /// <summary>
        /// 获取0-9条列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> Get029Tiao()
        {
            List<byte> tiao = new List<byte>();
            byte tiao1 = 0x21;
            for (int i = 0; i < 9; i++)
            {
                tiao.Add((byte)(tiao1 + i));
            }
            return tiao;
        }
        /// <summary>
        /// 获取字牌列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> Get027Zi()
        {
            List<byte> zi = new List<byte>();
            byte zi1 = 0x31;
            for (int i = 0; i < 7; i++)
            {
                zi.Add((byte)(zi1 + i));
            }
            return zi;
        }
        /// <summary>
        /// 获取东南西北列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> GetDNXB()
        {
            List<byte> zi = new List<byte>();
            byte zi1 = 0x31;
            for (int i = 0; i < 4; i++)
            {
                zi.Add((byte)(zi1 + i));
            }
            return zi;
        }
        /// <summary>
        /// 获取中发白列表
        /// </summary>
        /// <returns></returns>
        public static List<byte> GetZFB()
        {
            List<byte> zi = new List<byte>();
            byte zi1 = 0x35;
            for (int i = 0; i < 3; i++)
            {
                zi.Add((byte)(zi1 + i));
            }
            return zi;
        }


        /// <summary>
        /// 检查指定牌阵能否听牌(有混牌)
        /// </summary>
        /// <param name="srcAry"></param>
        /// <param name="hunAry"></param>
        /// <param name="vectorTingCard"></param>
        /// <returns></returns>
        public static bool CheckIfCanTingCardArrayHaveHun(List<byte> srcAry, List<byte> hunAry, List<byte> vectorTingCard = null, bool ifcanhu7dui = false)
        {
            List<byte> tingCards = new List<byte>();
            if (srcAry.Count % 3 != 1)
            {
                return false;
            }

            List<byte> m_ConstAllCard = MahjongGeneralAlgorithm.Get029Wan();
            m_ConstAllCard.AddRange(MahjongGeneralAlgorithm.Get029Tong());
            m_ConstAllCard.AddRange(MahjongGeneralAlgorithm.Get029Tiao());
            m_ConstAllCard.AddRange(MahjongGeneralAlgorithm.GetDNXB());
            m_ConstAllCard.AddRange(MahjongGeneralAlgorithm.GetZFB());

            int Count = m_ConstAllCard.Count;

            List<byte> allCard = new List<byte>();

            for (int i = 0; i < Count; i++)
            {
                allCard.Clear();
                allCard.AddRange(srcAry);
                allCard.Add(m_ConstAllCard[i]);

                if (MahjongGeneralAlgorithm.CheckIfCanHuCardArrayHaveHun(allCard, hunAry, ifcanhu7dui))
                {
                    tingCards.Add(m_ConstAllCard[i]);
                }

            }
            if (vectorTingCard != null)
            {
                for (int i = 0; i < tingCards.Count; i++)
                {
                    vectorTingCard.Add(tingCards[i]);
                }
            }

            return tingCards.Count > 0;
        }

        /// <summary>
        /// 检查指定牌阵是否能够胡牌
        /// </summary>
        /// <param name="srcAry"></param>
        /// <returns></returns>
        public static bool CheckIfCanHuCardArrayHaveHun(List<byte> srcAy, List<byte> hunAry, bool ifCanhu7Pair = false)
        {
            List<byte> vSrc = new List<byte>(srcAy);
            if (vSrc.Count % 3 != 2)
            {
                return false;
            }

            if (hunAry == null)
            {
                return false;
            }


            int laiziNum = 0;
            List<byte> srcAry = new List<byte>();
            for (int i = 0; i < vSrc.Count; i++)
            {
                if (hunAry.Contains(vSrc[i]))
                {
                    laiziNum++;
                    continue;
                }
                else
                {
                    srcAry.Add(vSrc[i]);
                }
            }


            if (CheckIfCanHuCardArray(srcAry))//没有赖子普通的胡牌，如果有赖子(即laiziNum!=0),且此处判断能够胡，那么赖子数必为3的整数倍
            {
                return true;
            }



            #region 检测带混的7对(有的带混的麻将不胡7对，有的带混麻将可以胡7对)
            //if (ifCanhu7Pair)
            //{
            //    if (ChangeArrayTo7PairsNeedHun(srcAry, laiziNum))
            //    {
            //        return true;
            //    }
            //}

            #endregion


            //2、按花色分拣牌
            List<byte> vectorWan = new List<byte>();
            List<byte> vectorTong = new List<byte>();
            List<byte> vectorTiao = new List<byte>();
            List<byte> vectorZi = new List<byte>();
            SpiltHandCardByCardColor(srcAry, vectorWan, vectorTong, vectorTiao, vectorZi);
            //3、得到各自的成组需赖子数
            int wanneed = ChangeArrayToTripleForHuapai(vectorWan);
            int tongneed = ChangeArrayToTripleForHuapai(vectorTong);
            int tiaoneed = ChangeArrayToTripleForHuapai(vectorTiao);
            int zineed = ChangeArrayToTripleForZipai(vectorZi);// ChangeArrayToTripleForZipai(vectorZi);红中赖子麻将实际上也没有字牌

            int needNum = wanneed + tongneed + tiaoneed + zineed;

            if (laiziNum >= needNum)//如果laiziNum>needNum,那么(laiziNum-needNum)一定是3的倍数
            {
                return true;
            }

            //四种情况，将对分别在万，筒，条，字中
            needNum = tongneed + tiaoneed + zineed;

            //万成对
            if (needNum <= laiziNum)
            {
                if (ChangeArrayToPairAndTripleForHuapai(vectorWan, laiziNum - needNum))
                {
                    return true;
                }
            }
            needNum = wanneed + tiaoneed + zineed;
            //筒成对
            if (needNum <= laiziNum)
            {
                if (ChangeArrayToPairAndTripleForHuapai(vectorTong, laiziNum - needNum))
                {
                    return true;
                }
            }

            needNum = tongneed + wanneed + zineed;
            //条成对
            if (needNum <= laiziNum)
            {
                if (ChangeArrayToPairAndTripleForHuapai(vectorTiao, laiziNum - needNum))
                {
                    return true;
                }
            }

            needNum = tongneed + tiaoneed + wanneed;
            //字成对
            if (needNum <= laiziNum)
            {
                if (ChangeArrayToPairAndTripleForZipai(vectorZi, laiziNum - needNum))
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// 检查一副牌是否可以胡牌
        /// </summary>
        /// <param name="vSrc"></param>
        /// <returns></returns>
        public static bool CheckIfCanHuCardArray(List<byte> srcAry)
        {
            List<byte> vSrc = new List<byte>(srcAry);

            //1、先决条件必须满足:胡牌的牌张数必须满%3==2，否则不可以胡
            if ((vSrc.Count % 3) != 2)
            {
                return false;
            }

            //2、胡牌分三种情况：
            /*
                2.1)、国世无双
                2.2)、七对子
                2.3)、对+刻/顺
            */

            if (IsHuSevenPairStruct(vSrc))
            {
                return true;
            }
            if (IsHuNormalStruct(vSrc))
            {
                return true;
            }
            return false;
        }

        //是否胡普通结构
        private static bool IsHuNormalStruct(List<byte> vSrc)
        {
            //1、先决条件，胡牌时手上最少要有2张
            if (vSrc.Count < 2)
            {
                return false;
            }
            //2、如果只有2张，则必须为对，否则不胡
            if (vSrc.Count == 2)
            {
                return vSrc[0] == vSrc[1];
            }
            //3、对+刻/顺结构
            vSrc.Sort();

            //除去对之后剩余的牌
            List<byte> vLeftCard = new List<byte>();

            List<byte> vWanCard = new List<byte>();
            List<byte> vTongCard = new List<byte>();
            List<byte> vTiaoCard = new List<byte>();
            List<byte> vZhiCard = new List<byte>();

            List<clsParseTriple> v_TripleWan = new List<clsParseTriple>();
            List<clsParseTriple> v_TripleTong = new List<clsParseTriple>();
            List<clsParseTriple> v_TripleTiao = new List<clsParseTriple>();
            List<clsParseTriple> v_TripleZhi = new List<clsParseTriple>();

            for (int i = 0; i < vSrc.Count - 1; i++)
            {
                if (vSrc[i] == vSrc[i + 1])//找到一对
                {
                    vLeftCard.Clear();

                    vWanCard.Clear();
                    vTongCard.Clear();
                    vTiaoCard.Clear();
                    vZhiCard.Clear();

                    v_TripleWan.Clear();
                    v_TripleTong.Clear();
                    v_TripleTiao.Clear();
                    v_TripleZhi.Clear();

                    //1、先将对子除去
                    for (int j = 0; j < vSrc.Count; j++)
                    {
                        if ((j != i) && (j != (i + 1)))
                        {
                            vLeftCard.Add(vSrc[j]);
                        }
                    }

                    //2、分拣牌
                    SpiltHandCardByCardColor(vLeftCard, vWanCard, vTongCard, vTiaoCard, vZhiCard);

                    //3、分别进行解析
                    Parse3ModelToTripleList(vWanCard, v_TripleWan);
                    Parse3ModelToTripleList(vTongCard, v_TripleTong);
                    Parse3ModelToTripleList(vTiaoCard, v_TripleTiao);
                    Parse3ModelToTripleList(vZhiCard, v_TripleZhi);

                    if ((v_TripleWan.Count * 3 + v_TripleTong.Count * 3 + v_TripleTiao.Count * 3 + v_TripleZhi.Count * 3 + 2) == vSrc.Count)
                    {
                        return true;
                    }
                    i += 1;
                    continue;
                }
            }
            return false;
        }

        //对一个同花色的3模式牌阵进行解析
        public static void Parse3ModelToTripleList(List<byte> vSingleCard, List<clsParseTriple> vTriple)
        {
            vTriple.Clear();

            //1、如果不是3模式或没有牌
            if (((vSingleCard.Count % 3) != 0) || (vSingleCard.Count == 0))
            {
                return;
            }

            //2、进行一次排序
            vSingleCard.Sort();

            //3、开始解析
            if (MahjongGeneralAlgorithm.GetMahjongColor(vSingleCard[0]) != MahjongDef.gMahjongColor_Zhi)//花牌,万，筒，条
            {
                //3张牌,要么一刻，要么一顺
                if (vSingleCard.Count == 3)
                {
                    //为一刻
                    if (vSingleCard[0] == vSingleCard[2])
                    {
                        clsParseTriple tagTriple = new clsParseTriple();
                        tagTriple.Clear();
                        tagTriple.enTripleType = enTripleType.TripleType_Echo;
                        tagTriple.cTokenCard = vSingleCard[0];
                        for (short i = 0; i < 3; i++)
                        {
                            tagTriple.cCardAry[i] = vSingleCard[i];
                        }
                        vTriple.Add(tagTriple);
                        return;
                    }

                    //为一顺
                    if (((vSingleCard[1] - vSingleCard[0]) == 1) && ((vSingleCard[2] - vSingleCard[1]) == 1))
                    {
                        clsParseTriple tagTriple = new clsParseTriple();
                        tagTriple.Clear();
                        tagTriple.enTripleType = enTripleType.TripleType_Flash;
                        tagTriple.cTokenCard = vSingleCard[0];
                        for (short i = 0; i < 3; i++)
                        {
                            tagTriple.cCardAry[i] = vSingleCard[i];
                        }
                        vTriple.Add(tagTriple);
                        return;
                    }
                    return;
                }

                //6,9,12张牌
                if ((vSingleCard.Count % 3) == 0)
                {
                    for (short i = 0; i < vSingleCard.Count - 2; i++)
                    {
                        //搜刻,如果含有刻，这三张必在一起
                        if ((vSingleCard[i] == vSingleCard[i + 1]) && (vSingleCard[i] == vSingleCard[i + 2]))
                        {
                            //本次去除刻后的子串
                            List<byte> vRemCard = new List<byte>();
                            for (short j = 0; j < vSingleCard.Count; j++)
                            {
                                if (j < i || j > i + 2)
                                {
                                    vRemCard.Add(vSingleCard[j]);
                                }
                            }
                            //递归解析本次去刻后的子串
                            List<clsParseTriple> vSubTriple = new List<clsParseTriple>();
                            Parse3ModelToTripleList(vRemCard, vSubTriple);
                            if (vSubTriple.Count == 0)
                            {
                                return;
                            }
                            else
                            {
                                for (short j = 0; j < vSubTriple.Count; j++)
                                {
                                    vTriple.Add(vSubTriple[j]);
                                }
                                //再加上此次拆串所得刻
                                clsParseTriple tagTriple = new clsParseTriple();
                                tagTriple.Clear();
                                tagTriple.enTripleType = enTripleType.TripleType_Echo;
                                tagTriple.cTokenCard = vSingleCard[i];
                                for (short j = 0; j < 3; j++)
                                {
                                    tagTriple.cCardAry[j] = vSingleCard[i + j];
                                }
                                vTriple.Add(tagTriple);
                                return;
                            }
                        }

                        //搜顺
                        short wNet1Idx = 0;//顺的第二个索引
                        short wNet2Idx = 0;//顺的第三个索引
                        for (int k = i + 1; k < vSingleCard.Count; k++)
                        {
                            if (((vSingleCard[k] - vSingleCard[i]) == 1) && (wNet1Idx == 0))///找到第一个(例:从233456678中根据3找到4)
                            {
                                wNet1Idx = (short)k;
                            }
                            if (((vSingleCard[k] - vSingleCard[i]) == 2) && (wNet2Idx == 0))///找到第一个(例:从233456678中根据3找到4)
                            {
                                wNet2Idx = (short)k;
                            }
                            if ((wNet1Idx != 0) && (wNet2Idx != 0))
                                break;
                        }
                        if ((wNet1Idx != 0) && (wNet2Idx != 0))//找到顺了
                        {
                            //本次去除刻后的子串
                            List<byte> vRemCard = new List<byte>();
                            for (short j = 0; j < vSingleCard.Count; j++)
                            {
                                if ((j != i) && (j != wNet1Idx) && (j != wNet2Idx))
                                {
                                    vRemCard.Add(vSingleCard[j]);
                                }
                            }

                            //先加上本次拆串所得刻
                            clsParseTriple tagTriple = new clsParseTriple();
                            tagTriple.Clear();
                            tagTriple.enTripleType = enTripleType.TripleType_Flash;
                            tagTriple.cTokenCard = vSingleCard[i];
                            tagTriple.cCardAry[0] = vSingleCard[i];
                            tagTriple.cCardAry[1] = vSingleCard[wNet1Idx];
                            tagTriple.cCardAry[2] = vSingleCard[wNet2Idx];
                            vTriple.Add(tagTriple);

                            //递归解析本次去刻后的子串
                            List<clsParseTriple> vSubTriple = new List<clsParseTriple>();
                            Parse3ModelToTripleList(vRemCard, vSubTriple);
                            if (vTriple.Count == 0)
                            {
                                return;
                            }
                            else
                            {
                                for (short j = 0; j < vSubTriple.Count; j++)
                                {
                                    vTriple.Add(vSubTriple[j]);
                                }
                                return;
                            }
                        }
                    }
                }
            }
            else//字牌，东，南，西，北，中，发，白
            {
                //3张牌，必为一刻，字牌不存在顺
                if (vSingleCard.Count == 3)
                {
                    //为一刻
                    if (vSingleCard[0] == vSingleCard[2])
                    {
                        clsParseTriple tagTriple = new clsParseTriple();
                        tagTriple.Clear();
                        tagTriple.enTripleType = enTripleType.TripleType_Echo;
                        tagTriple.cTokenCard = vSingleCard[0];
                        for (short i = 0; i < 3; i++)
                        {
                            tagTriple.cCardAry[i] = vSingleCard[i];
                        }
                        vTriple.Add(tagTriple);
                    }
                    return;
                }

                //6，9，12张牌
                if ((vSingleCard.Count % 3) == 0)
                {
                    for (short i = 0; i < vSingleCard.Count - 2; i++)
                    {
                        //搜刻,如果含有刻，这三张必在一起
                        if ((vSingleCard[i] == vSingleCard[i + 1]) && (vSingleCard[i] == vSingleCard[i + 2]))
                        {
                            //本次去除刻后的子串
                            List<byte> vRemCard = new List<byte>();
                            for (short j = 0; j < vSingleCard.Count; j++)
                            {
                                if (j < i || j > i + 2)
                                {
                                    vRemCard.Add(vSingleCard[j]);
                                }
                            }
                            //递归解析本次去刻后的子串
                            List<clsParseTriple> vSubTriple = new List<clsParseTriple>();
                            Parse3ModelToTripleList(vRemCard, vSubTriple);
                            if (vSubTriple.Count == 0)
                            {
                                return;
                            }
                            else
                            {
                                for (short j = 0; j < vSubTriple.Count; j++)
                                {
                                    vTriple.Add(vSubTriple[j]);
                                }
                                //再加上此次拆串所得刻
                                clsParseTriple tagTriple = new clsParseTriple();
                                tagTriple.Clear();
                                tagTriple.enTripleType = enTripleType.TripleType_Echo;
                                tagTriple.cTokenCard = vSingleCard[i];
                                for (short j = 0; j < 3; j++)
                                {
                                    tagTriple.cCardAry[j] = vSingleCard[i + j];
                                }
                                vTriple.Add(tagTriple);
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 单一花色牌组补成成组模式所需赖子数(所需最少赖子数)
        /// </summary>
        /// <param name="vectorCard">牌组</param>
        /// <param name="needCard">替代牌</param>
        /// <returns></returns>
        public static int ChangeArrayToTripleForHuapai(List<byte> vectorCard)
        {
            int needCard = 0;
            //无牌
            if (vectorCard.Count == 0)
                return needCard;
            //有牌
            List<List<byte>> vectorGet = new List<List<byte>>();
            List<int> needs = new List<int>(); //所需赖子牌数量
            //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
            GetFigureCardListByRemoveTriple(ref vectorCard, ref vectorGet);
            //牌组被改动，挑选最优项
            if (vectorGet.Count > 0)
            {
                needs.Clear();
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    needs.Add(ChangeArrayToTripleForHuapai(vectorGet[i]));
                }
                int temp = 0;
                for (int i = 0; i < needs.Count; i++)
                {
                    if (needs[temp] > needs[i])
                        temp = i;
                }
                //挑选出最少赖子数
                return needs[temp];
            }

            //最后留一刻或顺,去刻顺不知道为什么留
            if (vectorCard.Count == 3)
            {
                if ((vectorCard[0] == vectorCard[1] && vectorCard[1] == vectorCard[2]) || (vectorCard[2] - vectorCard[1] == 1 && vectorCard[1] - vectorCard[0] == 1))
                    return needCard;
            }

            //到此为止：刻顺全去，剩孤张，对
            vectorCard.Sort();
            for (int i = 0; i < vectorCard.Count; i++)
            {
                //不是最后一张
                if (i != vectorCard.Count - 1 && GetMahjongLogicValue(vectorCard[i + 1]) - GetMahjongLogicValue(vectorCard[i]) < 3)
                {
                    needCard++;
                    i++;
                }
                //最后一张 或 不连张
                else
                {
                    needCard += 2;
                }
            }
            return needCard;
        }

        /// <summary>
        /// 字牌组补成成组模式所需赖子数
        /// </summary>
        /// <param name="vectorCard">牌组</param>
        /// <returns></returns>
        public static int ChangeArrayToTripleForZipai(List<byte> vectorCard)
        {
            int needCard = 0;
            //无牌
            if (vectorCard.Count == 0)
                return needCard;
            //有牌
            List<List<byte>> vectorGet = new List<List<byte>>();
            List<int> needs = new List<int>();
            //针对花牌，以各种情况移除一个组（刻或者顺）后得到的所有可能的序列
            //GetCharCardsListsByRemoveTriple(vectorCard, vectorGet);


            //GetCharCardsListsByRemoveTripleForRQMJ(vectorCard, vectorGet);//任丘麻将有箭胡的情况调用的函数

            //牌组被改动，挑选最优项
            if (vectorGet.Count > 0)
            {
                needs.Clear();
                for (int i = 0; i < vectorGet.Count; i++)
                {
                    needs.Add(ChangeArrayToTripleForZipai(vectorGet[i]));
                }
                int temp = 0;
                for (int i = 0; i < needs.Count; i++)
                {
                    if (needs[temp] > needs[i])
                        temp = i;
                }
                //挑选出最少赖子数
                return needs[temp];
            }
            //最后留一刻或顺,去刻顺不知道为什么留vectorCard
            if (vectorCard.Count == 3)
            {
                if (vectorCard[0] == vectorCard[1] && vectorCard[1] == vectorCard[2])
                    return needCard;
            }

            //到此为止：刻顺全去，剩孤张，对
            //到此为止：刻顺全去，剩孤张，对
            vectorCard.Sort();
            //此时将东南西北，和中发白分出来

            List<byte> vectorDNXB = new List<byte>(); //东南西北列表
            List<byte> vectorZFB = new List<byte>();//中发白列表

            int needCardDNXB = 0;//东南西北需要混牌数量

            int needCardZFB = 0;//中發白需要混牌数量

            for (int i = 0; i < vectorCard.Count; i++)
            {
                if (vectorCard[i] != 0x35 && vectorCard[i] != 0x36 && vectorCard[i] != 0x37)
                {
                    vectorDNXB.Add(vectorCard[i]);
                    continue;
                }
                vectorZFB.Add(vectorCard[i]);
            }
            vectorDNXB.Sort();
            vectorZFB.Sort();

            for (int i = 0; i < vectorDNXB.Count; i++)//组成3个一样的
            {
                //不是最后一张，字牌要相同
                if (i != vectorDNXB.Count - 1 && GetMahjongLogicValue(vectorDNXB[i + 1]) == GetMahjongLogicValue(vectorDNXB[i]))
                {
                    needCardDNXB++;
                    i++;
                }

                //最后一张 或 不连张
                else
                {
                    needCardDNXB += 2;
                }
            }

            for (int i = 0; i < vectorZFB.Count; i++)//组成3个一样的
            {
                //不是最后一张，字牌要相同
                if (i != vectorZFB.Count - 1 && GetMahjongLogicValue(vectorZFB[i + 1]) == GetMahjongLogicValue(vectorZFB[i]))
                {
                    needCardZFB++;
                    i++;
                }

                //最后一张 或 不连张
                else
                {
                    needCardZFB += 2;
                }
            }

            int needCard2 = 0;
            bool isreal0 = false;
            for (int i = 0; i < vectorZFB.Count; i++)//组成箭
            {
                if (i != vectorZFB.Count - 1 && (vectorZFB[i] == 53 || vectorZFB[i] == 54 || vectorZFB[i] == 55))
                {
                    isreal0 = true;
                    int zhong = -1;
                    int fa = -1;
                    int bai = -1;

                    for (int j = i; j < vectorZFB.Count; j++)
                    {
                        if (zhong == -1 && vectorZFB[j] == 53)
                        {
                            zhong = j;
                        }
                        if (fa == -1 && vectorZFB[j] == 54)
                        {
                            fa = j;
                        }
                        if (bai == -1 && vectorZFB[j] == 55)
                        {
                            bai = j;
                        }
                    }

                    if (zhong != -1)
                    {
                        i++;
                    }
                    if (zhong == -1)
                    {
                        needCard2++;
                    }
                    if (fa != -1)
                    {
                        i++;
                    }
                    if (fa == -1)
                    {
                        needCard2++;
                    }
                    if (bai != -1)
                    {
                        i++;
                    }
                    if (bai == -1)
                    {
                        needCard2++;
                    }
                }
            }
            if (isreal0)
            {
                needCardZFB = (needCardZFB <= needCard2) ? needCardZFB : needCard2;
            }
            else
            {
                if (needCard2 != 0)
                {
                    needCardZFB = (needCardZFB <= needCard2) ? needCardZFB : needCard2;
                }
            }

            needCard = needCardDNXB + needCardZFB;

            return needCard;
        }

        /// <summary>
        /// 单一花色牌组补成胡牌模式（一对加N组）
        /// </summary>
        /// <param name="vectorCard">牌组</param>
        /// <param name="laiziNum">可用赖子数</param>
        /// <returns></returns>
        public static bool ChangeArrayToPairAndTripleForHuapai(List<byte> vectorCard, int laiziNum)
        {
            int needCard = 0;
            List<byte> allCards = new List<byte>(vectorCard);
            allCards.Sort();
            //无牌，要两张赖子
            if (allCards.Count == 0)
            {
                needCard += 2;
                return needCard <= laiziNum;
            }
            List<byte> needBu = new List<byte>();
            List<int> needs = new List<int>();
            //先选出一对，再对剩下的牌做补组
            for (int i = 0; i < allCards.Count; i++)
            {
                //非最后一张,且是对
                if (i < allCards.Count - 1 && allCards[i] == allCards[i + 1])
                {
                    needBu.Clear();
                    for (int j = 0; j < allCards.Count; j++)
                    {
                        if (!(j == i || j == i + 1))
                            needBu.Add(allCards[j]);
                    }
                    needs.Add(ChangeArrayToTripleForHuapai(needBu));//有对只需要计算出组成3张的，需要多少赖子
                }
                else//孤张
                {
                    needBu.Clear();
                    for (int j = 0; j < allCards.Count; j++)
                    {
                        if (j != i)
                            needBu.Add(allCards[j]);
                    }
                    needs.Add(ChangeArrayToTripleForHuapai(needBu));
                    needs[i]++;//单张组成对一张需要加
                }
            }
            //只能返回一种可能，若出现多种胡牌可能会出错
            int temp = 0;
            for (int i = 0; i < needs.Count; i++)
            {
                if (needs[temp] > needs[i])
                    temp = i;
            }

            return needs[temp] <= laiziNum;
        }

        /// <summary>
        /// 字牌组补成胡牌模式（一对加N组）
        /// </summary>
        /// <param name="vectorCard">牌组</param>
        /// <param name="laiziNum">可用赖子数</param>
        /// <returns></returns>
        public static bool ChangeArrayToPairAndTripleForZipai(List<byte> vectorCard, int laiziNum)
        {
            int needCard = 0;
            List<byte> allCards = new List<byte>(vectorCard);
            allCards.Sort();
            //无牌，要两张赖子
            if (allCards.Count == 0)
            {
                needCard += 2;
                return needCard <= laiziNum;
            }
            List<byte> needBu = new List<byte>();
            List<int> needs = new List<int>();
            //先选出一对，再对剩下的牌做补组
            for (int i = 0; i < allCards.Count; i++)
            {
                //非最后一张，是对
                if (i < allCards.Count - 1 && allCards[i] == allCards[i + 1])
                {
                    needBu.Clear();
                    for (int j = 0; j < allCards.Count; j++)
                    {
                        if (!(j == i || j == i + 1))
                            needBu.Add(allCards[j]);
                    }
                    needs.Add(ChangeArrayToTripleForZipai(needBu));
                }
                else//孤张
                {
                    needBu.Clear();
                    for (int j = 0; j < allCards.Count; j++)
                    {
                        if (j != i)
                            needBu.Add(allCards[j]);
                    }
                    needs.Add(ChangeArrayToTripleForZipai(needBu));
                    needs[i]++;
                }
            }
            //只能返回一种可能，若出现多种胡牌可能会出错
            int temp = 0;
            for (int i = 0; i < needs.Count; i++)
            {
                if (needs[temp] > needs[i])
                    temp = i;
            }


            return needs[temp] <= laiziNum;
        }

    }
}
