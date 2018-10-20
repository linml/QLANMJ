using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongAlgorithmForMGMJ
{
    /// <summary>
    /// 麻将牌型算法
    /// </summary>
    public class MahjongPatternAlgorithm
    {
        #region 牌阵解析

        /// <summary>
        /// 解析牌阵
        /// 一对一副已经胡了牌阵进行解析，例如:将一副牌13,13,15,16,17,22,22,22,24,25,26,34,35,36 解析成：
        /// 对子：13 13 放入vectorPair
        /// Triple集为:15,16,17 | 22,22,22 | 24,25,26 | 34,35,36 放入vectorTriple
        /// </summary>
        /// <param name="pCard"></param>
        /// <param name="wCardCount"></param>
        /// <param name="tagFixedCard"></param>
        /// <param name="tagParseResult"></param>
        /// <param name="cHuCard"></param>
        public static bool ParseCards(List<byte> srcActiveCard)
        {

            //复制一份活动牌
            List<byte> activeCard = new List<byte>(srcActiveCard);



            //去除活动牌阵中的无效牌并排序
            activeCard.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            activeCard.Sort();

            //先检查是否可以胡牌
            if (!MahjongGeneralAlgorithm.CheckIfCanHuCardArrayForWHMJ(activeCard))
            {
                return false;
            }


            return true;
        }

        /// <summary>
        /// 检查是否是特殊胡牌结构
        /// </summary>
        /// <param name="activeCard"></param>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckIsSpecialStruct(List<byte> activeCard, ref clsParseResult parseResult)
        {
            if (activeCard.Count != MahjongDef.gCardCount_Active)
            {
                return false;
            }

            //2、检查七对子:14张牌是七副对子组成，检查对子数量是否等于7
            int wPairCount = 0;
            for (int i = 0; i < activeCard.Count - 1; i++)
            {
                if (activeCard[i] == activeCard[i + 1])
                {
                    ++wPairCount;
                    i += 1;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (wPairCount != 7)//不满足基本七对子情况
            {
                return false;
            }

            #region 血战麻将中用不到的检测

            /*
            1、排除三连杠情况
            3333 4444 5555 99
            如果解析成七对子，则只有2番，但是如果解析成333 444 555 345 99,就有三暗刻+三连刻=4番,所以需要排除这种情况即排除三连杠情况
            

            byte[] cGangCard = new byte[3];
            Array.Clear(cGangCard, 0, 3);
            int wGangCount = 0;

            for (int i = 0; i < activeCard.Count - 3; i++)
            {
                if ((activeCard[i] == activeCard[i + 1]) && (activeCard[i] == activeCard[i + 2]) && (activeCard[i] == activeCard[i + 3]))
                {
                    cGangCard[wGangCount++] = activeCard[i];
                    i += 3;
                    continue;
                }
            }
            if (wGangCount == 3)
            {
                //检查是否是三连杠
                if (((cGangCard[1] - cGangCard[0]) == 1) && ((cGangCard[2] - cGangCard[1]) == 1))
                {
                    //如果是三连杠，就不解析成七对子
                    return false;
                }
            }*/

            /*
            2、排除二色二顺情况
            223344(万),55667777(筒),
            如果解析成七对子则只有2番，但是如果解析成二色二顺，则有3番，所以这种牌型应该解析成二色二顺
            
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

            if (vFlash.Count() == 2)
            {
                if ((vFlash[0] != vFlash[1]) && (MahjongGeneralAlgorithm.GetMahjongColor(vFlash[0]) != MahjongGeneralAlgorithm.GetMahjongColor(vFlash[1])))//二色二顺
                {
                    return false;
                }
            }
            */

            #endregion

            if (wPairCount == (activeCard.Count / 2))
            {
                parseResult.is7Pair = true;
                parseResult.cardAryBy7Pair.AddRange(activeCard);
                return true;
            }

            //3、都不是，就是非特殊胡牌结构
            return false;
        }

        /// <summary>
        /// 对一个单色牌阵进行解析
        /// </summary>
        /// <param name="vSingleCard"></param>
        private static void ParseSingleColorCard(List<byte> vSingleCard, ref clsPairTripleWrapper pairTripleWrapper)
        {
            if (vSingleCard.Count() == 0)
            {
                return;
            }

            //1、如果是三模式
            if (vSingleCard.Count() % 3 == 0)
            {
                List<clsParseTriple> vTriple = new List<clsParseTriple>();
                Parse3ModelToTripleList(vSingleCard, vTriple);
                for (int i = 0; i < vTriple.Count(); i++)
                {
                    pairTripleWrapper.AddTriple(vTriple[i]);
                }
                return;
            }

            //2、如果是二模式仅两张牌
            if (vSingleCard.Count() == 2)
            {
                pairTripleWrapper.cPair = vSingleCard[0];
                return;
            }

            /************************************************************************************
            * 注意:
            * 考察这样一个解析例子:
            * (例如:33344455566)
            * 如果以3做对子,其他的牌可以解析为:345,456,456(一色二顺),这样的解析结果翻数较小
            * 如果以6做对子,其他的牌可以解析为:333,444,555(三暗刻),这样的解析结果翻数较大
            * 所以,对于2模式,应该遍历搜对,将所有成功的解析包装,再选出解析结果的最大值作为解析
            * ***********************************************************************************/

            //3、如果是二模式，一对+顺/刻
            List<clsPairTripleWrapper> vPairTripleWrapper = new List<clsPairTripleWrapper>();
            vSingleCard.Sort();

            for (int i = 0; i < vSingleCard.Count() - 1; i++)
            {
                //有对子，两张牌必在一起
                if (vSingleCard[i] == vSingleCard[i + 1])
                {
                    List<byte> vRemList = new List<byte>();
                    for (int j = 0; j < vSingleCard.Count(); j++)
                    {
                        if ((j < i) || (j > (i + 1)))
                        {
                            vRemList.Add(vSingleCard[j]);
                        }
                    }
                    List<clsParseTriple> vTriple = new List<clsParseTriple>();
                    Parse3ModelToTripleList(vRemList, vTriple);
                    if (vTriple.Count() > 0)//此次拆分是对的
                    {
                        clsPairTripleWrapper tagParTripleWrapper = new clsPairTripleWrapper();
                        tagParTripleWrapper.Clear();
                        tagParTripleWrapper.cPair = vSingleCard[i];
                        for (int j = 0; j < vTriple.Count(); j++)
                        {
                            tagParTripleWrapper.AddTriple(vTriple[j]);
                        }
                        vPairTripleWrapper.Add(tagParTripleWrapper);
                    }
                }
            }

            if (vPairTripleWrapper.Count() == 0)
            {
                return;
            }

            //找到拥有最大解析值的PairTripleWrapper
            int wMaxIdx = 0;
            int wMaxTripleValue = 0;
            for (int i = 0; i < vPairTripleWrapper.Count(); i++)
            {
                int wCurTripleValue = vPairTripleWrapper[i].tripleValue;
                if (wCurTripleValue > wMaxTripleValue)
                {
                    wMaxIdx = i;
                    wMaxTripleValue = wCurTripleValue;
                }
            }

            //将此对赋值
            pairTripleWrapper.cPair = vPairTripleWrapper[wMaxIdx].cPair;
            for (int i = 0; i < vPairTripleWrapper[wMaxIdx].wTripleCount; i++)
            {
                pairTripleWrapper.AddTriple(vPairTripleWrapper[wMaxIdx].tagTripleList[i]);
            }
        }

        /// <summary>
        /// 对一个同花色的3模式牌阵进行解析
        /// </summary>
        /// <param name="vSingleCard"></param>
        /// <param name="vTriple"></param>
        private static void Parse3ModelToTripleList(List<byte> vSingleCard, List<clsParseTriple> vTriple)
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

                            //先加上本次拆串所得顺
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

        #endregion

        #region 牌型解析

        public static bool CheckMengQing(ref clsParseResult parseResult)
        {
            if (!parseResult.isValid)
            {
                return false;
            }

            //没有碰,明杠,不能幺九牌

            //if (parseResult.is7Pair)
            //{
            //    foreach (var card in parseResult.cardAryBy7Pair)
            //    {
            //        if (MahjongGeneralAlgorithm.CheckIs19Card(card))
            //        {
            //            return false;
            //        }
            //    }
            //}
            //else
            //{
            //检查头
            //if (MahjongGeneralAlgorithm.CheckIs19Card(parseResult.normalParse.pair))
            //{
            //    return false;
            //}
            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if ((enTripleType.TripleType_BGang == triple.enTripleType) || (enTripleType.TripleType_MGang == triple.enTripleType)
                || (enTripleType.TripleType_AGang == triple.enTripleType) || (enTripleType.TripleType_Peng == triple.enTripleType))// || triple.have19Card)
                {
                    return false;
                }
            }
            //}

            return true;
        }
        /// <summary>
        /// 断19
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        public static bool CheckDuan19(ref clsParseResult parseResult)
        {
            if (!parseResult.isValid)
            {
                return false;
            }

            //没有碰,明杠,不能幺九牌

            //if (parseResult.is7Pair)
            //{
            //    foreach (var card in parseResult.cardAryBy7Pair)
            //    {
            //        if (MahjongGeneralAlgorithm.CheckIs19Card(card))
            //        {
            //            return false;
            //        }
            //    }
            //}
            //else
            //{
            //检查头
            if (MahjongGeneralAlgorithm.CheckIs19Card(parseResult.normalParse.pair))
            {
                return false;
            }
            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if (triple.have19Card)
                {
                    return false;
                }
            }
            //}

            return true;
        }
        /// <summary>
        /// 解析牌型
        /// </summary>
        /// <param name="parseResult"></param>
        /// <param name="parseFan"></param>
        /// <returns></returns>
        //public static bool ParsePattern(ref clsParseResult parseResult, ref clsBalanceFan parseFan, bool have19Jiang)
        //{
        //    parseFan.Clear();
        //    if (!parseResult.isValid)
        //    {
        //        return false;
        //    }

        //    //默认平胡
        //    parseFan.cardPattern = enMahjongPattern.MahjongPattern_PingHu;

        //    //检查清单调
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_QingDanDiao(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_QingDanDiao;
        //        return true;
        //    }
        //    //检查清七对
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_QingQiDui(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_QingQiDui;
        //        return true;
        //    }
        //    //检查将对
        //    if (have19Jiang && MahjongPatternAlgorithm.CheckMahjongPattern_JiangDui(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_JiangDui;
        //        return true;
        //    }
        //    //检查龙七对
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_LongQiDui(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_LongQiDui;
        //        return true;
        //    }
        //    //检查清大对
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_QingDaDui(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_QingDaDui;
        //        return true;
        //    }
        //    //检查带幺九
        //    if (have19Jiang && MahjongPatternAlgorithm.CheckMahjongPattern_DaiYaoJiu(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_DaiYaoJiu;
        //        return true;
        //    }
        //    //检查小七对
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_XiaoQiDui(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_XiaoQiDui;
        //        return true;
        //    }
        //    //检查清一色
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_QingYiShe(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_QingYiShe;
        //        return true;
        //    }
        //    //检查对对胡
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_DuiDuiHu(ref parseResult))
        //    {
        //        parseFan.cardPattern = enMahjongPattern.MahjongPattern_DuiDuiHu;
        //        return true;
        //    }

        //    return true;
        //}

        #region 具体牌型检查

        /// <summary>
        /// 清单调,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555筒、666筒都是碰掉了，手里剩一张2筒，胡2筒
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_QingDanDiao(ref clsParseResult parseResult)
        {
            //同时满足清一色,大单调
            if (MahjongPatternAlgorithm.CheckMahjongPattern_QingYiShe(ref parseResult) && MahjongPatternAlgorithm.CheckMahjongPattern_DaDanDiao(ref parseResult))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 清七对,手上的牌是清一色的七对。 例：22334466778899条
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_QingQiDui(ref clsParseResult parseResult)
        {
            //同时满足清一色,小七对
            if (MahjongPatternAlgorithm.CheckMahjongPattern_QingYiShe(ref parseResult) && MahjongPatternAlgorithm.CheckMahjongPattern_XiaoQiDui(ref parseResult))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将对,除了一对对牌以外，剩下的都是三张一对的，一共四对。而对牌必须为二、五、八。 例：222555888万55588筒
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_JiangDui(ref clsParseResult parseResult)
        {
            if (!MahjongGeneralAlgorithm.CheckIsJiangCard(parseResult.normalParse.pair))
            {
                return false;
            }

            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if (!triple.isValid)
                {
                    continue;
                }
                if (enTripleType.TripleType_Flash == triple.enTripleType)//不能有顺
                {
                    return false;
                }
                if (!MahjongGeneralAlgorithm.CheckIsJiangCard(triple.cTokenCard))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 龙七对,手牌为暗七对牌型，没有碰过或者杠过，并且有四张牌是一样的，叫龙七对。不再计七对。例：22333366条337788筒
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_LongQiDui(ref clsParseResult parseResult)
        {
            if (parseResult.is7Pair && (MahjongDef.gCardCount_Active == parseResult.cardAryBy7Pair.Count))
            {
                List<byte> handCard = new List<byte>(parseResult.cardAryBy7Pair);
                handCard.Sort();

                for (int i = 0; i < handCard.Count - 3; i++)
                {
                    if (MahjongDef.gInvalidMahjongValue == handCard[i])
                    {
                        return false;
                    }
                    if (handCard[i] == handCard[i + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 清大对,手上的牌是清一色的对对胡。 例： 22233355566699筒
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_QingDaDui(ref clsParseResult parseResult)
        {
            //同时满足清一色,对对胡
            if (MahjongPatternAlgorithm.CheckMahjongPattern_QingYiShe(ref parseResult) && MahjongPatternAlgorithm.CheckMahjongPattern_DuiDuiHu(ref parseResult))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 大单吊,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555条、666条都是碰掉了，手里剩一张2筒或2条，胡2筒或2条
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_DaDanDiao(ref clsParseResult parseResult)
        {
            if (parseResult.is7Pair)
            {
                return false;
            }
            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if (!triple.isValid)
                {
                    continue;
                }
                if ((enTripleType.TripleType_Flash == triple.enTripleType) ||
                    (enTripleType.TripleType_Echo == triple.enTripleType))//不能有顺和刻
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 带幺九,玩家手牌中，全部都是用1的连牌或者9的连牌组成的牌，且麻将也是1,9。 例：111222333筒78999万
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_DaiYaoJiu(ref clsParseResult parseResult)
        {
            if (parseResult.is7Pair)
            {
                return false;
            }
            if (!MahjongGeneralAlgorithm.CheckIs19Card(parseResult.normalParse.pair))
            {
                return false;
            }

            bool bChangeCheck = false;

            //解析后的三元组必须带1或9
            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if (!triple.isValid)
                {
                    continue;
                }
                if (!triple.have19Card)//没有19牌,再去检查是否是7,8,9,1,2,3的刻
                {
                    if (enTripleType.TripleType_Echo == triple.enTripleType)
                    {
                        if ((7 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (8 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (9 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (1 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (2 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (3 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)))
                        {
                            bChangeCheck = true;
                            continue;
                        }
                    }
                    return false;
                }
            }

            //
            if (bChangeCheck == true)
            {
                //解析牌阵时,把111,222,333,解析成了刻,777,888,999,也解析成了刻
                bool[] b123 = new bool[3];
                bool[] b789 = new bool[3];

                b123[0] = b123[1] = b123[2] = false;
                b789[0] = b789[1] = b789[2] = false;

                List<byte> b123Triple = new List<byte>();
                List<byte> b789Triple = new List<byte>();

                b123Triple.Clear();
                b789Triple.Clear();

                foreach (var triple in parseResult.normalParse.triplyAry)
                {
                    if (!triple.isValid)
                    {
                        continue;
                    }
                    if (enTripleType.TripleType_Echo == triple.enTripleType)
                    {
                        if ((1 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (2 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                           (3 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)))
                        {
                            b123[MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard) - 1] = true;
                            b123Triple.Add(triple.cTokenCard);

                            continue;
                        }

                        if ((7 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                            (8 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                            (9 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)))
                        {
                            b789[MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard) - 7] = true;
                            b789Triple.Add(triple.cTokenCard);

                            continue;
                        }
                    }
                }

                //如果满足123或789就再重新检查一遍
                if ((b123[0] && b123[1] && b123[2]) || (b789[0] && b789[1] && b789[2]))
                {
                    foreach (var triple in parseResult.normalParse.triplyAry)
                    {
                        if (!triple.isValid)
                        {
                            continue;
                        }
                        if (!triple.have19Card)//没有19牌
                        {
                            //有123刻,且这个就是123中的一个
                            if ((b123[0] && b123[1] && b123[2]) &&
                                ((1 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                                 (2 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                                 (3 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard))))
                            {
                                if ((MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[0]) != MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[1])) ||
                                   (MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[0]) != MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[2])) ||
                                   (MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[1]) != MahjongGeneralAlgorithm.GetMahjongColor(b123Triple[2])))
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            //有789刻,且这个就是789中的一个
                            if ((b789[0] && b789[1] && b789[2]) &&
                                ((7 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                                 (8 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard)) ||
                                 (9 == MahjongGeneralAlgorithm.GetMahjongValue(triple.cTokenCard))))
                            {
                                if ((MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[0]) != MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[1])) ||
                                    (MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[0]) != MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[2])) ||
                                    (MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[1]) != MahjongGeneralAlgorithm.GetMahjongColor(b789Triple[2])))
                                {
                                    return false;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            return false;

                        }
                    }
                }
                else
                {
                    foreach (var triple in parseResult.normalParse.triplyAry)
                    {
                        if (!triple.isValid)
                        {
                            continue;
                        }
                        if (!triple.have19Card)//没有19牌,再去检查是否是7,8,9,1,2,3的刻
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 小七对,手牌全部是两张一对的，没有碰过和杠过 例：11335566条224466筒
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_XiaoQiDui(ref clsParseResult parseResult)
        {
            return parseResult.is7Pair;
        }
        /// <summary>
        /// 清一色,胡牌的手牌全部都是一门花色。 例：11122233345688筒。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_QingYiShe(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);

            if (parseResult.is7Pair)
            {
                foreach (var card in parseResult.cardAryBy7Pair)
                {
                    color[MahjongGeneralAlgorithm.GetMahjongColor(card)] = 1;
                }
            }
            else
            {
                foreach (var card in parseResult.normalParse.activeCard)
                {
                    color[MahjongGeneralAlgorithm.GetMahjongColor(card)] = 1;
                }
            }

            if (1 == (color[0] + color[1] + color[2] + color[3]))
            {
                return true;
            }

            return false;
        }



        #endregion

        #endregion

        #region 淮北麻将
        /// <summary>
        /// 牌型解析，parseResult
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        //public static bool ParsePatternForWWMJ(ref clsParseResult parseResult, ref clsBalanceFan parseFan)
        //{
        //    if (!parseResult.isValid)
        //    {
        //        return false;
        //    }

        //    //压单，在外面算
        //    //缺一门
        //    if (CheckQueYiMen(ref parseResult))
        //    {
        //        parseFan.QueYiMen = true;
        //        parseFan.ZuiZi++;
        //    }
        //    //八支
        //    parseFan.BaZhi = MahjongPatternAlgorithm.CheckZhi(ref parseResult);
        //    parseFan.ZuiZi += parseFan.BaZhi;
        //    //四核
        //    parseFan.SiHe = CheckSiHe(ref parseResult);
        //    parseFan.ZuiZi += parseFan.SiHe;
        //    //门清
        //    if (MahjongPatternAlgorithm.CheckMengQing(ref parseResult))
        //    {
        //        parseFan.MenQing = true;
        //        parseFan.ZuiZi++;
        //    }
        //    //断19
        //    if (MahjongPatternAlgorithm.CheckDuan19(ref parseResult))
        //    {
        //        parseFan.Duan19 = true;
        //        parseFan.ZuiZi++;
        //    }
        //    //顶龙
        //    if (MahjongPatternAlgorithm.CheckDingLong(ref parseResult))
        //    {
        //        parseFan.DingLong = true;
        //        parseFan.ZuiZi++;
        //    }


        //    //对对胡
        //    if (MahjongPatternAlgorithm.CheckMahjongPattern_DuiDuiHu(ref parseResult))
        //    {
        //        parseFan.DuiDuiHu = true;
        //        parseFan.XiaoYangZi += 5;
        //    }
        //    //全老
        //    if (CheckQuanLao(ref parseResult))
        //    {
        //        parseFan.QuanLao = true;
        //        parseFan.XiaoYangZi += 5;
        //    }
        //    //全小
        //    if (CheckQuanXiao(ref parseResult))
        //    {
        //        parseFan.QuanXiao = true;
        //        parseFan.XiaoYangZi += 5;
        //    }
        //    //全19
        //    if (CheckQuan19(ref parseResult))
        //    {
        //        parseFan.Quan19 = true;
        //        parseFan.XiaoYangZi += 5;
        //    }
        //    ////混一色
        //    //if (MahjongPatternAlgorithm.CheckHunYiSe(ref parseResult))
        //    //{
        //    //    parseFan.HunYiSe = 1;
        //    //    parseFan.ZuiZi++;
        //    //}
        //    //清一色
        //    if (MahjongPatternAlgorithm.CheckQingYiSe(ref parseResult))
        //    {
        //        parseFan.QingYiSe = true;
        //        parseFan.DaYangZi += 10;
        //    }

        //    //通,6+8怎么算
        //    parseFan.Tong = MahjongPatternAlgorithm.CheckTong(ref parseResult);

        //    return true;
        //}
        #region 具体嘴数检查
        /// <summary>
        /// 算支，一门牌达到8张叫做够支，+1嘴。多一张叫两支，+2嘴。以此类推。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanZhi(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            List<byte> vWan = new List<byte>();
            List<byte> vTong = new List<byte>();
            List<byte> vTiao = new List<byte>();
            List<byte> vZhi = new List<byte>();
            MahjongGeneralAlgorithm.SpiltHandCardByCardColor(allCard, vWan, vTong, vTiao, vZhi);
            //只有万桶条
            if (vWan.Count > 7)
                score += vWan.Count - 7;
            if (vTong.Count > 7)
                score += vTong.Count - 7;
            if (vTiao.Count > 7)
                score += vTiao.Count - 7;
            return score;
        }
        /// <summary>
        /// 缺门，胡牌时所有牌只存在有2门花色。+1嘴 ，清一色缺2门。+2嘴。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_QueMen(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            List<byte> vWan = new List<byte>();
            List<byte> vTong = new List<byte>();
            List<byte> vTiao = new List<byte>();
            List<byte> vZhi = new List<byte>();
            MahjongGeneralAlgorithm.SpiltHandCardByCardColor(allCard, vWan, vTong, vTiao, vZhi);
            //只有万桶条
            if (vWan.Count == 0)
                score++;
            if (vTong.Count == 0)
                score++;
            if (vTiao.Count == 0)
                score++;
            return score;
        }
        /// <summary>
        /// 算同，所有牌中数字一样的牌从5张起数，+1嘴 每多一张多+1嘴。例如3 张四万，2 张四条、 3 张四饼一共有8张同，+4嘴
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanTong(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            int[] EachvalueN = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var VARIABLE in allCard)
            {
                EachvalueN[MahjongGeneralAlgorithm.GetMahjongValue(VARIABLE)]++;
            }
            for (int i = 2; i < 9; i++)
            {
                score += EachvalueN[i] > 4 ? EachvalueN[i] - 4 : 0;
            }
            return score;
        }
        /// <summary>
        /// 算坎，（就是找刻）三张一样的牌在手，三张牌未分开叫做一坎（手上有3张1万，一个2万，一个3万，没有4万，胡牌时，3个1万不能算作一坎），每一坎+1嘴。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanKan(ref clsParseResult parseResult)
        {
            int score = 0;
            foreach (var VARIABLE in parseResult.normalParse.triplyAry)
            {
                if (VARIABLE.enTripleType == enTripleType.TripleType_Echo)
                    score++;
            }
            return score > 0 ? score - CheckMahjongPattern_SuanHuo(ref parseResult) : 0;
        }
        /// <summary>
        /// 算暗杠。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanAnGang(ref clsParseResult parseResult)
        {
            int score = 0;
            foreach (var VARIABLE in parseResult.normalParse.triplyAry)
            {
                if (VARIABLE.enTripleType == enTripleType.TripleType_AGang)
                    score += 1;
            }
            return score;
        }
        /// <summary>
        /// 算明杠。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanMingGang(ref clsParseResult parseResult)
        {
            int score = 0;
            foreach (var VARIABLE in parseResult.normalParse.triplyAry)
            {
                if (VARIABLE.enTripleType == enTripleType.TripleType_MGang || VARIABLE.enTripleType == enTripleType.TripleType_BGang)
                    score += 1;
            }
            return score;
        }
        /// <summary>
        /// 算活，手上有四张一样的牌，没有开杠就算活。+1嘴  先去暗杠，再找4个
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanHuo(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            foreach (var VARIABLE in parseResult.normalParse.triplyAry)
            {
                if (VARIABLE.enTripleType == enTripleType.TripleType_AGang || VARIABLE.enTripleType == enTripleType.TripleType_BGang || VARIABLE.enTripleType == enTripleType.TripleType_MGang)
                {
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                }
                if (VARIABLE.enTripleType == enTripleType.TripleType_Peng)
                {
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                    allCard.Remove(VARIABLE.cTokenCard);
                }
            }
            allCard.Sort();
            for (int i = 0; i < allCard.Count - 3; i++)
            {
                if (allCard[i] == allCard[i + 3])
                    score++;
            }
            return score;
        }
        /// <summary>
        /// 算卡，胡牌只胡一张算卡。例如：手上有1万和3万胡2万算卡，手上有7万和8万胡6万算卡，手上有1万和2万胡3万算卡，手上有2万和3万，1万被打完了只胡4万这个不算卡。只从顺找
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanKa(ref clsParseResult parseResult)
        {
            //还原手牌，再找听牌组，听牌组数量为1就是卡
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
                return 1;
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            allCard.Remove(parseResult.huCard);
            foreach (var VARIABLE in parseResult.normalParse.triplyAry)
            {
                if (VARIABLE.enTripleType == enTripleType.TripleType_AGang || VARIABLE.enTripleType == enTripleType.TripleType_BGang || VARIABLE.enTripleType == enTripleType.TripleType_MGang)
                {
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                }
                if (VARIABLE.enTripleType == enTripleType.TripleType_Peng)
                {
                    allCard.Remove(VARIABLE.cTokenCard); allCard.Remove(VARIABLE.cTokenCard);
                    allCard.Remove(VARIABLE.cTokenCard);
                }
            }
            allCard.Sort();
            List<byte> tingCard = new List<byte>();
            MahjongGeneralAlgorithm.CheckIfCanTingCardArray(allCard, tingCard);
            if (tingCard.Count == 1)
                return 1;
            return score;
        }
        /// <summary>
        /// 大三元：胡牌的时候手上有4个三张加一对。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_DaSanYuan(ref clsParseResult parseResult)
        {
            int score = 0;
            //分是否是七对
            if (!parseResult.is7Pair)
            {
                int n = 0;
                foreach (var VARIABLE in parseResult.normalParse.triplyAry)
                {
                    n += VARIABLE.enTripleType == enTripleType.TripleType_Echo ? 1 : 0;
                }
                if (n == 4)
                    return 1;
            }
            return score;
        }

        /// <summary>
        /// 算双普，胡牌只胡一张算卡。例如：手上有1万和3万胡2万算卡，手上有7万和8万胡6万算卡，手上有1万和2万胡3万算卡，手上有2万和3万，1万被打完了只胡4万这个不算卡。只从顺找
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_SuanShuangPu(int baseScore, ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            //分是否是七对
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
                allCard.Sort();
                List<byte> vWan = new List<byte>();
                List<byte> vTong = new List<byte>();
                List<byte> vTiao = new List<byte>();
                List<byte> vZhi = new List<byte>();
                MahjongGeneralAlgorithm.SpiltHandCardByCardColor(allCard, vWan, vTong, vTiao, vZhi);
                score += getShuangPu(vWan);
                score += getShuangPu(vTong);
                score += getShuangPu(vTiao);
                score *= baseScore / 2;
            }
            else/////////非七对333444555情况双普与坎有冲突
            {
                //找到所有的顺
                List<clsParseTriple> tempFlashTriples = new List<clsParseTriple>();
                foreach (var VARIABLE in parseResult.normalParse.triplyAry)
                {
                    if (VARIABLE.enTripleType == enTripleType.TripleType_Flash)
                    {
                        tempFlashTriples.Add(VARIABLE);
                    }
                }
                //只可能有两组相同的顺 4组是7对
                if (tempFlashTriples.Count > 1)
                {
                    for (int i = 0; i < tempFlashTriples.Count - 1; i++)
                    {
                        for (int j = i + 1; j < tempFlashTriples.Count; j++)
                        {
                            if (tempFlashTriples[i].cTokenCard == tempFlashTriples[j].cTokenCard)
                                return baseScore / 2;
                        }
                    }
                }
            }
            return score;
        }
        /// <summary>
        /// 单色找双普
        /// </summary>
        /// <param name="allCard"></param>
        /// <returns></returns>
        private static int getShuangPu(List<byte> srcAry)
        {
            int score = 0;
            List<byte> allCard = new List<byte>(srcAry);


            List<int> EachvalueN = new List<int>();
            for (var i = 0; i < 10; i++)
                EachvalueN.Add(0);
            for (int i = 0; i < allCard.Count; i++)
            {
                EachvalueN[MahjongGeneralAlgorithm.GetMahjongValue(allCard[i])]++;
            }

            if (allCard.Count > 5)
            {
                for (int i = 2; i < 7; i++)
                {
                    if (EachvalueN[i] > 1 && EachvalueN[i + 1] > 1 && EachvalueN[i + 2] > 1)
                    {
                        EachvalueN[i] -= 2; EachvalueN[i + 1] -= 2; EachvalueN[i + 2] -= 2;
                        score++;
                        i = 1;
                    }
                }
            }

            return score;
        }
        /// <summary>
        /// 算258，开牌数数字为2，5，8的牌有多少张，五张+1嘴。六张+2嘴，依次类推。
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckMahjongPattern_Suan258(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            int[] EachvalueN = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var VARIABLE in allCard)
            {
                EachvalueN[MahjongGeneralAlgorithm.GetMahjongValue(VARIABLE)]++;
            }

            score += EachvalueN[2] + EachvalueN[5] + EachvalueN[8] > 4 ? EachvalueN[2] + EachvalueN[5] + EachvalueN[8] - 4 : 0;

            return score;
        }
        #endregion


        #region 麻将具体算嘴子,支数
        /// <summary>
        /// 支数，取最大的
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckZhi(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);
            int max = 0;
            //没七对
            foreach (var card in parseResult.normalParse.activeCard)
            {
                color[MahjongGeneralAlgorithm.GetMahjongColor(card)]++;
            }
            if (color[0] >= color[1] && color[0] >= color[2])
            {
                max = color[0];
            }
            if (color[1] >= color[0] && color[1] >= color[2])
            {
                max = color[1];
            }
            if (color[2] >= color[1] && color[2] >= color[0])
            {
                max = color[2];
            }
            if (max < 8)
            {
                return 0;
            }
            else if (max >= 11)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 混一色检查
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckHunYiSe(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);
            //没七对
            foreach (var card in parseResult.normalParse.activeCard)
            {
                color[MahjongGeneralAlgorithm.GetMahjongColor(card)] = 1;
            }
            if ((1 == (color[0] + color[1] + color[2]) && 1 == color[3]))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 清一色
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckQingYiSe(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);
            foreach (var card in parseResult.normalParse.activeCard)
            {
                color[MahjongGeneralAlgorithm.GetMahjongColor(card)] = 1;
            }

            if (1 == (color[0] + color[1] + color[2] + color[3]))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 缺一门
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckQueYiMen(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);
            foreach (var card in parseResult.normalParse.activeCard)
            {
                color[MahjongGeneralAlgorithm.GetMahjongColor(card)] = 1;
            }

            if (2 == color[0] + color[1] + color[2])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 顶龙，同色三连顺
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckDingLong(ref clsParseResult parseResult)
        {
            List<byte> shun = new List<byte>();

            foreach (var triply in parseResult.normalParse.triplyAry)
            {
                if (triply.enTripleType == enTripleType.TripleType_Flash)
                {
                    if (!shun.Contains(triply.cTokenCard))
                        shun.Add(triply.cTokenCard);
                }
            }
            shun.Sort();
            if (shun.Count > 2)
            {
                for (int i = 0; i < shun.Count - 2; i++)
                {
                    if (shun[i + 2] - shun[i + 1] == 3 && shun[i + 1] - shun[i] == 3)
                        return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 四核，首先有四张，然后这些牌必须在碰或刻中
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckSiHe(ref clsParseResult parseResult)
        {
            List<byte> allcard = new List<byte>(parseResult.normalParse.activeCard);
            allcard.Sort();
            List<byte> sizhan = new List<byte>();
            int sihe = 0;
            for (int i = 0; i < allcard.Count - 3; i++)
            {
                if (allcard[i] == allcard[i + 3])
                {
                    sizhan.Add(allcard[i]);
                    i += 3;
                }
            }
            foreach (var triply in parseResult.normalParse.triplyAry)
            {
                if (triply.enTripleType == enTripleType.TripleType_Peng || triply.enTripleType == enTripleType.TripleType_Echo)
                {
                    if (sizhan.Contains(triply.cTokenCard))
                        sihe++;
                }
            }
            return sihe;
        }
        /// <summary>
        /// 对对胡
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckMahjongPattern_DuiDuiHu(ref clsParseResult parseResult)
        {
            if (parseResult.is7Pair)
            {
                return false;
            }
            foreach (var triple in parseResult.normalParse.triplyAry)
            {
                if (!triple.isValid)
                {
                    continue;
                }
                if (enTripleType.TripleType_Flash == triple.enTripleType)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 全老，算有牌>5
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckQuanLao(ref clsParseResult parseResult)
        {

            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }

            foreach (var VARIABLE in allCard)
            {
                if (MahjongGeneralAlgorithm.GetMahjongColor(VARIABLE) != 3 &&
                    MahjongGeneralAlgorithm.GetMahjongValue(VARIABLE) < 5)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 全小，算有牌>5
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckQuanXiao(ref clsParseResult parseResult)
        {

            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }

            foreach (var VARIABLE in allCard)
            {
                if (MahjongGeneralAlgorithm.GetMahjongColor(VARIABLE) != 3 &&
                    MahjongGeneralAlgorithm.GetMahjongValue(VARIABLE) > 5)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 全19，
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckQuan19(ref clsParseResult parseResult)
        {

            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }

            foreach (var VARIABLE in allCard)
            {
                if (!MahjongGeneralAlgorithm.CheckIs19Card(VARIABLE))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 算同，所有牌中数字一样的牌从5张起数，+1嘴 每多一张多+1嘴。例如3 张四万，2 张四条、 3 张四饼一共有8张同，+4嘴
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static int CheckTong(ref clsParseResult parseResult)
        {
            int score = 0;
            List<byte> allCard = new List<byte>();
            if (parseResult.is7Pair)
            {
                allCard.AddRange(parseResult.cardAryBy7Pair);
            }
            else
            {
                allCard.AddRange(parseResult.normalParse.activeCard);
            }
            int[] EachvalueN = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var VARIABLE in allCard)
            {
                if (MahjongGeneralAlgorithm.GetMahjongColor(VARIABLE) != 3)
                    EachvalueN[MahjongGeneralAlgorithm.GetMahjongValue(VARIABLE)]++;
            }
            for (int i = 1; i < 10; i++)
            {
                //这里还有问题
                score += EachvalueN[i] > 4 ? EachvalueN[i] - 4 : 0;
            }
            return score;
        }
        /// <summary>
        /// 双八只检查，不是双同色杠+8张算法，//可能有问题
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        private static bool CheckShuangBaZhi(ref clsParseResult parseResult)
        {
            List<byte> color = new List<byte>();
            color.Add(0);
            color.Add(0);
            color.Add(0);
            color.Add(0);
            //没七对
            foreach (var card in parseResult.normalParse.activeCard)
            {
                color[MahjongGeneralAlgorithm.GetMahjongColor(card)]++;
            }
            if ((color[0] >= 8 && color[1] >= 8) ||
                (color[0] >= 8 && color[2] >= 8) ||
                (color[2] >= 8 && color[1] >= 8))
            {
                return true;
            }
            return false;
        }
        #endregion
        #endregion
    }
}
