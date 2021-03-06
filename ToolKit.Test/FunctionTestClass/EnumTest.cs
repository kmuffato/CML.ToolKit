﻿using CML.CommonEx.EnumEx;
using CML.CommonEx.EnumEx.ExFunction;
using System.ComponentModel;

namespace ToolKit.Test
{
    /// <summary>
    /// 枚举操作测试类
    /// </summary>
    internal class EnumTest : ToolKitTestBase
    {
        /// <summary>
        /// 测试类名
        /// </summary>
        public override string TestClassName => "EnumTest";

        /// <summary>
        /// 版本信息
        /// </summary>
        public override void CF_GetVersionInfo()
        {
            PrintMsgLn(MsgType.Success, "⊙日志信息⊙");
            PrintMsgLn(MsgType.Info, new VersionInfo().CF_GetVersionInfo());
        }

        /// <summary>
        /// 执行测试
        /// </summary>
        public override void ExecuteTest()
        {
            PrintLogLn(MsgType.Info, "枚举数值: " + ETest.EnumTestItem.CF_ToNumber());
            PrintLogLn(MsgType.Info, "枚举字符串: " + ETest.EnumTestItem.CF_ToString());
            PrintLogLn(MsgType.Info, "枚举描述信息: " + ETest.EnumTestItem.CF_GetDescription());
        }

        private enum ETest
        {
            [Description("枚举测试")]
            EnumTestItem
        }
    }
}
