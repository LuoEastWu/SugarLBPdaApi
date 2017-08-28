using Sodao.FastSocket.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace Common
{
    /// <summary>
    /// 服务器提供的中间件连接通信类
    /// </summary>
    public static class FastSocket
    {
        #region 消息处理模块
        /// <summary>
        /// 系统推送消息委托
        /// </summary>
        /// <param name="Cmdname"></param>
        /// <param name="SeqID"></param>
        /// <param name="data"></param>
        public delegate void Messagedelegate(int ID, string Cmdname, int SeqID, byte[] data);
        /// <summary>
        /// 当前客户端模式[True]系统自带的客户端[False]改写后的客户端
        /// </summary>
        public static bool FastSocketCode = true;
        /// <summary>
        /// 消息弹窗界面风格
        /// </summary>
        public static int MagCode = 1;
        /// <summary>
        /// 收到服务器消息事件
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="e"></param>
        public static void OnMessaged(int ID, string Cmdname, int SeqID, byte[] data)
        {
            return;
        }
        /// <summary>
        /// 线程处理消息
        /// </summary>
        /// <param name="Mag"></param>
        public static void Massage_On(object Mag)
        {
            MassgeClass mag = (MassgeClass)Mag;
            if (mag.Mags_Type == "Money")
            {
                return;
            }
        }
        /// <summary>
        /// 消息弹窗关闭按钮点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        private static void CloseClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("Closed was Clicked");
        }
        /// <summary>
        /// 消息弹窗标题点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        private static void TitleClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("Title was Clicked");
        }
        /// <summary>
        /// 消息弹窗内容点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        private static void ContentClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("Content was Clicked");
        }
        #endregion
        #region 服务器通信模块
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static string get_localip(bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.get_localip(Show) : FastSocket_Rcominfo.GetLocalIp();
        }
     
      
     
        /// <summary>
        /// 向服务器发送当前标示
        /// </summary>
        /// <param name="userdata"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool BingUserData(string SiteNo, String UserNo, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.BingUserData(SiteNo, UserNo, Show) : FastSocket_Rcominfo.BingUserData(SiteNo, UserNo, Show);
        }
        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static DataSet GetSchemaTable(string sqlstr, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.GetSchemaTable(sqlstr, Show) : FastSocket_Rcominfo.GetSchemaTable(sqlstr, Show);
        }
    
       
        /// <summary>
        /// 上传文件并返回结果
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool UploadFile(string path, string filename, string savefilename, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.UploadFile(path, filename, savefilename, Show) : FastSocket_Rcominfo.UploadFile(path, filename, savefilename, Show);
        }
        /// <summary>
        /// 上传图片并返回结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pic"></param>
        /// <param name="savefilename"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool UploadFile(string path, byte[] pic, string savefilename, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.UploadFile(path, pic, savefilename, Show) : FastSocket_Rcominfo.UploadFile(path, pic, savefilename, Show);
        }
        /// <summary>
        /// 将image转化为二进制 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] GetByteImage(System.Drawing.Image img)
        {

            byte[] bt = null;

            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);

                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图像以指定的格式存入缓存内存流

                    bt = new byte[mostream.Length];

                    mostream.Position = 0;//设置留的初始位置

                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));

                }

            }

            return bt;

        }
        /// <summary>
        /// 向服务器发送消息推送
        /// </summary>
        /// <param name="s"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool MaeesgeSend(MassgeClass mag, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.MaeesgeSend(mag, Show) : FastSocket_Rcominfo.MaeesgeSend(mag, Show);
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool GetloadFile(string path, string filename, string SaveFileName, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.GetloadFile(path, filename, SaveFileName, Show) : FastSocket_Rcominfo.GetloadFile(path, filename, SaveFileName, Show);
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static byte[] GetloadFile(string path, string filename, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.GetloadFile(path, filename, Show) : FastSocket_Rcominfo.GetloadFile(path, filename, Show);
        }
        /// <summary>
        /// 获取服务器文件MD5值
        /// </summary>
        /// <param name="FileName">文件名称</param>
        /// <returns>返回MD5</returns>
        public static string GetloadFileMD5(string FileName, bool? Show = true)
        {
            return FastSocketCode ? FastSocket_1005.GetloadFileMD5(FileName, Show) : FastSocket_Rcominfo.GetloadFileMD5(FileName, Show);
        }
        /// <summary>
        /// 将Byte转换成Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static System.Drawing.Image BytesToImage(byte[] buffer)
        {
            if (buffer == null) { return null; }
            MemoryStream ms = new MemoryStream(buffer);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public static void StopConnectServer()
        {
            if (FastSocketCode)
            {
                FastSocket_1005.StopConnectServer();
            }
            else
            {
                FastSocket_Rcominfo.CloseConnect();
            }
        }
        /// <summary>
        /// 发送文件给服务器
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Save_Path"></param>
        /// <param name="Save_FileName"></param>
        /// <returns></returns>
        public static bool SentFile(String FileName, String Save_Path, String Save_FileName, SentFiled Exed)
        {
            return FastSocketCode ? FastSocket_1005.SentFile(FileName, Save_Path, Save_FileName, new FastSocket_1005.SentFiled(Exed)) : FastSocket_Rcominfo.SentFile(FileName, Save_Path, Save_FileName, new FastSocket_Rcominfo.SentFiled(Exed));
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="Save_FileName"></param>
        /// <param name="Exed"></param>
        /// <returns></returns>
        public static bool GetFile(String Path, String FileName, String Save_FileName, SentFiled Exed)
        {
            return FastSocketCode ? FastSocket_1005.GetFile(Path, FileName, Save_FileName, new FastSocket_1005.SentFiled(Exed)) : FastSocket_Rcominfo.GetFile(Path, FileName, Save_FileName, new FastSocket_Rcominfo.SentFiled(Exed));
        }
        /// <summary>
        /// 上传文件进度委托
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="now_Count"></param>
        /// <param name="state"></param>
        public delegate void SentFiled(int Count, int now_Count, bool state);
        #endregion
    }



    /// <summary>
    /// 服务器提供的中间件连接通信类
    /// </summary>
    public static class FastSocket_1005
    {
        /// <summary>
        /// 客户端Socket句柄
        /// </summary>
        public static AsyncBinarySocketClient client;
        /// <summary>
        /// 消息弹窗界面风格
        /// </summary>
        public static int MagCode = 1;
        /// <summary>
        /// 检查并连接服务器中间件
        /// </summary>
        public static void ConnectServer()
        {
            if (client == null)
            {
                client = new Sodao.FastSocket.Client.AsyncBinarySocketClient(8192, 8192, 60000, 60000);
                SererInfo server = EntityProcess.GetNowServer();
                bool a = client.RegisterServerNode(server.IP + ":" + server.Port.ToString(), new System.Net.IPEndPoint(System.Net.IPAddress.Parse(server.IP), server.Port));
                client.OnMessaged += new AsyncBinarySocketClient.OnMessage(OnMessaged);
            }
            if (LoginInfo.UserID != null && LoginInfo.UserName != null && client.CountConnection() > 0)
            {
                BingUserData(LoginInfo.UserID, LoginInfo.UserName, false);
            }
        }
        /// <summary>
        /// 消息到达事件
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="data"></param>
        private static void OnMessaged(Sodao.FastSocket.SocketBase.IConnection connection, byte[] data)
        {
            FastSocket.OnMessaged(0, string.Empty, 0, data);
        }
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static string get_localip(bool? Show = true)
        {
            try
            {
                ConnectServer();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes("");
                string ReturnText = "";
                client.Send("GetLocalIP", bytes, res => System.Text.Encoding.UTF8.GetString(res.Buffer)).ContinueWith(c =>
                {
                    ReturnText = c.Result;
                }
                ).Wait();
                return ReturnText;
            }
            catch
            {
                return string.Empty;
            }
        }
      
   
   
    
        /// <summary>
        /// 向服务器发送当前标示
        /// </summary>
        /// <param name="userdata"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool BingUserData(string SiteNo, String UserNo, bool? Show = true)
        {
            byte[] sql = DataSetSerializer.Compress(new UserData(SiteNo, UserNo));
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);
            client.Send("BingUserData", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
            {
                try
                {
                    ret = c.Result;
                }
                catch (Exception ex)
                {
                    if (Show == true) { ; }
                }
            }).Wait();
            return ret.State;
        }
        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static DataSet GetSchemaTable(string sqlstr, bool? Show = true)
        {
            ConnectServer();
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, "0");
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(sqlstr);
            client.Send("GetSchemaTable", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
            {
                ret = c.Result;
            }).Wait();
            if (ret.State == false) { if (Show == true) { ; } }
            return ret.DT;
        }


   
 
        /// <summary>
        /// 上传文件并返回结果
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>Collections.ReturnObject
        public static bool UploadFile(string path, string filename, string savefilename, bool? Show = true)
        {
            ConnectServer();
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);
            FileStream fs = File.OpenRead(filename);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            fs.Dispose();
            string FileName = savefilename == string.Empty ? Path.GetFileName(filename) : savefilename;
            byte[] sql = DataSetSerializer.Compress(new PicClass(path, FileName, data));
            try
            {
                client.Send("UploadFile", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
                {
                    try
                    {
                        ret = c.Result;
                    }
                    catch (Exception dd) { ; }
                }).Wait();
            }
            catch (AggregateException ex)
            {
                ;
            }

            if (ret.State == false) { if (Show == true) { ; } }
            return ret.State;
        }
        /// <summary>
        /// 上传图片并返回结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pic"></param>
        /// <param name="savefilename"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool UploadFile(string path, byte[] pic, string savefilename, bool? Show = true)
        {
            ConnectServer();
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);

            string FileName = savefilename;
            byte[] sql = DataSetSerializer.Compress(new PicClass(path, FileName, pic));
            try
            {
                client.Send("UploadFile", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
                {
                    try
                    {
                        ret = c.Result;
                    }
                    catch (Exception dd) { ; }
                }).Wait();
            }
            catch (AggregateException ex)
            {
                ;
            }

            if (ret.State == false) { if (Show == true) { ; } }
            return ret.State;
        }
        /// <summary>
        /// 将image转化为二进制 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] GetByteImage(System.Drawing.Image img)
        {

            byte[] bt = null;

            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);

                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图像以指定的格式存入缓存内存流

                    bt = new byte[mostream.Length];

                    mostream.Position = 0;//设置留的初始位置

                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));

                }

            }

            return bt;

        }
        /// <summary>
        /// 向服务器发送消息推送
        /// </summary>
        /// <param name="s"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool MaeesgeSend(MassgeClass mag, bool? Show = true)
        {
            ConnectServer();

            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);
            try
            {
                client.Send("MessgSend", DataSetSerializer.Compress(mag), res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
                {
                    try
                    {
                        ret = c.Result;
                    }
                    catch (Exception dd) { ; }
                }).Wait();
            }
            catch (AggregateException ex)
            {
                ;
            }

            if (ret.State == false) { if (Show == true) { ; } }
            return ret.State;
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool GetloadFile(string path, string filename, string SaveFileName, bool? Show = true)
        {
            ConnectServer();
            PicClass ret = new PicClass(string.Empty, string.Empty, null);
            string FileName = filename;
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            try
            {
                client.Send("GetloadFile", sql, res => DataSetSerializer.DeCompress<PicClass>(res.Buffer)).ContinueWith(c =>
                {
                    try
                    {
                        ret = c.Result;
                    }
                    catch (Exception dd) { ; }
                }).Wait();
            }
            catch (AggregateException ex)
            {
                ;
            }

            if (ret.Pic == null) { if (Show == true) { ; };return false; }
            FileStream FileObject = File.Create(SaveFileName);
            FileObject.Position = 0;
            FileObject.Write(ret.Pic, 0, ret.Pic.Length);
            FileObject.Close();
            FileObject.Dispose();
            return true;
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static byte[] GetloadFile(string path, string filename, bool? Show = true)
        {
            ConnectServer();
            PicClass ret = new PicClass(string.Empty, string.Empty, null);
            string FileName = filename;
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            try
            {
                client.Send("GetloadFile", sql, res => DataSetSerializer.DeCompress<PicClass>(res.Buffer)).ContinueWith(c =>
                {
                    try
                    {
                        ret = c.Result;
                    }
                    catch (Exception dd) { ;}
                }).Wait();
            }
            catch (AggregateException ex)
            {
                ;
            }

            if (ret.Pic == null) { if (Show == true) { ; };return null; }
            return ret.Pic;
        }
        /// <summary>
        /// 获取服务器文件MD5值
        /// </summary>
        /// <param name="FileName">文件名称</param>
        /// <returns>返回MD5</returns>
        public static string GetloadFileMD5(string FileName, bool? Show = true)
        {
            ConnectServer();
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            try
            {
                client.Send("GetloadFileMD5", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
                {
                    ret = c.Result;
                }).Wait();
                if (ret.State == false) { if (Show == true) { ;} }
            }
            catch
            {
                return ret.ReturnText;
            }
            return ret.ReturnText;
        }
        /// <summary>
        /// 将Byte转换成Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static System.Drawing.Image BytesToImage(byte[] buffer)
        {
            if (buffer == null) { return null; }
            MemoryStream ms = new MemoryStream(buffer);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public static void StopConnectServer()
        {
            if (client != null)
            {
                client.Stop();
            }
        }
        /// <summary>
        /// 向服务器请求文件
        /// </summary>
        /// <param name="Path">请求路径</param>
        /// <param name="FileName">请求文件</param>
        /// <param name="StartSize">其实文件位置</param>
        /// <param name="ReadSize">读取长度</param>
        /// <param name="Show">是否显示错误提示</param>
        /// <returns></returns>
        public static PicClass GetServerFileByte(String Path, String FileName, int StartSize, int ReadSize, bool? Show = false)
        {
            ConnectServer();
            PicClass ret = new PicClass();
            byte[] sql = DataSetSerializer.Compress(new PicClass(Path, FileName, null, StartSize, ReadSize));
            try
            {
                client.Send("GetServerFileByte", sql, res => DataSetSerializer.DeCompress<PicClass>(res.Buffer)).ContinueWith(c =>
                {
                    ret = c.Result;
                }).Wait();
            }
            catch
            {
                return null;
            }
            return ret;
        }
        /// <summary>
        /// 发送文件给服务器[内部]
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="StartSize"></param>
        /// <param name="ReadSize"></param>
        /// <param name="CountSize"></param>
        /// <param name="pic"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool SentServerFileByte(String Path, String FileName, int StartSize, int ReadSize, int CountSize, byte[] pic, bool? Show = false)
        {
            ConnectServer();
            Common.DataSetSerializer.ReturnObject ret = new Common.DataSetSerializer.ReturnObject(false, string.Empty, null, string.Empty);
            byte[] sql = DataSetSerializer.Compress(new PicClass(Path, FileName, pic, StartSize, ReadSize, CountSize));
            try
            {
                client.Send("SentServerFileByte", sql, res => DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(res.Buffer)).ContinueWith(c =>
                {
                    ret = c.Result;
                }).Wait();
                if (ret.State == false) { if (Show == true) { ;} }
            }
            catch
            {
                return false;
            }
            return ret.State;
        }
        /// <summary>
        /// 发送文件给服务器
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Save_Path"></param>
        /// <param name="Save_FileName"></param>
        /// <returns></returns>
        public static bool SentFile(String FileName, String Save_Path, String Save_FileName, SentFiled Exed)
        {
            FileStream File_Read = File.OpenRead(FileName);
            File_Read.Position = 0;
            int now_size = 10240;
            int now_position = 0;
            while (now_size != 0)
            {
                byte[] b = new byte[now_size];
                now_position = (int)File_Read.Position;
                now_size = File_Read.Read(b, 0, now_size);
                bool state = true;
                if (now_size > 0)
                {
                    if (!SentServerFileByte(Save_Path, Save_FileName, now_position, now_size, (int)File_Read.Length, b, false)) { state = false; }

                }
                if (Exed != null) { Exed((int)File_Read.Length, now_position, state); }
                if (!state) { File_Read.Close(); File_Read.Dispose(); return state; };
            }
            File_Read.Close();
            File_Read.Dispose();
            return true;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="Save_FileName"></param>
        /// <param name="Exed"></param>
        /// <returns></returns>
        public static bool GetFile(String Path, String FileName, String Save_FileName, SentFiled Exed)
        {
            int NowSize = 1;
            int NowReadSize = 0;
            byte[] FileCountData = new byte[0];
            PicClass FileByte = new PicClass();
            while (NowSize > 0)
            {
                FileByte = GetServerFileByte(Path, FileName, NowReadSize, 10240);
                NowSize = FileByte.ReadSize;
                if (FileByte.CountSize == 0) { ; continue; }
                NowReadSize += NowSize;
                FileCountData = FileCountData.Concat(FileByte.Pic).ToArray();
                if (Exed != null) { Exed(FileByte.CountSize, FileByte.StartSize, true); };
            }
            FileStream File_Write = new FileStream(Save_FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            File_Write.Write(FileCountData, 0, FileByte.CountSize);
            File_Write.Close();
            FileByte = null;
            return true;
        }
        /// <summary>
        /// 上传文件进度委托
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="now_Count"></param>
        /// <param name="state"></param>
        public delegate void SentFiled(int Count, int now_Count, bool state);
    }


    /// <summary>
    /// 对象序列号公开类
    /// </summary>
    public static class DataSetSerializer
    {
        /// <summary>
        /// 把bytes用GZIPStream 压缩
        /// </summary>
        /// <param name="bytes">需要压缩的byte[]数组</param>
        /// <returns>返回已压缩的byte[]数组</returns>
        public static byte[] GZIPCompress(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream Compress = new GZipStream(ms, CompressionMode.Compress);
                Compress.Write(bytes, 0, bytes.Length);
                Compress.Close();
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 把bytes用GZIPStream 解压缩
        /// </summary>
        /// <param name="bytes">需要解压缩的byte[]数组</param>
        /// <returns>返回已解压缩的byte[]数组</returns>
        public static byte[] GZIPDecompress(Byte[] bytes)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);
                    Decompress.CopyTo(tempMs);
                    Decompress.Close();
                    return tempMs.ToArray();
                }
            }
        }
        /// <summary>
        /// 将Byte[]转换为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="Bytes">要转换的字节集</param>
        /// <returns>对象</returns>
        public static T DeCompress<T>(byte[] Bytes)
        {
            try
            {
                //创建内存流
                MemoryStream memStream = new MemoryStream(GZIPDecompress(Bytes));
                //产生二进制序列化格式
                IFormatter formatter = new BinaryFormatter();
                //反串行化到内存中
                object obj = formatter.Deserialize(memStream);
                //类型检验
                if (obj is T)
                {
                    return (T)obj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 将对象序列化为Byte[]
        /// </summary>
        /// <param name="NowObject"></param>
        /// <returns></returns>
        public static byte[] Compress(Object NowObject)
        {
            try
            {
                //创建内存流
                MemoryStream memStream = new MemoryStream();//产生二进制序列化格式
                IFormatter formatter = new BinaryFormatter();//指定DataSet串行化格式是二进制

                formatter.Serialize(memStream, NowObject);//将DataSet转化成byte[]               
                byte[] binaryResult = memStream.ToArray();//清空和释放内存流
                memStream.Close();
                memStream.Dispose();
                return GZIPCompress(binaryResult);
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 提供一个可序列化成byte[]的对象,此对象可通过网络传送到服务端. 
        /// ReturnObject对象
        /// </summary>
        [Serializable]
        public class ReturnObject
        {
            /// <summary>
            /// 返回结果
            /// </summary>
            public bool State;
            /// <summary>
            /// 错误信息
            /// </summary>
            public string Megs;
            /// <summary>
            /// 返回datatable
            /// </summary>
            public DataSet DT;
            /// <summary>
            /// 返回其他执行结果
            /// </summary>
            public string ReturnText;
            public ReturnObject(bool s, string m, DataSet d, string r)
            {
                State = s;
                Megs = m;
                DT = d;
                ReturnText = r;
            }
        }
    }


    /// <summary>
    /// 带参数的sql类
    /// </summary>
    [Serializable]
    public class SqlAsgeClass
    {
        /// <summary>
        /// sql命令
        /// </summary>
        public string SqlStr { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public IList<SerSqlParameter> ParList = new List<SerSqlParameter>();
        /// <summary>
        /// 初始化类实例
        /// </summary>
        public SqlAsgeClass()
        {
            SqlStr = string.Empty;
        }
        /// <summary>
        /// 初始化类实例
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="list"></param>
        public SqlAsgeClass(string sql, List<SerSqlParameter> list)
        {
            SqlStr = sql;
            ParList = list;
        }
    }


    /// <summary>
    /// 服务器信息
    /// </summary>
    public class SererInfo
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 服务器端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 服务器状态
        /// </summary>
        public bool ServerState { get; set; }
        /// <summary>
        /// 是否当前服务器
        /// </summary>
        public bool NowServer { get; set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string Name { get; set; }
    }


   


    /// <summary>
    /// 客户端信息类
    /// </summary>
    [Serializable]
    public class UserData
    {
        /// <summary>
        /// 网点编号
        /// </summary>
        public String SiteNo { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public String UserNo { get; set; }
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="Siteno"></param>
        /// <param name="Userno"></param>
        public UserData(String Siteno, String Userno)
        {
            SiteNo = Siteno;
            UserNo = Userno;
        }
    }


    /// <summary>
    /// 提供一个可序列化成byte[]的对象,此对象可通过网络传送到服务端. 
    /// DSU对象包括一个 存储过程 和一个 IDataParameter[] parameters.
    /// </summary>
    [Serializable]
    public class PicClass
    {
        /// <summary>
        /// 文件目录
        /// </summary>
        public string Path = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName = string.Empty;
        /// <summary>
        /// 文件内容
        /// </summary>
        public Byte[] Pic;
        /// <summary>
        /// 开始读取位置
        /// </summary>
        public int StartSize = 0;
        /// <summary>
        /// 本次读取长度
        /// </summary>
        public int ReadSize = 10240;
        /// <summary>
        /// 文件总长度
        /// </summary>
        public int CountSize = 0;
        /// <summary>
        /// 初始化类
        /// </summary>
        public PicClass()
        {

        }
        /// <summary>
        /// 带参数初始化类
        /// </summary>
        /// <param name="pate"></param>
        /// <param name="filename"></param>
        /// <param name="pic"></param>
        public PicClass(string pate, string filename, byte[] pic)
        {
            this.Path = pate;
            this.FileName = filename;
            this.Pic = pic;
            StartSize = 0;
        }
        /// <summary>
        /// 带参数实例化类
        /// </summary>
        /// <param name="pate"></param>
        /// <param name="filename"></param>
        /// <param name="pic"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public PicClass(string pate, string filename, byte[] pic, int a, int b)
        {
            this.Path = pate;
            this.FileName = filename;
            this.Pic = pic;
            StartSize = a;
            ReadSize = b;
        }
        /// <summary>
        /// 带参数实例化类
        /// </summary>
        /// <param name="pate"></param>
        /// <param name="filename"></param>
        /// <param name="pic"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public PicClass(string pate, string filename, byte[] pic, int a, int b, int c)
        {
            this.Path = pate;
            this.FileName = filename;
            this.Pic = pic;
            StartSize = a;
            ReadSize = b;
            CountSize = c;
        }
    }


    /// <summary>
    /// 提供一个可序列化成byte[]的对象,此对象可通过网络传送到服务端. 
    /// 消息对象
    /// </summary>
    [Serializable]
    public class MassgeClass
    {
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Mags;
        /// <summary>
        /// 接收用户
        /// </summary>
        public string[] SiteOrUser { get; set; }
        /// <summary>
        /// 是否网点
        /// </summary>
        public bool IsSite { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public String Mags_Type { get; set; }
        /// <summary>
        /// 消息编号
        /// </summary>
        public string MagsID { get; set; }
        /// <summary>
        /// 初始化消息对象
        /// </summary>
        /// <param name="u">消息类型</param>
        /// <param name="m">信息内容</param>
        /// <param name="u">是否网点</param>
        /// <param name="m">接收用户</param>
        public MassgeClass(string t, string m, bool s, string[] su, string id)
        {
            Mags_Type = t;
            Mags = m;
            IsSite = s;
            SiteOrUser = su;
            MagsID = id;
        }
        public MassgeClass()
        {

        }

    }


    /// <summary>
    /// 提供一个可序列化成byte[]的对象,此对象可通过网络传送到服务端. 
    /// DSU对象包括一个 存储过程 和一个 IDataParameter[] parameters.
    /// </summary>
    [Serializable]
    public class ExecProcedure
    {
        public IList<SerSqlParameter> parameters;
        public string ProcedureName;

        public ExecProcedure(string name, IList<SerSqlParameter> p)
        {
            this.parameters = p;
            this.ProcedureName = name;
        }
    }

    /// <summary>
    /// 可能序列化的SqlParameter对象
    /// </summary>
    [Serializable]
    public class SerSqlParameter
    {
        public SerSqlParameter(SqlParameter sPara)
        {
            this.paraName = sPara.ParameterName;
            this.paraLen = sPara.Size;
            this.paraVal = sPara.Value;
            this.sqlDbType = sPara.SqlDbType;
        }
        public SerSqlParameter(string Name, SqlDbType sqltype, int len, string value)
        {
            this.paraName = Name;
            this.paraLen = len;
            this.paraVal = value;
            this.sqlDbType = sqltype;

        }
        public SqlParameter ToSqlParameter()
        {
            SqlParameter para = new SqlParameter(this.paraName, this.sqlDbType, this.paraLen);
            para.Value = this.paraVal;
            return para;
        }

        private string paraName = "";
        public string ParaName
        {
            get { return this.paraName; }
            set { this.paraName = value; }

        }

        private int paraLen = 0;
        public int ParaLen
        {

            get { return this.paraLen; }
            set { this.paraLen = value; }
        }

        private object paraVal = null;
        public object ParaVal
        {
            get { return this.paraVal; }
            set { this.paraVal = value; }
        }

        private SqlDbType sqlDbType = SqlDbType.NVarChar;
        public SqlDbType SqlDbType
        {
            get { return this.sqlDbType; }

            set { this.sqlDbType = value; }
        }
    }


    /// <summary>
    /// 保存用户登录信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 当前用户登录状态
        /// </summary>
        public static bool LoginState { get; set; }
        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public static string UserID { get; set; }
        /// <summary>
        /// 当前登录用户名称
        /// </summary>
        public static string UserName { get; set; }
        /// <summary>
        /// 当前用户登录时间
        /// </summary>
        public static DateTime LoginTime { get; set; }
    }



    /// <summary>
    /// 自定义FastSocket客户端 主要实现3.5环境下的通讯
    /// </summary>
    public static class FastSocket_Rcominfo
    {
        #region FastSocket内部属性 不建议更改 以免引发未知的后果
        /// <summary>
        /// Socket句柄[内部使用]
        /// </summary>
        private static Socket ClientSocket = null;
        /// <summary>
        /// 单次接收数据大小
        /// </summary>
        private static int RepcsSize = 8192;
        /// <summary>
        /// 当前连接编号
        /// </summary>
        private static int FastSocketID { get; set; }
        /// <summary>
        /// Socket状态
        /// </summary>
        public static bool SocketState = true;
        /// <summary>
        /// 当前Seq值
        /// </summary>
        private static int NowSeqID = 0;
        /// <summary>
        /// 读取状态[True]为读取完毕
        /// </summary>
        private static bool ReadState = false;
        /// <summary>
        /// 当前读取的数据用做返回调用函数
        /// </summary>
        private static byte[] NowData = null;
        /// <summary>
        /// 接收超时时间ms
        /// </summary>
        private static int outtime = 60000;
        /// <summary>
        /// 当前链接等待时间
        /// </summary>
        public static int NowOutTime = 1000;
        /// <summary>
        /// 服务器名称
        /// </summary>
        public static string ServerName { get; set; }
        /// <summary>
        /// 临时信号保存变量
        /// </summary>
        private static int ServerXh_Temp { get; set; }
        /// <summary>
        /// 服务器信号
        /// </summary>
        public static int ServerXh
        {
            get { return ServerXh_Temp; }
            set
            {
                ServerXh_Temp = value;
                if (ServerXhChanged != null) { ServerXhChanged(FastSocketID, value); }
            }
        }
        /// <summary>
        /// 获取不重复的Seq
        /// </summary>
        /// <returns></returns>
        private static int GetSeqID()
        {
            NowSeqID += 1;
            return NowSeqID;
        }
        /// <summary>
        /// 等待对象
        /// </summary>
        private static readonly ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        public static bool ConnectServer(bool IsOneConnect)
        {
            if (ClientSocket != null)
            {
                if (LoginInfo.UserID != null && LoginInfo.UserName != null)
                {
                    BingUserData(LoginInfo.UserID, LoginInfo.UserName, false);
                }
                return true;
            }
            var NowList =Common.Entity.ServerList.Where(x => x.Value.NowServer).ToArray()[0];
            IPAddress ip = IPAddress.Parse(NowList.Value.IP);
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                TimeoutObject.Reset();
                ClientSocket.BeginConnect(new IPEndPoint(ip, NowList.Value.Port), CallBackMethod, ClientSocket);
                if (TimeoutObject.WaitOne(NowOutTime, false))
                {
                    NowList.Value.ServerState = true;
                    SocketState = true;
                    Thread receiveThread = new Thread(ReadServer);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                    MessagRead = new FastSocket.Messagedelegate(FastSocket.OnMessaged);
                }
                else
                {
                    NowList.Value.ServerState = false;
                    NowList.Value.NowServer = false;
                    NowList = Common.Entity.ServerList.Where(y => y.Key > NowList.Key || NowList.Key == Common.Entity.ServerList.Count - 1 || y.Value.ServerState).OrderBy(x => !x.Value.ServerState).ToArray()[0];
                    NowList.Value.NowServer = true;
                    SocketState = false;
                    ClientSocket = null;
                    if (IsOneConnect)
                    {
                        new Thread(new ThreadStart(() =>
                        {
                            ConnectServer(true);
                        })).Start();
                    }
                }
            }
            catch
            {
                SocketState = false;
                ClientSocket = null;
                if (IsOneConnect)
                {
                    new Thread(new ThreadStart(() =>
                    {
                        ConnectServer(true);
                    })).Start();
                }
            }
            if (ConnectChanged != null) { ConnectChanged(FastSocketID, SocketState); }
            return SocketState;
        }
        /// <summary>
        /// 等待对象回掉
        /// </summary>
        /// <param name="asyncresult"></param>
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            TimeoutObject.Set();
        }
        /// <summary>
        /// 监听接收数据(同步接收)
        /// </summary>
        private static void ReadServer()
        {
            while (SocketState)
            {
                try
                {
                    //通过clientSocket接收数据  
                    byte[] Data = new byte[0];//本次接收数据集合
                    byte[] result = new byte[RepcsSize];//本次单次接收数据
                    while (SocketState)
                    {
                        DateTime dt = DateTime.Now;
                        int receiveNumber = ClientSocket.Receive(result);
                        TimeSpan t = dt - DateTime.Now;
                        if (t.TotalMilliseconds > 1000) { Data = null; }
                        byte[] b = new byte[receiveNumber];
                        Buffer.BlockCopy(result, 0, b, 0, receiveNumber);
                        Data = Data.Concat(b).ToArray();//接收到是数据
                        Int32 DateLength = IPAddress.NetworkToHostOrder(System.BitConverter.ToInt32(Data, 0));
                        if (Data.Length == DateLength + 4)
                        {
                            Thread th_temp = new Thread(new ParameterizedThreadStart(Readed));
                            th_temp.IsBackground = true;
                            th_temp.Start(Data);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    SocketState = false;
                    ClientSocket = null;
                    ReadState = true;
                    if (ConnectChanged != null)
                    {
                        ConnectChanged(FastSocketID, SocketState);
                    }
                    new Thread(new ThreadStart(() =>
                    {
                        while (!SocketState)
                        {
                            ConnectServer(false);
                        }
                    })).Start();
                    return;
                }
            }
        }
        /// <summary>
        /// 接收完毕系统处理事件
        /// </summary>
        /// <param name="data"></param>
        private static void Readed(object data)
        {
            byte[] d = (byte[])data;
            int count = IPAddress.NetworkToHostOrder(System.BitConverter.ToInt32(d, 0));
            int seqid = IPAddress.NetworkToHostOrder(System.BitConverter.ToInt32(d, 4));
            int cmdnamecount = IPAddress.NetworkToHostOrder(System.BitConverter.ToInt16(d, 8));
            byte[] dat = new byte[cmdnamecount];
            Buffer.BlockCopy(d, 10, dat, 0, cmdnamecount);
            string cmdname = Encoding.UTF8.GetString(dat);
            byte[] da = new byte[count - 6 - cmdnamecount];
            Buffer.BlockCopy(d, 10 + cmdnamecount, da, 0, count - 6 - cmdnamecount);
            NowData = da.Length == 0 ? null : da;
            if (!ReadState)
            {
                ReadState = true;
            }
            else
            {
                if (MessagRead == null)
                {
                    Messaged(cmdname, seqid, NowData);
                }
                else
                {
                    MessagRead(FastSocketID, cmdname, seqid, NowData);
                }
            }
        }
        /// <summary>
        /// 接收系统推送消息事件[当收到服务器未定义消息时触发]
        /// </summary>
        public static FastSocket.Messagedelegate MessagRead;
        /// <summary>
        /// 链接状态改变委托
        /// </summary>
        /// <param name="connectstate"></param>
        public delegate void ConnectChange(int ID, bool connectstate);
        /// <summary>
        /// 连接状态改变事件
        /// </summary>
        public static ConnectChange ConnectChanged;
        /// <summary>
        /// 信号强度改变事件委托
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Xh"></param>
        public delegate void ServerXhChange(int ID, int Xh);
        /// <summary>
        /// 信号强度改变事件
        /// </summary>
        public static ServerXhChange ServerXhChanged;
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="Cmdname"></param>
        /// <param name="data"></param>
        /// <param name="Readeding"></param>
        /// <returns></returns>
        private static byte[] SendData(string Cmdname, byte[] data, Func<byte[], byte[]> Readeding)
        {
            try
            {
                DateTime Dt1 = DateTime.Now;
                if (!SocketState) { return null; }
                ReadState = false;
                byte[] bufferdata = new byte[0];
                int seqid = GetSeqID();
                byte[] cmdnamebyte = Encoding.UTF8.GetBytes(Cmdname);
                bufferdata = bufferdata.Concat(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(6 + cmdnamebyte.Length + data.Length))).ToArray();
                bufferdata = bufferdata.Concat(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(seqid))).ToArray();
                bufferdata = bufferdata.Concat(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)cmdnamebyte.Length))).ToArray();
                bufferdata = bufferdata.Concat(cmdnamebyte).ToArray().Concat(data).ToArray();
                DateTime dt = DateTime.Now;
                int SentSize = ClientSocket.Send(bufferdata);
                if (SentSize != bufferdata.Length) { return null; };
                while (!ReadState)
                {
                    TimeSpan t = DateTime.Now - dt;
                    if (t.TotalMilliseconds > outtime) { NowData = null; break; }
                }
                TimeSpan Ts = DateTime.Now - Dt1;
                ServerXh = (int)Ts.TotalMilliseconds;
                return Readeding(NowData);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 未定义服务器消息到达接收函数时默认的接收函数
        /// </summary>
        /// <param name="Cmdname"></param>
        /// <param name="SeqID"></param>
        /// <param name="data"></param>
        private static void Messaged(string Cmdname, int SeqID, byte[] data)
        {
            return;
            //MessageBox.Show("收到未知消息", Cmdname);
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public static void CloseConnect()
        {
            if (ClientSocket == null) { return; }
            ClientSocket.Close();
            ClientSocket = null;
            ReadState = true;
            SocketState = false;
            if (ConnectChanged != null) { ConnectChanged(FastSocketID, false); }
        }
        #endregion
        #region FastSocket方法
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("GetLocalIP", new byte[0], ret =>
                a = ret
                );
            if (a == null) { return string.Empty; };
            return Encoding.UTF8.GetString(a);
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        public static void CloseServer()
        {
            byte[] a = null;
            SendData("CloseServer", new byte[0], ret =>
                a = ret
                );
            if (a == null) { return; };
            return;
        }
        /// <summary>
        /// 执行Sql命令并返回DataSet
        /// </summary>
        /// <param name="sqlstr">Sql命令</param>
        /// <returns>返回DataSet</returns>
        public static DataSet get_ds(string sqlstr, bool? Show = true)
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("query", Encoding.UTF8.GetBytes(sqlstr), ret =>
                a = ret
                );
            if (a == null) { return null; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.DT;
        }
        /// <summary>
        /// 执行Sql命令并返回影响的行数
        /// </summary>
        /// <param name="sqlstr">Sql命令</param>
        /// <returns></returns>
        public static string ExecuteSql(string sqlstr, bool? Show = true)
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("ExecuteSql", Encoding.UTF8.GetBytes(sqlstr), ret =>
                a = ret
                );
            if (a == null) { return null; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ;} }
            return rt.ReturnText;
        }
  
     
        /// <summary>
        /// 向服务器发送当前标示
        /// </summary>
        /// <param name="userdata"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool BingUserData(string SiteNo, String UserNo, bool? Show = true)
        {
            byte[] a = null;
            SendData("BingUserData", DataSetSerializer.Compress(new UserData(SiteNo, UserNo)), ret =>
                a = ret
                );
            if (a == null) { return false; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.State;
        }
        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static DataSet GetSchemaTable(string sqlstr, bool? Show = true)
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("GetSchemaTable", Encoding.UTF8.GetBytes(sqlstr), ret =>
                a = ret
                );
            if (a == null) { return null; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.DT;
        }
      
  
        /// <summary>
        /// 上传文件并返回结果
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool UploadFile(string path, string filename, string savefilename, bool? Show = true)
        {
            ConnectServer(false);
            FileStream fs = File.OpenRead(filename);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            fs.Dispose();
            string FileName = savefilename == string.Empty ? Path.GetFileName(filename) : savefilename;
            byte[] sql = DataSetSerializer.Compress(new PicClass(path, FileName, data));
            byte[] a = null;
            SendData("UploadFile", sql, ret =>
                a = ret
                );
            if (a == null) { return false; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ;} }
            return rt.State;
        }
        /// <summary>
        /// 上传图片并返回结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pic"></param>
        /// <param name="savefilename"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool UploadFile(string path, byte[] pic, string savefilename, bool? Show = true)
        {
            ConnectServer(false);
            string FileName = savefilename;
            byte[] sql = DataSetSerializer.Compress(new PicClass(path, FileName, pic));
            byte[] a = null;
            SendData("UploadFile", sql, ret =>
                a = ret
                );
            if (a == null) { return false; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.State;
        }
        /// <summary>
        /// 将image转化为二进制 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] GetByteImage(System.Drawing.Image img)
        {
            ConnectServer(false);
            byte[] bt = null;
            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图像以指定的格式存入缓存内存流
                    bt = new byte[mostream.Length];
                    mostream.Position = 0;//设置留的初始位置
                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                }
            }
            return bt;
        }
        /// <summary>
        /// 向服务器发送消息推送
        /// </summary>
        /// <param name="s"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool MaeesgeSend(MassgeClass mag, bool? Show = true)
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("MessgSend", DataSetSerializer.Compress(mag), ret =>
                a = ret
                );
            if (a == null) { return false; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            return rt == null ? false : rt.State;
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool GetloadFile(string path, string filename, string SaveFileName, bool? Show = true)
        {
            ConnectServer(false);
            string FileName = filename;
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            byte[] a = null;
            SendData("GetloadFile", sql, ret =>
                a = ret
                );
            if (a == null) { return false; };
            PicClass rt = DataSetSerializer.DeCompress<PicClass>(a);
            if (rt.Pic == null) { if (Show == true) { ; } return false; }
            FileStream FileObject = File.Create(SaveFileName);
            FileObject.Position = 0;
            FileObject.Write(rt.Pic, 0, rt.Pic.Length);
            FileObject.Close();
            FileObject.Dispose();
            return true;
        }
        /// <summary>
        /// 请求服务器文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static byte[] GetloadFile(string path, string filename, bool? Show = true)
        {
            ConnectServer(false);
            string FileName = filename;
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            byte[] a = null;
            SendData("GetloadFile", sql, ret =>
                a = ret
                );
            if (a == null) { return null; };
            PicClass rt = DataSetSerializer.DeCompress<PicClass>(a);
            if (rt.Pic == null) { if (Show == true) { ; } }
            return rt.Pic;
        }
        /// <summary>
        /// 获取服务器文件MD5值
        /// </summary>
        /// <param name="FileName">文件名称</param>
        /// <returns>返回MD5</returns>
        public static string GetloadFileMD5(string FileName, bool? Show = true)
        {
            ConnectServer(false);
            byte[] sql = System.Text.Encoding.UTF8.GetBytes(FileName);
            byte[] a = null;
            SendData("GetloadFileMD5", sql, ret =>
                a = ret
                );
            if (a == null) { return null; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.ReturnText;
        }
        /// <summary>
        /// 将Byte转换成Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static System.Drawing.Image BytesToImage(byte[] buffer)
        {
            ConnectServer(false);
            if (buffer == null) { return null; }
            MemoryStream ms = new MemoryStream(buffer);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        /// <summary>
        /// 向服务器请求文件
        /// </summary>
        /// <param name="Path">请求路径</param>
        /// <param name="FileName">请求文件</param>
        /// <param name="StartSize">其实文件位置</param>
        /// <param name="ReadSize">读取长度</param>
        /// <param name="Show">是否显示错误提示</param>
        /// <returns></returns>
        public static PicClass GetServerFileByte(String Path, String FileName, int StartSize, int ReadSize, bool? Show = false)
        {
            ConnectServer(false);
            byte[] sql = DataSetSerializer.Compress(new PicClass(Path, FileName, null, StartSize, ReadSize));
            byte[] a = null;
            SendData("GetServerFileByte", sql, ret =>
                a = ret
                );
            if (a == null) { return null; };
            PicClass rt = DataSetSerializer.DeCompress<PicClass>(a);
            if (rt.Pic == null) { if (Show == true) { ; } }
            return rt;
        }
        /// <summary>
        /// 发送文件给服务器[内部]
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="StartSize"></param>
        /// <param name="ReadSize"></param>
        /// <param name="CountSize"></param>
        /// <param name="pic"></param>
        /// <param name="Show"></param>
        /// <returns></returns>
        public static bool SentServerFileByte(String Path, String FileName, int StartSize, int ReadSize, int CountSize, byte[] pic, bool? Show = false)
        {
            ConnectServer(false);
            byte[] sql = DataSetSerializer.Compress(new PicClass(Path, FileName, pic, StartSize, ReadSize, CountSize));
            byte[] a = null;
            SendData("SentServerFileByte", sql, ret =>
                a = ret
                );
            if (a == null) { return false; };
            Common.DataSetSerializer.ReturnObject rt = DataSetSerializer.DeCompress<Common.DataSetSerializer.ReturnObject>(a);
            if (rt.State == false) { if (Show == true) { ; } }
            return rt.State;
        }
        /// <summary>
        /// 发送文件给服务器
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Save_Path"></param>
        /// <param name="Save_FileName"></param>
        /// <returns></returns>
        public static bool SentFile(String FileName, String Save_Path, String Save_FileName, SentFiled Exed)
        {
            ConnectServer(false);
            FileStream File_Read = File.OpenRead(FileName);
            File_Read.Position = 0;
            int now_size = 10240;
            int now_position = 0;
            while (now_size != 0)
            {
                byte[] b = new byte[now_size];
                now_position = (int)File_Read.Position;
                now_size = File_Read.Read(b, 0, now_size);
                bool state = true;
                if (now_size > 0)
                {
                    if (!SentServerFileByte(Save_Path, Save_FileName, now_position, now_size, (int)File_Read.Length, b, false)) { state = false; }

                }
                if (Exed != null) { Exed((int)File_Read.Length, now_position, state); }
                if (!state) { File_Read.Close(); File_Read.Dispose(); return state; };
            }
            File_Read.Close();
            File_Read.Dispose();
            return true;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="Save_FileName"></param>
        /// <param name="Exed"></param>
        /// <returns></returns>
        public static bool GetFile(String Path, String FileName, String Save_FileName, SentFiled Exed)
        {
            ConnectServer(false);
            int NowSize = 1;
            int NowReadSize = 0;
            byte[] FileCountData = new byte[0];
            PicClass FileByte = new PicClass();
            while (NowSize > 0)
            {
                FileByte = GetServerFileByte(Path, FileName, NowReadSize, 10240);
                NowSize = FileByte.ReadSize;
                if (FileByte.CountSize == 0) { ; continue; }
                NowReadSize += NowSize;
                FileCountData = FileCountData.Concat(FileByte.Pic).ToArray();
                if (Exed != null) { Exed(FileByte.CountSize, FileByte.StartSize, true); };
            }
            FileStream File_Write = new FileStream(Save_FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            File_Write.Write(FileCountData, 0, FileByte.CountSize);
            File_Write.Close();
            FileByte = null;
            return true;
        }
        /// <summary>
        /// 重启服务器
        /// </summary>
        public static void UpdateServer()
        {
            ConnectServer(false);
            byte[] a = null;
            SendData("UpdateServer", new byte[0], ret =>
                a = ret
                );
            if (a == null) { return; };
            return;
        }
        /// <summary>
        /// 上传文件进度委托
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="now_Count"></param>
        /// <param name="state"></param>
        public delegate void SentFiled(int Count, int now_Count, bool state);
        #endregion
    }
}
