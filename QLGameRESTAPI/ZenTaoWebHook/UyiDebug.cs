/***************************************************************************
 * 
 * 创建时间：   2017/12/12 15:36:46
 * 创建人员：   沈瑞
 * CLR版本号：  4.0.30319.42000
 * 备注信息：   未填写备注信息
 * 
 * *************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL;

namespace ZenTaoWebHook
{
    /// <summary>
    /// 类UyiDebug的注释信息
    /// </summary>
    internal class UyiDebug: QL.QLDebugBase<UyiDebug>
    {
        protected override string ServerName => "ZenTaoWebHook";

        public override void OnPrintError(Exception err, Stream stream = null, string fname = null, string[] emils = null)
        {

        }

        public override void OnShowMsg(string msg, ShowMsgColor color)
        { 
        }
    }
}
