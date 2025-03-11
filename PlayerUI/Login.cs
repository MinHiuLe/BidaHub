using QuanLyBanBida.DAO;
using QuanLyBanBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBida
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        #region Methods
        bool Login1(string username, string password) // hàm login1 này trả về 2 giá trị , true hoặc false
        {
            return AccountDAO.Instance.Login(username, password); // hàm kiểm tra của em là Login
        }
        #endregion

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = txt_NameID.Text; // khai biến userName gán giá trị của nó =  txt_nameID
            string passWord = txt_Password.Text;
            if (Login1(userName, passWord)) // trong login1 truyền về 2 tham số, userName và password
            {
                 Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName); // hàm này kiểm tra để lấy được tài khoản có trong data 
                 Form1 f = new Form1(loginAccount); // form 1 của em sẽ xuất hiện tùy vào tài khoản đăng nhập
                 this.Hide();
                 f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.ShowDialog(this);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {

        }
    }
}
