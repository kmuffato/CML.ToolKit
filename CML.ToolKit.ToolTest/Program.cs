﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CML.ToolKit.ToolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Type> testClassTypes = Assembly.GetExecutingAssembly().GetTypes().ToList();

            for (int i = testClassTypes.Count - 1; i >= 0; i--)
            {
                if (!testClassTypes[i].IsSubclassOf(typeof(ToolKitTestBase)))
                {
                    testClassTypes.Remove(testClassTypes[i]);
                }
            }

            if (testClassTypes.Count == 0)
            {
                Console.WriteLine("测试类为空，请先编写测试类！");
            }
            else if (args.Length == 1 && int.TryParse(args[0], out int index) && index >= 1 && index <= testClassTypes.Count)
            {
                ToolKitTestBase toolKitTest = (ToolKitTestBase)Activator.CreateInstance(testClassTypes[index - 1], true);
                toolKitTest.GetVersionInfo();
                toolKitTest.ExecuteTest();
                Console.WriteLine($"[{toolKitTest.TestClassName}]测试结束！\n");
            }
            else
            {
                for (int i = 0; i < testClassTypes.Count; i++)
                {
                    ToolKitTestBase toolKitTest = (ToolKitTestBase)Activator.CreateInstance(testClassTypes[i], true);
                    Console.WriteLine($"[{i + 1}]{toolKitTest.TestClassName}");
                }
                Console.WriteLine("[C]清空界面");
                Console.WriteLine("[M]显示菜单");
                Console.WriteLine("[Q]退出测试\n");

                while (true)
                {
                    Console.Write("请选择: ");
                    string cmd = Console.ReadLine();

                    if (cmd.ToUpper() == "Q")
                    {
                        break;
                    }
                    else if (cmd.ToUpper() == "C" || cmd.ToUpper() == "M")
                    {
                        if (cmd.ToUpper() == "C")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("");
                        }

                        for (int i = 0; i < testClassTypes.Count; i++)
                        {
                            ToolKitTestBase toolKitTest = (ToolKitTestBase)Activator.CreateInstance(testClassTypes[i], true);
                            Console.WriteLine($"[{i + 1}]{toolKitTest.TestClassName}");
                        }
                        Console.WriteLine("[C]清空界面");
                        Console.WriteLine("[M]显示菜单");
                        Console.WriteLine("[Q]退出测试\n");
                    }
                    else if (!int.TryParse(cmd, out index) || index < 1 || index > testClassTypes.Count)
                    {
                        Console.WriteLine("输入命令错误！\n");
                    }
                    else
                    {
                        ToolKitTestBase toolKitTest = (ToolKitTestBase)Activator.CreateInstance(testClassTypes[index - 1], true);
                        toolKitTest.GetVersionInfo();
                        toolKitTest.ExecuteTest();
                        Console.WriteLine($"[{toolKitTest.TestClassName}]测试结束！\n");
                    }
                }
            }
        }
    }
}
