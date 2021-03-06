﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace CML.CommonEx.EncodeEx
{
    /// <summary>
    /// 3DES加密解密操作类
    /// </summary>
    public class DESTripleEncrypt
    {
        /// <summary>
        /// 3DES加密文件
        /// </summary>
        /// <param name="desPara">3DES加密参数</param>
        /// <param name="inFilePath">待加密文件路径</param>
        /// <param name="outFilePath">[OUT]已加密文件存储路径</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_EncryptFile(ModDESTripleParameter desPara, string inFilePath, string outFilePath, out string errMsg)
        {
            bool result;

            try
            {
                byte[] bts = File.ReadAllBytes(inFilePath);
                if (CF_EncryptBytes(desPara, bts, out byte[] outBytes, out errMsg))
                {
                    File.WriteAllBytes(outFilePath, outBytes);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 3DES解密文件
        /// </summary>
        /// <param name="desPara">3DES解密参数</param>
        /// <param name="inFilePath">待解密文件路径</param>
        /// <param name="outFilePath">[OUT]已解密文件存储路径</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_DecryptFile(ModDESTripleParameter desPara, string inFilePath, string outFilePath, out string errMsg)
        {
            bool result;

            try
            {
                byte[] bts = File.ReadAllBytes(inFilePath);
                if (CF_DecryptBytes(desPara, bts, out byte[] outBytes, out errMsg))
                {
                    File.WriteAllBytes(outFilePath, outBytes);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 3DES加密字符串
        /// </summary>
        /// <param name="desPara">3DES加密参数</param>
        /// <param name="inString">待加密字符串</param>
        /// <param name="outString">[OUT]已加密字符串</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_EncryptString(ModDESTripleParameter desPara, string inString, out string outString, out string errMsg)
        {
            bool result;

            try
            {
                byte[] bts = desPara.Encode.GetBytes(inString);
                if (CF_EncryptBytes(desPara, bts, out byte[] outBytes, out errMsg))
                {
                    outString = Convert.ToBase64String(outBytes);
                    result = true;
                }
                else
                {
                    outString = "";
                    result = false;
                }
            }
            catch (Exception ex)
            {
                outString = "";
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 3DES解密字符串
        /// </summary>
        /// <param name="desPara">3DES解密参数</param>
        /// <param name="inString">待解密字符串</param>
        /// <param name="outString">[OUT]已解密字符串</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_DecryptString(ModDESTripleParameter desPara, string inString, out string outString, out string errMsg)
        {
            bool result;

            try
            {
                byte[] bts = Convert.FromBase64String(inString);
                if (CF_DecryptBytes(desPara, bts, out byte[] outBytes, out errMsg))
                {
                    outString = desPara.Encode.GetString(outBytes);
                    result = true;
                }
                else
                {
                    outString = "";
                    result = false;
                }
            }
            catch (Exception ex)
            {
                outString = "";
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 3DES加密字节数组
        /// </summary>
        /// <param name="desPara">3DES加密参数</param>
        /// <param name="inBytes">待加密字节数组</param>
        /// <param name="outBytes">[OUT]已加密字节数组</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_EncryptBytes(ModDESTripleParameter desPara, byte[] inBytes, out byte[] outBytes, out string errMsg)
        {
            bool result;

            try
            {
                using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider
                {
                    Mode = desPara.CipherMode.Convert(),
                    Padding = desPara.PaddingMode.Convert(),
                })
                {
                    des.Key = desPara.Encode.GetBytes(desPara.Key);
                    des.IV = desPara.Encode.GetBytes(desPara.IV);

                    using (ICryptoTransform ct = des.CreateEncryptor())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                            {
                                cs.Write(inBytes, 0, inBytes.Length);
                                cs.FlushFinalBlock();
                            }

                            outBytes = ms.ToArray();
                        }
                    }
                }

                errMsg = "";
                result = true;
            }
            catch (Exception ex)
            {
                outBytes = null;
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 3DES解密字节数组
        /// </summary>
        /// <param name="desPara">3DES解密参数</param>
        /// <param name="inBytes">待解密字节数组</param>
        /// <param name="outBytes">[OUT]已解密字节数组</param>
        /// <param name="errMsg">[OUT]错误信息</param>
        /// <returns>执行结果</returns>
        public static bool CF_DecryptBytes(ModDESTripleParameter desPara, byte[] inBytes, out byte[] outBytes, out string errMsg)
        {
            bool result;

            try
            {
                using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider
                {
                    Mode = desPara.CipherMode.Convert(),
                    Padding = desPara.PaddingMode.Convert(),
                })
                {
                    des.Key = desPara.Encode.GetBytes(desPara.Key);
                    des.IV = desPara.Encode.GetBytes(desPara.IV);

                    using (ICryptoTransform ct = des.CreateDecryptor())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                            {
                                cs.Write(inBytes, 0, inBytes.Length);
                                cs.FlushFinalBlock();
                            }

                            outBytes = ms.ToArray();
                        }
                    }
                }

                errMsg = "";
                result = true;
            }
            catch (Exception ex)
            {
                outBytes = null;
                errMsg = ex.Message;
                result = false;
            }

            return result;
        }
    }
}
