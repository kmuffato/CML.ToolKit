﻿using System.Reflection;

namespace CML.CommonEx.SingletonEx
{
    /// <summary>
    /// 常用工具包单实例工具版本信息
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
        public override string VerDate => "2019年7月3日 14:05";
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
            string filePath = "CML.CommonEx.FuncSingleton.AssiVersion.UpdateInfo.LOG";
            return base.GetVersionInfo(filePath);
        }
        #endregion
    }
}
