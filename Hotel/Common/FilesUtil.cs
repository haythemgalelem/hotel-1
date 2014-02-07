using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;   

namespace Common
{
    /// <summary>
    /// 模块：
    /// 作用：文件上传、下载操作类
    /// 作者：phq
    /// 日期： 
    /// 说明：
    public class FilesUtil
    {
        /// <summary>
        /// 异步上传文件（带进度条）
        /// </summary>
        /// <param name="webClient"></param> 
        /// <param name="fileNamePath">文件名，全路径格式</param>   
        /// <param name="urlString">服务器文件夹路径</param>   
        /// <param name="fileName">上传后的新文件名（不带扩展名）</param>  
        /// <returns></returns>
        public static bool UploadDataAsync(WebClient client, string fileNamePath, string urlString, string newFileName)
        {
            string fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\") + 1);//原文件名
            string fileNameExt = Path.GetExtension(fileNamePath);//扩展名//文件扩展名
            if (urlString.EndsWith("/") == false)
            {
                urlString = urlString + "/";
            }
            string uploadFilePath = urlString + newFileName + fileNameExt; //上传文件的目标地址 
            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            FileStream fStream = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            byte[] dataByte = new byte[fStream.Length];
            fStream.Read(dataByte, 0, dataByte.Length);        //写到2进制数组中
            fStream.Close();
            Uri uri = new Uri(uploadFilePath);
            client.UploadDataAsync(uri, "PUT", dataByte, dataByte);
            return true;
        }
        /// <summary>
        /// 异步下载文件
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fileServerURL">远程服务器文件url</param>
        /// <param name="newFilePath">下载后的文件路径(包含文件名、扩展名)</param>
        /// <returns></returns>
        public static bool DownloadDataAsync(WebClient client, string fileServerURL, string newFilePath)
        {
            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            Uri uri = new Uri(fileServerURL);
            client.DownloadFileAsync(uri, newFilePath);
            return true;
        }
    }
}
