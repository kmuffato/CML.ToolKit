﻿using System.Reflection;

namespace CML.CommonEx.NetworkEx
{
    /// <summary>
    /// 常用工具包网络操作工具版本信息
    /// </summary>
    public class VersionInfo : VersionEx.VersionBase
    {
        #region 版本信息
        /// <summary>
        /// 主版本号
        /// </summary>
        public override string VerMain => "1.0";
        /// <summary>
        /// 研发版本号
        /// </summary>
        public override string VerDev => "19Y001R001";
        /// <summary>
        /// 更新时间
        /// </summary>
        public override string VerDate => "2019年07月04日 14:30";
        /// <summary>
        /// 当前程序集 
        /// </summary>
        protected override Assembly RunAssembly => Assembly.GetExecutingAssembly();
        #endregion

        #region 公共方法
        /// <summary>
        /// 获得版本信息
        /// </summary>
        /// <returns>版本信息</returns>
        public string GetVersionInfo()
        {
            string filePath = "CML.CommonEx.FuncNetwork.AssiVersion.UpdateInfo.LOG";
            return base.GetVersionInfo(filePath);
        }
        #endregion
    }
}
