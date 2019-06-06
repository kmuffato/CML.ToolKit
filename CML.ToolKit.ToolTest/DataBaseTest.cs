﻿using CML.ToolKit.DataBaseEx;
using System;

namespace CML.ToolKit.ToolTest
{
    /// <summary>
    /// Socket客户端测试类
    /// </summary>
    class DataBaseTest : ToolKitTestBase
    {
        /// <summary>
        /// 测试类名
        /// </summary>
        public override string TestClassName => "DataBaseTest";

        /// <summary>
        /// 执行测试
        /// </summary>
        public override void ExecuteTest()
        {
            DataBase dataBase = new DataBase()
            {
                CP_ConnectionType = EDataBaseType.ORACLE,
                CP_ConnectionString = "DATA SOURCE=192.168.20.15:1521/orcl; User ID=SCOTT; Password=123456;"
            };

            try
            {
                dataBase.CF_InitDataBase();
                object count = dataBase.CF_GetSingleObject("SELECT COUNT(*) FROM T_AGING_RESULT_INFO");
                PrintLn(MsgType.INFO, $"一共有{count}组老化数据！");
            }
            catch (Exception ex)
            {
                PrintLn(MsgType.ERROR, ex.Message);
            }
        }
    }
}
