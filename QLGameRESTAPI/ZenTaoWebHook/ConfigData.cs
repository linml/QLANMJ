/***************************************************************************
 * 
 * 创建时间：   2017/12/6 14:41:07
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

namespace ZenTaoWebHook
{
    /// <summary>
    /// 类ConfigData的注释信息
    /// </summary>
    public class ConfigData:QL.Tools.AppConfigBase<ConfigData>
    {

        public string MysqlConstr = "Server=127.0.0.1;port=3300;Database=zentao;Uid=root;Pwd=deCFGj>Es6z";
        public string HookUrl = "https://oapi.dingtalk.com/robot/send?access_token={0}";
        public int WebPort = 18900;
         
    }
}
