using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform多线程控件控制
{
    public partial class Form1 : Form
    {
        Thread t;
        private bool isStopped = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetNoCheckFOrIllegalCrossThreadCalls();
            // StartTimer();
            //StartTimer1();
            //StartTimer2();
        }

        #region 会出错的多线程调用
        /// <summary>
        /// 会报错的多线程调用
        /// System.InvalidOperationException”类型的未经处理的异常在 System.Windows.Forms.dll 中发生 
        ///其他信息: 线程间操作无效: 从不是创建控件“lblTime”的线程访问它。
        /// </summary>
        void StartTimer()
        {

            Thread t = new Thread(() =>
            {
                lblTime.Text = DateTime.Now.ToString("yyyy/MM/DD HH:mm:ss");
                Thread.Sleep(1000);
            });
            t.IsBackground = true;
            t.Start();
        }
        #endregion

        #region 方法0： 全局设置允许跨线程调用控件， Control.CheckForIllegalCrossThreadCalls = false;
        void SetNoCheckFOrIllegalCrossThreadCalls()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            StartTimer1();
        }
        #endregion

        #region 方法1：使用代理来解决跨线程调用控件问题,需要父级控件中调用Invoke
        public delegate void DoWorkDelegate(string msg);
        void StartTimer1()
        {
            // Thread.
            t = new Thread(() =>
            {
                string p = "StartTimer1";
                DoWorkDelegate d = new DoWorkDelegate((pt) =>
                {

                    lblTime.Text = pt + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                });
                while (!isStopped)
                {
                    this.Invoke(d, p);
                    Thread.Sleep(2000);
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        #endregion

        #region 方法2：使用MethodInvoke方法来实现跨线程调用,其原理和方法1一样，只是用MethodInvoker代替自定义的Delegate
        void StartTimer2()
        {
            t = new Thread(() =>
            {
                MethodInvoker invoker = new MethodInvoker(() =>
                {

                    lblTime.Text = "StartTimer2:" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                });
                while (!isStopped)
                {
                    this.Invoke(invoker);
                    Thread.Sleep(2000);
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        #endregion


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isStopped = true;
            if (t != null)
            {
                t.Abort();
            }
        }
    }
}
