﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Component.User;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;

namespace ProjectCSharp
{
    public partial class UsersHome : Form
    {
        private User _user;
        private thongtincanhan thongtincanhan;
        private thaydoithongtincanhan thaydoithongtincanhan;
        private thaydoimatkhau thaydoimatkhau;
        private homepage homepage;
        private sogiaodich sogiaodich;
        private quanlydanhmuc quanlydanhmuc;

        public UsersHome()
        {
            InitializeComponent();

        }
        public UsersHome(User user)
        {

            InitializeComponent();
            _user = user;
            
        }
        private void UsersHome_Load(object sender, EventArgs e)
        {
            // mặc định usercontrol homepage sẽ được hiển thị đầu tiên
            homepage = new homepage();
            ShowUserControl(homepage);
            sidebar1.setUsersForm(this);
        }
        // ============================hàm tiêu chuẩn để gọi usercontrol=============================
        private void ShowUserControl(UserControl uc)
        {
            
            foreach (Control control in panel.Controls)
            {
                control.Visible = false;
            }
            if (!panel.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill; 
                panel.Controls.Add(uc);   
            }

            uc.Visible = true;  
            uc.BringToFront();  
        }
        // gọi các usercontrol
        public void ShowThongTinCanhan()
        {
            // bắt buộc phải khởi tạo 1 instance không thì null mất
            thongtincanhan = new thongtincanhan(_user, this);
            thongtincanhan.LoadUserInfo();
            ShowUserControl(thongtincanhan);

        }
        public void ShowQuanLyDanhMuc()
        {
            quanlydanhmuc = new quanlydanhmuc();
            ShowUserControl(quanlydanhmuc);
        }
        public void ShowThayDoiMatKhau()
        {
            thaydoimatkhau = new thaydoimatkhau(_user, this);
            ShowUserControl(thaydoimatkhau);
        }
        public void ShowThayDoiThongTin()
        {
            thaydoithongtincanhan = new thaydoithongtincanhan(_user,this);
            thaydoithongtincanhan.LoadUserInfo();
            ShowUserControl(thaydoithongtincanhan);
        }
        
        public void ShowSoGiaoDich()
        {
            sogiaodich = new sogiaodich();
            ShowUserControl(sogiaodich);
        }

        public void ShowHomePage()
        {
            homepage = new homepage();
            ShowUserControl(homepage);
        }
        // chua có nè
        public void ShowTongthuchi()
        {
            homepage = new homepage();
            ShowUserControl(homepage);
        }
    }
}