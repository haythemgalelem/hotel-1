using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using Common;
using System.Collections;

namespace Client.Controls
{
    /// <summary>
    /// Html编辑器
    /// </summary>
    [Description("Html编辑器"), ClassInterface(ClassInterfaceType.AutoDispatch)]
    public partial class HtmlEditor : UserControl
    {
        #region 初始化
        public HtmlEditor()
        {
            dataUpdate = 0;

            InitializeComponent();
            InitEvent();
            InitializeControls();
            this.toolStripComboBoxName.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxName_SelectedIndexChanged);
            this.toolStripComboBoxSize.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSize_SelectedIndexChanged);
      
            this.toolStripButtonUnDo.Click += new System.EventHandler(this.toolStripButtonUnDo_Click);
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            this.toolStripButtonBold.Click += new System.EventHandler(this.toolStripButtonBold_Click);
            this.toolStripButtonItalic.Click += new System.EventHandler(this.toolStripButtonItalic_Click);
            this.toolStripButtonUnderline.Click += new System.EventHandler(this.toolStripButtonUnderline_Click);
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);
            this.toolStripButtonNumbers.Click += new System.EventHandler(this.toolStripButtonNumbers_Click);
            this.toolStripButtonBullets.Click += new System.EventHandler(this.toolStripButtonBullets_Click);
            this.toolStripButtonOutdent.Click += new System.EventHandler(this.toolStripButtonOutdent_Click);
            this.toolStripButtonIndent.Click += new System.EventHandler(this.toolStripButtonIndent_Click);
            this.toolStripButtonLeft.Click += new System.EventHandler(this.toolStripButtonLeft_Click);
            this.toolStripButtonCenter.Click += new System.EventHandler(this.toolStripButtonCenter_Click);

            this.toolStripButtonRight.Click += new System.EventHandler(this.toolStripButtonRight_Click);
            this.toolStripButtonFull.Click += new System.EventHandler(this.toolStripButtonFull_Click);
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            this.toolStripButtonPicture.Click += new System.EventHandler(this.toolStripButtonPicture_Click);
            this.toolStripButtonHyperlink.Click += new System.EventHandler(this.toolStripButtonHyperlink_Click);
            this.webBrowserBody.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserBody_DocumentCompleted); 
        }

          /// <summary>
        /// 控件初始化
        /// </summary>
        private void InitializeControls()
        {
            BeginUpdate();

            //工具栏
            foreach (FontFamily family in FontFamily.Families)
            {
                toolStripComboBoxName.Items.Add(family.Name);
            }

            toolStripComboBoxSize.Items.AddRange(FontSize.All.ToArray());

            //浏览器
            webBrowserBody.DocumentText = string.Empty;
            webBrowserBody.Document.Click += new HtmlElementEventHandler(webBrowserBody_DocumentClick);
            webBrowserBody.Document.Focusing += new HtmlElementEventHandler(webBrowserBody_DocumentFocusing);
            webBrowserBody.Document.ExecCommand("EditMode", false, null);//编辑模式
            webBrowserBody.Document.ExecCommand("LiveResize", false, null);

            EndUpdate();
        }

       /// <summary>
        /// 初始化自定义事件
        /// </summary>
        private void InitEvent()
        {
            client = new WebClient(); 
            client.UploadDataCompleted += new UploadDataCompletedEventHandler(client_UploadDataCompleted);

        }
        #endregion
        #region 属性
        private WebClient client = null;
        /// <summary>
        /// 图片存放路径名称，如：PathUtil.NOTE_PICTURE_PATH，即"NotePicture";
        /// </summary>
        public string picturePath = Program.fileServerUrl;
        private List<string> all_images_LocalPath = new List<string>();//所有上传图片本地路径列表，
        private List<string> all_images_newFileName = new List<string>();//所有上传图片对应先文件名列表，
        private List<string> needUpload_images_LocalPath = new List<string>();//需要上传图片本地路径列表
        private List<string> needUpload_images_newFileName = new List<string>();//需要上传图片列表新名称
        private string urlString = "";
        private Hashtable currentImageHashtable = new Hashtable();
        #endregion

        #region 扩展属性

        /// <summary>
        /// 获取和设置当前的Html文本
        /// </summary>
        public string Html
        {
            get
            {
                try
                {
                    return this.webBrowserBody.Document.Body.InnerHtml == null ? "" : this.webBrowserBody.Document.Body.InnerHtml;
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
               
                try
                {     
                    webBrowserBody.Document.Body.InnerHtml = value;// value.Replace("\r\n", "<br>");
                }
                catch (Exception)
                {
                   
                }
            }
        }
              

        /// <summary>
        /// 获取插入的图片名称集合
        /// </summary>
        public string[] Images
        {
            get
            {
                List<string> images = new List<string>();

                if (webBrowserBody.Document != null && webBrowserBody.Document.Images != null)
                {
                    foreach (HtmlElement element in webBrowserBody.Document.Images)
                    {
                        string image = element.GetAttribute("src");
                        if (!images.Contains(image))
                        {
                            images.Add(image);
                        }
                    }
                }

                return images.ToArray();
            }
        }

        #endregion

        #region 方法
       
        
        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        private void RefreshToolBar()
        {
            BeginUpdate();

            try
            {
                mshtml.IHTMLDocument2 document = (mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument;

                toolStripComboBoxName.Text = document.queryCommandValue("FontName").ToString();
                toolStripComboBoxSize.SelectedItem = FontSize.Find((int)document.queryCommandValue("FontSize"));
                toolStripButtonBold.Checked = document.queryCommandState("Bold");
                toolStripButtonItalic.Checked = document.queryCommandState("Italic");
                toolStripButtonUnderline.Checked = document.queryCommandState("Underline");

                toolStripButtonNumbers.Checked = document.queryCommandState("InsertOrderedList");
                toolStripButtonBullets.Checked = document.queryCommandState("InsertUnorderedList");

                toolStripButtonLeft.Checked = document.queryCommandState("JustifyLeft");
                toolStripButtonCenter.Checked = document.queryCommandState("JustifyCenter");
                toolStripButtonRight.Checked = document.queryCommandState("JustifyRight");
                toolStripButtonFull.Checked = document.queryCommandState("JustifyFull");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                EndUpdate();
            }
        }
        /// <summary>
        /// 转换从word中复制的shape类型图片为img图片
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string ChangeShapeToImg(string sourceHtml)
        {
            string html = sourceHtml; 
            try
            {
                ////检测临时存放图片的文件夹是否存在 
                string tempFilePath = Environment.GetEnvironmentVariable("Temp") + "\\JSMS\\";
                try
                {
                    if (!System.IO.Directory.Exists(tempFilePath))
                        System.IO.Directory.CreateDirectory(tempFilePath);
                }
                catch (Exception ex)
                {
                    throw new HotelException(string.Format("创建临时文件夹失败!{0}", ex));
                }
                while (html.IndexOf("<v:shape ") >= 0)
                {                    
                    int start = html.IndexOf("<v:shape ");
                    int end = html.IndexOf("</v:shape>") + 10;
                    string shapeImageStr = html.Substring(start, end - start);
                    string styleStart = shapeImageStr.Substring(shapeImageStr.IndexOf("style=\"") + 7);
                    string style = styleStart.Substring(0, styleStart.IndexOf("\""));//提取style属性值
                    string srcStart = shapeImageStr.Substring(shapeImageStr.IndexOf("src=\"") + 5);
                    string src = srcStart.Substring(0, srcStart.IndexOf("\""));//提取src属性值
                    src = Path.GetFullPath(src.Replace("%20", " ").Replace("file:///", ""));
                    //把剪贴板中图片复制到临时文件夹temp下，防止剪贴板重复粘贴出现后面的图片一直显示为第一次粘贴的图片
                    string newImageFileName = tempFilePath+Guid.NewGuid().ToString("N") + Path.GetExtension(src);
                    File.Copy(src, newImageFileName);

                    //拼接图片标签,(使用新图片路径)
                    string imageStr = "<img style=\"" + style + "\" src=\"" + newImageFileName + "\"/>";
                    //替换字符串              
                    html = html.Replace(shapeImageStr, imageStr); 
                }
            }
            catch 
            {
            }
            return html;
        }
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <returns></returns>
        public string GetDocumentHtmlBody()
        {
            string html =this.ChangeShapeToImg(this.Html);//获取当前Html内容(经过shape类型转换img的过程)
            string[] images =this.Images;//获取当前Html中包含的图片
            
          
            urlString = this.picturePath;//Program.FilesServerURL + "/" + this.picturePath;//文件上传到目标服务器上的url
            DateTime dt = DateTime.Now;//获取当前时间

          
            if (images.Length > 0)
            {
                for (int i = 0, count = images.Length; i < count; ++i)
                {
                    string image = images[i];

                    if (image.Trim() == "")
                    {
                        continue;
                    }
                    if (!image.StartsWith("file"))
                    {
                        continue;
                    }
                    string imagePath = Path.GetFullPath(image.Replace("%20", " ").Replace("file:///", ""));
                    if (imagePath.Contains("QQ\\WinTemp") || imagePath.Contains("Tencent"))//如果包含QQ截图,则要对%7B，%7D进行替换
                    {
                        imagePath = imagePath.Replace("%7B", "{").Replace("%7D", "}").Replace("%60", "`").Replace("%25","%");
                    } 
                   //简单根据文件名和文件大小判断是否相同文件
                    string newFileName="";
                    if (this.currentImageHashtable.ContainsKey(imagePath))
                    {
                        newFileName = this.currentImageHashtable[imagePath].ToString();//取出存储的转换过的新图片url
                    }
                    else
                    {
                        this.needUpload_images_LocalPath.Add(imagePath);//取得待上传图片本地路径                        
                        //上传后新的文件名
                        newFileName = dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + "_"
                            + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00") +
                            dt.Millisecond.ToString() + "_" + i.ToString();//新文件名：yyyyMMdd_hhmmssMi_i
                        this.currentImageHashtable.Add(imagePath, newFileName);//把图片原路径和转换后的路径存储，以便后面判断是否已经上传过了
                        this.needUpload_images_newFileName.Add(newFileName);//新文件名列表
                    }                  
                   
                    
                    string replaceFileName = urlString + "/" + newFileName + Path.GetExtension(imagePath);//扩展名
                    this.all_images_LocalPath.Add(imagePath);
                    this.all_images_newFileName.Add(replaceFileName);
                    html = html.Replace(imagePath, replaceFileName).Replace(image,replaceFileName);//替换图片路径为服务器图片路径                   
                }             
            }

            return html.Replace("<BR><BR><BR>", "").
                Replace("<BR><BR>", "<BR>").Replace("<!--StartFragment -->", "").
                Replace("<DIV>&nbsp;", "<DIV>");
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        public void UploadImage()
        {
            try
            {
                if (needUpload_images_LocalPath.Count > 0)//如有图片要上传，则必须顺序上传，不能同时上传，即要成功上传一个后，在上传下一个
                {
                    //先上传第一个图片，然后根据上传完成情况，决定是否继续上传
                    Image resourceImage = Image.FromFile(this.needUpload_images_LocalPath[0]);//原图片
                    int width = 1400;
                    string mode = "W";
                    if (resourceImage.Width < width && resourceImage.Height < width)
                    {
                        width = resourceImage.Width > resourceImage.Height ? resourceImage.Width : resourceImage.Height;
                    }
                    mode = resourceImage.Width > resourceImage.Height ? "W" : "H";  //采取按宽度、高度模式缩略
                    //异步上传中等缩略图                       
                    UploadReducedImageAsync(this.needUpload_images_LocalPath[0], urlString, this.needUpload_images_newFileName[0], resourceImage, width, width, mode);
                   
                }
            }
            catch (Exception ex)
            {
                throw new HotelException("上传图片失败!", ex);
               // Program.MsgBoxInfo(string.Format("图片上传失败！{0}", ex));
            }
        }
        /// <summary>
        /// 异步上传缩略图
        /// </summary>
        /// <param name="ResourceImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode">model:HW,H,W,Cut</param>
        /// <returns></returns>
        private void UploadReducedImageAsync(string fileNamePath, string urlString, string newFileName,
            Image ResourceImage, int width, int height, string mode)
        {
            #region --------------------图片格式、新图片名称、扩展名------------
            System.Drawing.Imaging.ImageFormat imageFormat = null;
            string fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\") + 1);//原文件名
            string fileNameExt = Path.GetExtension(fileNamePath);//扩展名
            switch (fileNameExt.ToLower())
            {
                case ".gif":
                    imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case ".bmp":
                    imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case ".png":
                    imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                default:
                    imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                    break;
            }
            if (urlString.EndsWith("/") == false)
            {
                urlString = urlString + "/";
            }
            string uploadFilePath = urlString + newFileName + fileNameExt; //上传文件的目标地址 
            #endregion---------------------------------------------

            #region------------------------------缩略图比率模式--------
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = ResourceImage.Width;
            int oh = ResourceImage.Height;
            switch (mode)//缩略图比率模式
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = ResourceImage.Height * width / ResourceImage.Width;
                    break;
                case "H"://指定高，宽按比例 
                    towidth = ResourceImage.Width * height / ResourceImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if ((double)ResourceImage.Width / (double)ResourceImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = ResourceImage.Height;
                        ow = ResourceImage.Height * towidth / toheight;
                        y = 0;
                        x = (ResourceImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = ResourceImage.Width;
                        oh = ResourceImage.Width * height / towidth;
                        x = 0;
                        y = (ResourceImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            #endregion---------------------------------------------
            #region--------------新建缩略图片--------------------
            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(ResourceImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
            #endregion---------------------------------------------

            #region -----------------异步上传图片--------------------

            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            byte[] uploadByte = null;
            try
            {
                using (MemoryStream oMemoryStream = new MemoryStream())
                {     //建立副本  
                    using (Bitmap oBitmap = new Bitmap(bitmap))
                    {
                        //存储图片到 MemoryStream 物，並且指定存储图像格式 
                        oBitmap.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //设定资料流位置
                        oMemoryStream.Position = 0;
                        //设定 buffer长度
                        uploadByte = new byte[oMemoryStream.Length];
                        //將资料 buffer 
                        oMemoryStream.Read(uploadByte, 0, Convert.ToInt32(oMemoryStream.Length));
                        //將所有缓冲区资料写入资料流 
                        oMemoryStream.Flush();
                    }
                }
                Uri uri = new Uri(uploadFilePath);
                client.UploadDataAsync(uri, "PUT", uploadByte, uploadByte);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
            #endregion---------------------------------------------
        }

        #endregion

        #region 注册事件
        /// <summary>
        /// 数据上传完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            try
            {
                //接收UploadDataAsync传递过来的用户定义对象
                byte[] dataByte = (byte[])e.UserState;
                if (e.Error == null)
                {
                    if (this.needUpload_images_LocalPath.Count > 0 && this.needUpload_images_newFileName.Count > 0)
                    {
                        this.needUpload_images_LocalPath.RemoveAt(0);
                        this.needUpload_images_newFileName.RemoveAt(0);
                    }
                    if (this.needUpload_images_LocalPath.Count > 0)//如果还有图片要上传
                    {
                        Image resourceImage = Image.FromFile(this.needUpload_images_LocalPath[0]);//原图片  
                        int width = 1400;
                        string mode = "W";
                        if (resourceImage.Width < width && resourceImage.Height < width)
                        {
                            width = resourceImage.Width > resourceImage.Height ? resourceImage.Width : resourceImage.Height;
                        }
                        mode = resourceImage.Width > resourceImage.Height ? "W" : "H";  //采取按宽度、高度模式缩略
                        //异步上传中等缩略图                       
                        UploadReducedImageAsync(this.needUpload_images_LocalPath[0], urlString, this.needUpload_images_newFileName[0], resourceImage, width, width, mode);
                    }
                    else
                    {
                       
                    }
                }
                else
                {
                    throw e.Error;
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
       
        /// <summary>
        /// 针对剪贴板粘贴的数据刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Html = this.ChangeShapeToImg(this.Html);//获取当前Html内容 
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }

        }
        #endregion

        #region 更新相关

        private int dataUpdate;
        private bool Updating
        {
            get
            {
                return dataUpdate != 0;
            }
        }

        private void BeginUpdate()
        {
            ++dataUpdate;
        }
        private void EndUpdate()
        {
            --dataUpdate;
        }

        #endregion

        #region 工具栏

        private void toolStripComboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("FontName", false, toolStripComboBoxName.Text);
        }
        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            int size = (toolStripComboBoxSize.SelectedItem == null) ? 1 : (toolStripComboBoxSize.SelectedItem as FontSize).Value;
            webBrowserBody.Document.ExecCommand("FontSize", false, size);
        }
        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Bold", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Italic", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Underline", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }
            int fontcolor =0;
            try
            {   //如果字符串中包含多种颜色的时候，转换会出错
                fontcolor = (int)((mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument).queryCommandValue("ForeColor");
            }
            catch
            {
            }
            try
            {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Color.FromArgb(0xff, fontcolor & 0xff, (fontcolor >> 8) & 0xff, (fontcolor >> 16) & 0xff);
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string color = dialog.Color.Name;
                    if (!dialog.Color.IsNamedColor)
                    {
                        color = "#" + color.Remove(0, 2);
                    }
                    webBrowserBody.Document.ExecCommand("ForeColor", false, color);
                }
            }
            catch
            {
            }
          
            RefreshToolBar();
        }

        private void toolStripButtonNumbers_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertOrderedList", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonBullets_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertUnorderedList", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonOutdent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Outdent", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonIndent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Indent", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyLeft", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyCenter", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyRight", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonFull_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyFull", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertHorizontalRule", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonHyperlink_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("CreateLink", true, null);
            RefreshToolBar();
        }
        private void toolStripButtonPicture_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertImage", true, null); 
            RefreshToolBar();
        }

        private void toolStripButtonUnDo_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("UnDo", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("ReDo", false, null);
            RefreshToolBar();
        }

        #endregion

        #region 浏览器

        private void webBrowserBody_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void webBrowserBody_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.IsInputKey)
            {
                return;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
              // this.Html = this.ChangeShapeToImg(this.Html);//复制其他文本时，先转换前次粘贴的文字、图片
            }
            RefreshToolBar();
        }

        private void webBrowserBody_DocumentClick(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        private void webBrowserBody_DocumentFocusing(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        #endregion

        #region 字体大小转换

        private class FontSize
        {
            private static List<FontSize> allFontSize = null;
            public static List<FontSize> All
            {
                get
                {
                    if (allFontSize == null)
                    {
                        allFontSize = new List<FontSize>();
                        allFontSize.Add(new FontSize(8, 1));
                        allFontSize.Add(new FontSize(10, 2));
                        allFontSize.Add(new FontSize(12, 3));
                        allFontSize.Add(new FontSize(14, 4));
                        allFontSize.Add(new FontSize(18, 5));
                        allFontSize.Add(new FontSize(24, 6));
                        allFontSize.Add(new FontSize(36, 7));
                    }

                    return allFontSize;
                }
            }

            public static FontSize Find(int value)
            {
                if (value < 1)
                {
                    return All[0];
                }

                if (value > 7)
                {
                    return All[6];
                }

                return All[value - 1];
            }

            private FontSize(int display, int value)
            {
                displaySize = display;
                valueSize = value;
            }

            private int valueSize;
            public int Value
            {
                get
                {
                    return valueSize;
                }
            }

            private int displaySize;
            public int Display
            {
                get
                {
                    return displaySize;
                }
            }

            public override string ToString()
            {
                return displaySize.ToString();
            }
        }

        #endregion

        #region 下拉框

        private class ToolStripComboBoxEx : ToolStripComboBox
        {
            public override Size GetPreferredSize(Size constrainingSize)
            {
                Size size = base.GetPreferredSize(constrainingSize);
                size.Width = Math.Max(Width, 0x20);
                return size;
            }
        }

        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowserBody.ShowPrintPreviewDialog();
            }
            catch
            {
            }
        }
        #endregion





    }
}
