using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using WMPLib;
using System.Runtime.InteropServices;

namespace GameTiengAnhDienTu
{
    public partial class WordFillGame : Form
    {
        #region Khai báo các biến toàn cục
        int luotChoi, soCoin, timer, soIdea, sTTQuestionHienTai;
        RoundedPanel pnLuotChoi, pnCoin;
        Panel pnIdea;
        Label lbTime, lbLuotChoi, lbCoin, lbIdea;
        RoundLabel lbCauHoi;
        PictureBox picBoxQuestion;
        Button[] btGoiY;
        RoundedButton btIdea;
        TextBox[] txtDapAn;
        Random rand = new Random();
        WMPLib.WindowsMediaPlayer play, play1;
        string[] listPicture; //danh sach chua duong dan cua anh
        int viTri; //vi tri xuat hien cua hinh
        int[] indexDaDung; //danh sach vi tri xuat hien của hinh trong 1 lan choi
        int soLuongTextBox; //so luong textbox dung de dien dap an
        string[] dapAn; //danh sach cau tra loi cua tung hinh
        int soLuongAnhDaDung; //so luong anh da dung trong mot lan choi 
        int soLuongIdDaDung; //so luong vị trí các từ trong đáp án đã được gọi ý
        int[] idDaDung; //danh sách chứa các vị trí các từ trong đáp án đã gợi ý
        char[] kyTuDapAn;
        int soLuongTxtDaNhap;//số lượng các ô textbox đáp án đã được nhập 
        public object ApplicationView { get; private set; }

        #endregion


        public WordFillGame()
        {
 
            InitializeComponent();
            play = new WMPLib.WindowsMediaPlayer();
            play1 = new WMPLib.WindowsMediaPlayer();
            luotChoi = 2;
        }
        
        //Khoi tao du lieu
        private void InitData()
        {
            luotChoi = 2;
            soCoin = 0;
            timer = 60;
            soIdea = 1;
            sTTQuestionHienTai = 1;
            StreamReader readFile = new StreamReader(Application.StartupPath + @"\Answer.txt");
            String fileData = readFile.ReadToEnd();
            dapAn = fileData.Split('\n'); //danh sach luu tung dong du lieu cua file
            listPicture = new string[dapAn.Length - 1];
            for (int i = 0; i < dapAn.Length - 1; ++i)
            {
                listPicture[i] = @"Picture Game\" + (i + 1) + ".jpg";
            }
            viTri = rand.Next(0, dapAn.Length - 1);
            indexDaDung = new int[dapAn.Length - 1];
            for(int i =0; i < indexDaDung.Length; ++i)
            {
                indexDaDung[i] = new int();
            }
            kyTuDapAn = new char[dapAn[viTri].Length - 1];
            for (int i = 0; i < kyTuDapAn.Length; ++i)
            {
                kyTuDapAn[i] = dapAn[viTri][i];
            }
            idDaDung = new int[kyTuDapAn.Length];
            soLuongAnhDaDung = 0;
            soLuongTxtDaNhap = 0;
            soLuongIdDaDung = 0;
        }

        //Khoi tao hien thi luot choi
        private void InitLuotChoi()
        {
            //Tao 1 panel luot choi
            pnLuotChoi = new RoundedPanel();
            pnLuotChoi.Location = new Point(50, 20);
            pnLuotChoi.Size = new Size(130, 45);
            pnLuotChoi.BackColor = Color.FromArgb(255, 224, 192);
            pnLuotChoi.BorderStyle = BorderStyle.None;

            //Tao 1 pictureBox bieu tuong luot choi
            PictureBox picBoxLuotChoi = new PictureBox();
            picBoxLuotChoi.Image = Image.FromFile(Application.StartupPath + @"\Picture BackGround\heart.jpg");
            picBoxLuotChoi.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxLuotChoi.Size = new Size(33, 33);
            picBoxLuotChoi.Location = new Point(18, 6);

            //Tao 1 lable hien thi so luot choi
            lbLuotChoi = new Label();
            lbLuotChoi.Location = new Point(picBoxLuotChoi.Location.X + 3, picBoxLuotChoi.Location.Y + 5);
            lbLuotChoi.ForeColor = Color.FromArgb(53, 45, 125);
            lbLuotChoi.TextAlign = ContentAlignment.MiddleCenter;
            lbLuotChoi.Font = new Font("Lucida Handwriting", 15, FontStyle.Bold);
            lbLuotChoi.Text = String.Format("{0}", luotChoi);

            //Them cac control vao panel
            pnLuotChoi.Controls.AddRange(new Control[] { picBoxLuotChoi, lbLuotChoi });

            //Them cac control vao form
            this.Controls.Add(pnLuotChoi);
        }

        //Khoi tao hien thi Coin
        private void InitCoin()
        {
            //Tao 1 panel coin
            pnCoin = new RoundedPanel();
            pnCoin.Location = new Point(pnLuotChoi.Location.X + pnLuotChoi.Width + 50, pnLuotChoi.Location.Y);
            pnCoin.Size = new Size(135, 45);
            pnCoin.BackColor = Color.FromArgb(255, 224, 192);
            pnCoin.BorderStyle = BorderStyle.None;

            //Tao 1 pictureBox bieu tuong coin
            PictureBox picBoxCoin = new PictureBox();
            picBoxCoin.Image = Image.FromFile(Application.StartupPath + @"\Picture BackGround\coin.jpg");
            picBoxCoin.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxCoin.Size = new Size(35, 35);
            picBoxCoin.Location = new Point(18, 4);

            //Tao 1 lable hien thi so coin
            lbCoin = new Label();
            lbCoin.Location = new Point(picBoxCoin.Location.X + 8 , picBoxCoin.Location.Y + 5);
            lbCoin.ForeColor = Color.FromArgb(53, 45, 125);
            lbCoin.TextAlign = ContentAlignment.MiddleCenter;
            lbCoin.Font = new Font("Lucida Handwriting", 15, FontStyle.Bold);
            lbCoin.Text = String.Format("{0}", soCoin);

            //Them cac control vao panel
            pnCoin.Controls.AddRange(new Control[] { picBoxCoin, lbCoin });

            //Them panel vao form
            this.Controls.Add(pnCoin);
        }

        //Khoi tao timer
        private void InitTimer()
        {
            //Tao 1 lable hien thi thoi gian con lai
            lbTime = new Label();
            lbTime.Size = new Size(200, 50);
            lbTime.Location = new Point(ClientRectangle.Width - lbTime.Width - 100, pnCoin.Location.Y + 5);
            lbTime.ForeColor = Color.FromArgb(53, 45, 125);
            lbTime.TextAlign = ContentAlignment.MiddleCenter;
            lbTime.Font = new Font("Segoe Print", 20, FontStyle.Bold);
            lbTime.Text = String.Format("Time: {0 : 00}", timer);

            //Them label vao form
            this.Controls.Add(lbTime);
        }

        //Khoi tao so goi y
        private void InitIdea()
        {
            //Tao 1 panel goi y
            pnIdea = new Panel();
            pnIdea.Size = new Size(75, 60);
            pnIdea.Location = new Point(ClientRectangle.Width - pnIdea.Width - 50, lbTime.Location.Y + 70);
            pnIdea.BackColor = Color.FromArgb(192, 255, 255);
            pnIdea.BorderStyle = BorderStyle.None;

            //Tao button goi y
            btIdea = new RoundedButton();
            btIdea.Size = new Size(50, 50);
            btIdea.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Picture BackGround\idea.jpg");
            btIdea.BackgroundImageLayout = ImageLayout.Stretch;
            btIdea.Text = "";
            btIdea.Click += BtIdea_Click;
            btIdea.MouseEnter += BtIdea_MouseEnter;
            btIdea.MouseLeave += BtIdea_MouseLeave;

            //Tao label hien thi so goi y duoc su dung
            lbIdea = new Label();
            lbIdea.Location = new Point(btIdea.Location.X + btIdea.Width, btIdea.Location.Y);
            lbIdea.Size = new Size(30, 20);
            lbIdea.ForeColor = Color.Black;
            lbIdea.BackColor = Color.Red;
            lbIdea.TextAlign = ContentAlignment.MiddleCenter;
            lbIdea.BorderStyle = BorderStyle.Fixed3D;
            lbIdea.Font = new Font("Microsoft Sans Serif", 10);
            lbIdea.Text = String.Format("{0}", soIdea);

            //Them cac control vao panel
            pnIdea.Controls.AddRange(new Control[] { btIdea, lbIdea });

            //Them panel vao form
            this.Controls.Add(pnIdea);
        }

        //Khoi tao STT Cau hoi hien tai
        private void InitSttQuestion()
        {
            //Tao lable hien thi nguoi choi dang o cau hoi bao nhieu
            lbCauHoi = new RoundLabel();
            lbCauHoi.Size = new Size(320, 50);
            lbCauHoi.Location = new Point(pnCoin.Location.X - 5, pnIdea.Location.Y);
            lbCauHoi.BackColor = Color.FromArgb(255, 193, 0);
            lbCauHoi.ForeColor = Color.Red;
            lbCauHoi.TextAlign = ContentAlignment.MiddleCenter;
            lbCauHoi.Font = new Font("Brush Script MT", 23, FontStyle.Bold);
            lbCauHoi.Text = String.Format("Câu hỏi số: {0 : 00}", sTTQuestionHienTai);

            //Them label vao form
            this.Controls.Add(lbCauHoi);
        }

        //Khoi tao cau hoi (hinh anh)
        private void InitQuestion()
        {
            //Tao 1 pictureBox cau hoi
            picBoxQuestion = new PictureBox();
            picBoxQuestion.Size = new Size(350, 230);
            picBoxQuestion.Location = new Point(100, lbCauHoi.Location.Y + 100);
            picBoxQuestion.BackgroundImage = Image.FromFile(listPicture[viTri]);
            picBoxQuestion.BackgroundImageLayout = ImageLayout.Stretch;
            picBoxQuestion.BorderStyle = BorderStyle.FixedSingle;

            //Them pictureBox vao form
            this.Controls.Add(picBoxQuestion);

        }

        //Phát sinh tự động các textbox đáp án
        private void PhatSinhTxtDapAn()
        {
            #region Phat sinh tu dong cac dap an
            soLuongTextBox = dapAn[viTri].Length - 1;
            //Tao textbox de dien dap an
            txtDapAn = new TextBox[soLuongTextBox];

            //textbox dau tien
            txtDapAn[0] = new TextBox();
            txtDapAn[0].BackColor = Color.FromArgb(255, 255, 128);
            txtDapAn[0].Size = new Size(30, 30);
            txtDapAn[0].Location = new Point(picBoxQuestion.Location.X, picBoxQuestion.Location.Y + picBoxQuestion.Height + 50);
            txtDapAn[0].Cursor = Cursors.Arrow;
            this.Controls.Add(txtDapAn[0]);
            txtDapAn[0].Click += WordFillGame_Click1;
            txtDapAn[0].KeyPress += WordFillGame_KeyPress;
            txtDapAn[0].MouseEnter += WordFillGame_MouseEnter1;
            txtDapAn[0].MouseLeave += WordFillGame_MouseLeave1;

            //cac textbox con lai
            for (int i = 1; i < soLuongTextBox; ++i)
            {
                txtDapAn[i] = new TextBox();
                txtDapAn[i].BackColor = Color.FromArgb(255, 255, 128);
                txtDapAn[i].Size = new Size(30, 30);
                txtDapAn[i].Location = new Point(txtDapAn[i - 1].Location.X + txtDapAn[i - 1].Size.Width + 5, txtDapAn[i - 1].Location.Y);
                txtDapAn[i].Cursor = Cursors.Arrow;
                this.Controls.Add(txtDapAn[i]);
                txtDapAn[i].Click += WordFillGame_Click1;
                txtDapAn[i].KeyPress += WordFillGame_KeyPress;
                txtDapAn[i].MouseEnter += WordFillGame_MouseEnter1;
                txtDapAn[i].MouseLeave += WordFillGame_MouseLeave1;

            }
            #endregion
        }

        //Phat sinh tu dong cac button goi y dap an
        private void PhatSinhBtGoiY()
        {
            #region Phat sinh tu dong cac goi y dap an
            //tao button goi y dap an

            btGoiY = new Button[soLuongTextBox * 2];

            //button thu nhat
            btGoiY[0] = new Button();
            btGoiY[0].Location = new Point(picBoxQuestion.Location.X + picBoxQuestion.Width + 80, picBoxQuestion.Location.Y);
            btGoiY[0].Size = new Size(35, 35);
            btGoiY[0].BackColor = Color.FromArgb(255, 128, 128);
            this.Controls.Add(btGoiY[0]);
            btGoiY[0].Click += WordFillGame_Click; //tao su kien Click cho button thu nhat
            btGoiY[0].MouseLeave += WordFillGame_MouseLeave;
            btGoiY[0].MouseEnter += WordFillGame_MouseEnter;

            //button thu hai
            btGoiY[1] = new Button();
            btGoiY[1].Location = new Point(btGoiY[0].Location.X + btGoiY[0].Width + 25, btGoiY[0].Location.Y);
            btGoiY[1].Size = new Size(35, 35);
            btGoiY[1].BackColor = Color.FromArgb(255, 128, 128);
            this.Controls.Add(btGoiY[1]);
            btGoiY[1].Click += WordFillGame_Click; //tao su kien Click cho button thu hai
            btGoiY[1].MouseLeave += WordFillGame_MouseLeave;
            btGoiY[1].MouseEnter += WordFillGame_MouseEnter;

            //cac button con lai
            for (int i = 2; i < soLuongTextBox * 2; i++)
            {
                btGoiY[i] = new Button();
                btGoiY[i].Location = new Point(btGoiY[i - 2].Location.X, btGoiY[i - 2].Location.Y + btGoiY[i - 2].Height + 5);
                btGoiY[i].Size = new Size(35, 35);
                btGoiY[i].BackColor = Color.FromArgb(255, 128, 128);
                this.Controls.Add(btGoiY[i]);
                btGoiY[i].Click += WordFillGame_Click; // su kien Click cho cac button con lai
                btGoiY[i].MouseLeave += WordFillGame_MouseLeave;
                btGoiY[i].MouseEnter += WordFillGame_MouseEnter;
            }

            #endregion 
        }

        //Phat sinh cac text trong cac button goi y dap an
        private void PhatSinhTextBtGoiY()
        {
            #region Phat sinh cac text trong cac button goi y dap an
            char[] kyTuGoiYDapAn = new char[btGoiY.Length];

            //Dua cac ky tu trong dap an vao trong danh sach cac ky tu goi y dap an
            for (int i = 0; i < kyTuGoiYDapAn.Length/2; ++i)
            {
                kyTuGoiYDapAn[i] = dapAn[viTri][i];
            }

            //Phat sinh cac ky tu con lai trong danh sach cac ky tu goi y daap an
            //Lay cac ky tu trong bang chu cai hoa tu A (65) den Z (90) theo ma ASCII 
            for(int i = kyTuGoiYDapAn.Length/2; i< kyTuGoiYDapAn.Length; ++i)
            {
                kyTuGoiYDapAn[i] = (Char)rand.Next(65, 91);
            }

            //Tron lan va doc len cac button goi y
            int[] viTriDaDung = new int[kyTuGoiYDapAn.Length]; //luu cac vi tri cac ki tu da duoc random
            int soLuong = 0;
            for(int i = 0; i < kyTuGoiYDapAn.Length; ++i)
            {
                int idx = rand.Next(0, kyTuGoiYDapAn.Length);

                if (i == 0)
                {
                    //Hien thi text len button
                    btGoiY[i].Text = kyTuGoiYDapAn[idx].ToString();

                    //Cap nhat lai danh sach vi tri cac ky tu da dung
                    viTriDaDung[soLuong++] = idx;
                }
                else
                {
                    bool check;
                    do
                    {
                        check = true;
                        for (int j = 0; j < soLuong; j++)
                        {
                            if (idx == viTriDaDung[j])
                            {
                                check = false;
                                idx = rand.Next(0, kyTuGoiYDapAn.Length);
                                break;
                            }
                        }
                        if (check == true)
                        {
                            //Hien thi text len button
                            btGoiY[i].Text = kyTuGoiYDapAn[idx].ToString();

                            //Cap nhat lai danh sach vi tri cac ky tu da dung
                            viTriDaDung[soLuong++] = idx;
                        }
                    } while (check == false);
                }
            }

            #endregion
        }

        //Kiem tra thời gian người chơi làm 1 câu có vượt quá không
        private void KTraThGianLamMotCauHoi()
        {
            if(timer == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Your reply time has ended!!!");
                luotChoi--;
                if(luotChoi <= 0)
                {
                    lbLuotChoi.Text = luotChoi.ToString();
                    if (MessageBox.Show("GAMEOVER!!!\n\nDo you want to continue playing game?", "News", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Controls.Clear();
                        this.Controls.AddRange(new Control[] { panel1, label2, btPlay });
                        ResetBackGroundMusic();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    lbLuotChoi.Text = luotChoi.ToString();
                    ResetBackGroundMusic();
                    foreach (TextBox txt in txtDapAn)
                    {
                        txt.Text = "";
                        txt.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    foreach (Button bt in btGoiY)
                    {
                        bt.Visible = true;
                    }
                    timer = 60;
                    timer1.Enabled = true;
                    timer1.Start();
                }

            }
        }

        
        //Kiểm tra textbox đã lấp đầy chưa... nếu đã được lấp đầy thì kiểm tra đáp án, đúng thì chuyển sang câu tiếp theo
        private void KtTextBoxFull()
        {
            bool check = false;
            foreach (TextBox txtBox in txtDapAn)
            {
                if (txtBox.Text == "")
                {
                    check = true; //da phat hien ra van con textbox con trong
                    break;
                }
            }
            if (check == false)
            {
                timer1.Stop();
                string s = "";
                for (int i = 0; i < txtDapAn.Length; ++i)
                {
                    s += txtDapAn[i].Text;
                }
                s += dapAn[viTri][dapAn[viTri].Length - 1].ToString();

                //So sanh voi dap an de biet dung sai (Khong phan biet hoa thuong)
                if (String.Compare(s.ToUpper(), dapAn[viTri].ToString().ToUpper(), true) == 0)
                {
                    play1.URL = "2.wav";
                    play1.controls.play();
                    MessageBox.Show("Congratulations... you answered correctly!!!", "Congratulations");
                    soCoin += 20;
                    lbCoin.Text = soCoin.ToString();
                    lbIdea.Text = (++soIdea).ToString();
                    lbLuotChoi.Text = (++luotChoi).ToString();
                    ChuyenSangCauTiepTheo();
                }
                else
                {
                    play1.URL = "3.wav";
                    play1.controls.play();
                    MessageBox.Show("Sorry, this answer is not correct!!!");
                    luotChoi--;
                    kyTuDapAn = new char[dapAn[viTri].Length - 1];
                    for (int i = 0; i < kyTuDapAn.Length; ++i)
                    {
                        kyTuDapAn[i] = dapAn[viTri][i];
                    }
                    idDaDung = new int[kyTuDapAn.Length];
                    soLuongIdDaDung = 0;
                    soLuongTxtDaNhap = 0;
                    if (luotChoi == 0)
                    {
                        if (MessageBox.Show("GAMEOVER!!!\n\nDo you want to continue playing game?", "News", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Controls.Clear();
                            this.Controls.AddRange(new Control[] { panel1, label2, btPlay });
                        }
                        else
                        {
                            Close();
                        }

                    }
                    else
                    {
                        lbLuotChoi.Text = luotChoi.ToString();
                        foreach (TextBox txt in txtDapAn)
                        {
                            txt.Text = "";
                            txt.BackColor = Color.FromArgb(255, 255, 128);
                        }
                        foreach (Button bt in btGoiY)
                        {
                            bt.Visible = true;
                        }
                        timer = 60;
                        timer1.Start();
                    }
                }
            }
        }

        //Chuyển sang câu tiếp theo
        private void ChuyenSangCauTiepTheo()
        {
            bool kiemTra; //Kiểm tra ảnh load lên có trùng với ảnh đã được load lên trước đó
            do
            {
                viTri = rand.Next(0, dapAn.Length - 1);
                kiemTra = true; //Giả sử không trùng
                for (int i = 0; i < soLuongAnhDaDung; ++i)
                {
                    if (indexDaDung[i] == viTri)
                    {
                        kiemTra = false; //Phát hiện trùng
                        break;
                    }
                }
                if (kiemTra == true) //nếu không trùng thì load ảnh lên đồng thời reset lại dữ liệu để sang câu mới
                {
                    picBoxQuestion.BackgroundImage = Image.FromFile(listPicture[viTri]);
                    picBoxQuestion.BackgroundImageLayout = ImageLayout.Stretch;
                    indexDaDung[soLuongAnhDaDung] = viTri;
                    soLuongAnhDaDung++;
                    ResetBackGroundMusic();
                    soLuongIdDaDung = 0;
                    kyTuDapAn = new char[dapAn[viTri].Length - 1];
                    for (int i = 0; i < kyTuDapAn.Length; ++i)
                    {
                        kyTuDapAn[i] = dapAn[viTri][i];
                    }
                    idDaDung = new int[kyTuDapAn.Length];

                    //reset lại các testbox đã được dinh ra ở câu trước
                    foreach (TextBox txt in txtDapAn)
                    {
                        this.Controls.Remove(txt);
                    }

                    //Khởi tạo lại các textbox cho câu sau
                    PhatSinhTxtDapAn();

                    //Reset lại các button gợi ý đáp án ở câu trước
                    foreach (Button bt in btGoiY)
                    {
                        this.Controls.Remove(bt);
                    }

                    //Khởi tạo lại các button gợi ý cho câu sau
                    PhatSinhBtGoiY();
                    PhatSinhTextBtGoiY();

                    //Khởi tạo lại thời gian quy định làm cho câu tiếp theo
                    timer = 60;
                    lbTime.Text = String.Format("Time: {0 : 00}", timer);
                    timer1.Start();

                    //Cập nhật lại người chơi đang ở câu hỏi nào
                    sTTQuestionHienTai++;
                    lbCauHoi.Text = String.Format("Câu hỏi số: {0:00}", sTTQuestionHienTai);

                    //Cập nhận lại số lượng textbox đáp án đã nhập
                    soLuongTxtDaNhap = 0;

                }
            } while (kiemTra == false);
            

            //kiem tra da lam het tat ca cac cau hoi chua
            if(sTTQuestionHienTai == listPicture.Length + 1)
            {
                this.Controls.Clear();
                if ((MessageBox.Show("Congratulations on winning!!!\n\nDo you want to continue playing game?", "Congratulations", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    this.Controls.AddRange(new Control[] { panel1, label2, btPlay }); 
                }
                else
                {
                    Close();
                }
            }
        }

        private void ResetBackGroundMusic()
        {
            //reset lại nhạc nền
            if (btSound.Visible == true)
            {
                play.URL = "1.wav";
                play.controls.play();
            }
        }

        #region Danh sách các sự kiện
        /*Su kien timer khi nguoi choi nhan PLAY NOW
        Khi nguoi choi bat dau choi thi thgian se tu dong quay nguoc
        Nếu hết thời gian sẽ kết thúc lượt chơi*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer > 0)
            {
                timer--;
                lbTime.Text = String.Format("Time: {0 : 00}", timer);
            }
            KTraThGianLamMotCauHoi();
        }


        /*Su kien Click cho cac button goi y dap an
        Kiem tra cac textbox đã được lấp đầy chưa
        Nếu rồi thì chuyển sang câu tiếp theo. Ngược lại thì tiếp tục làm câu hiện tại*/
        private void WordFillGame_Click(object sender, EventArgs e)
        {

            //Dien dap an vao tung o dap an theo thu tu tu trai sag phai khi nhan button goi y dap an
            for (int i = 0; i < txtDapAn.Length; ++i)
            {
                if (txtDapAn[i].Text == "")
                {
                    soLuongTxtDaNhap++;
                    txtDapAn[i].Text = ((Button)sender).Text; //dien dap an vao o trong
                    txtDapAn[i].BackColor = Color.FromArgb(255, 128, 128);
                    txtDapAn[i].TextAlign = HorizontalAlignment.Center;
                    txtDapAn[i].ForeColor = Color.Black;
                    ((Button)sender).Visible = false; //ẩn button sau khi đã nhấn
                    break;
                }
            }


            //Kiem tra cac o textbox da duoc lấp đầy hay chua
            KtTextBoxFull();

        }

        //Su kien Click cho cac textbox dap an
        private void WordFillGame_Click1(object sender, EventArgs e)
        {
            /*Lấy text của textbox đi vào danh sách các button 
            tìm ra các button đã bị ẩn có text trùng với text của textbox để hiện nó lên*/
            foreach (Button bt in btGoiY)
            {
                if (bt.Visible == false && bt.Text == ((TextBox)sender).Text)
                {
                    soLuongTxtDaNhap--;
                    bt.Visible = true;
                    break;
                }
            }

            //reset lại text của các textbox
            ((TextBox)sender).ResetText();
            ((TextBox)sender).BackColor = Color.FromArgb(255, 255, 128);
        }

        //Sự kiện Click cho button thực hiện gợi ý 
        private void BtIdea_Click(object sender, EventArgs e)
        {
            /*lấy một ký tự bất kì của đáp án trong danh sách các ký tự gợi ý đưa vào vị trí thích hợp của textbox đáp án,
            sau đó ẩn button đã điền vào textbox và hiện kí tự đó lên textbox*/

            Random rd = new Random();
            bool kTraId; //Kiểm tra id có trùng hay không

            if (soIdea > 0) //Trường hợp vẫn còn hint
            {

                //Kiểm tra nếu trùng vị trí thì random lại
                do
                {
                    kTraId = true; //Giả sử nếu không trùng
                    int id = rd.Next(soLuongTxtDaNhap, kyTuDapAn.Length);
                    for (int i = 0; i < soLuongIdDaDung; ++i)
                    {
                        if (id == idDaDung[i])
                        {
                            kTraId = false; //Phát hiện trùng
                            break;
                        }
                    }
                    if (kTraId == true) //Nếu không trùng
                    {
                        idDaDung[soLuongIdDaDung] = id;
                        soLuongIdDaDung++;
                        txtDapAn[id].Text = kyTuDapAn[id].ToString();
                        txtDapAn[id].BackColor = Color.FromArgb(255, 128, 128);
                        txtDapAn[id].TextAlign = HorizontalAlignment.Center;
                        foreach(Button bt in btGoiY)
                        {
                            if(bt.Text == txtDapAn[id].Text)
                            {
                                bt.Visible = false;
                                break;
                            }
                        }
                        soIdea--;
                        lbIdea.Text = soIdea.ToString();
                    }
                } while (kTraId == false);
            }
            else //Trường hợp hết hint phải dùng coin
            {
                soCoin -= 10;
                if (soCoin >= 0)
                {
                    lbCoin.Text = soCoin.ToString();

                    //Kiểm tra nếu trùng vị trí thì random lại
                    do
                    {
                        kTraId = true; //Giả sử nếu không trùng
                        int id = rd.Next(soLuongTxtDaNhap, kyTuDapAn.Length);
                        for (int i = 0; i < soLuongIdDaDung; ++i)
                        {
                            if (id == idDaDung[i])
                            {
                                kTraId = false; //Phát hiện trùng
                                break;
                            }
                        }
                        if (kTraId == true) //Nếu không trùng
                        {
                            idDaDung[soLuongIdDaDung] = id;
                            soLuongIdDaDung++;
                            txtDapAn[id].Text = kyTuDapAn[id].ToString();
                            txtDapAn[id].BackColor = Color.FromArgb(255, 128, 128);
                            txtDapAn[id].TextAlign = HorizontalAlignment.Center;
                            btGoiY[id].Visible = false;
                            lbIdea.Text = "0";
                        }
                    } while (kTraId == false);
                }
                else
                {
                    MessageBox.Show("You don't enough coin to use the hint!\n\nYou need at least 10 coins to use the hint!", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            KtTextBoxFull();

        }

        //Sự kiện chuột cho các button gợi ý đáp án
        private void WordFillGame_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 128, 128);
            ((Button)sender).ForeColor = Color.Black;
            ((Button)sender).Size = new Size(35, 35);
        }

        private void WordFillGame_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(192, 0, 0);
            ((Button)sender).ForeColor = Color.White;
            ((Button)sender).Size = new Size(40, 40);
        }

        //Sự kiện chuột của các textbox điền đáp án
        private void WordFillGame_MouseLeave1(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).BackColor = Color.FromArgb(255, 255, 128); 
            }
            else
            {
                ((TextBox)sender).BackColor = Color.FromArgb(255, 128, 128);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        ////Sự kiện Click của roundbutton1 NotSound
        private void btNotSound_Click(object sender, EventArgs e)
        {
                btNotSound.Visible = false;
                btSound.Visible = true;
                play.URL = "1.wav";
                play.controls.play();    
        }

        //Sự kiện Click của roundbutton1 Sound
        private void btSound_Click(object sender, EventArgs e)
        {
            btNotSound.Visible = true;
            btSound.Visible = false;
            play.URL = "1.wav";
            play.controls.stop();
        }

        //Sự kiện Form Load
        private void WordFillGame_Load(object sender, EventArgs e)
        {
            btSound.Visible = true;
            btNotSound.Visible = false;
            play.URL = "1.wav";
            play.controls.play();
        }

        //Sự kiện chuột của roundbutton1 (Sound và NotSound)
        private void btNotSound_MouseEnter(object sender, EventArgs e)
        {
            ((RoundButton1)sender).Size = new Size(57, 57);
        }

        private void btNotSound_MouseLeave(object sender, EventArgs e)
        {
            ((RoundButton1)sender).Size = new Size(52, 52);
        }

        private void WordFillGame_MouseEnter1(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).BackColor = Color.FromArgb(255, 193, 0); 
            }
            else
            {
                ((TextBox)sender).BackColor = Color.FromArgb(192, 0, 0);
                ((TextBox)sender).ForeColor = Color.White;
            }
        }
        //Sự kiện chuột cho button thực hiện gợi ý đáp án
        private void BtIdea_MouseLeave(object sender, EventArgs e)
        {
            btIdea.Size = new Size(50, 50);
        }

        private void BtIdea_MouseEnter(object sender, EventArgs e)
        {
            btIdea.Size = new Size(55, 55);
        }

        
        //Sự kiện chuột cho button Play
        private void btPlay_MouseEnter(object sender, EventArgs e)
        {
            btPlay.Size = new Size(200, 80);
        }

        private void btPlay_MouseLeave(object sender, EventArgs e)
        {
            btPlay.Size = new Size(190, 70);
        }

        //Sự kiện bàn phím cho các textbox đáp án
        private void WordFillGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //Sự kiện Click của button Play
        private void btPlay_Click(object sender, EventArgs e)
        {
            ResetBackGroundMusic();
            play1.URL = "0.wav";
            play1.controls.play();
            this.Controls.Remove(panel1);
            this.Controls.Remove(label2);
            this.Controls.Remove(btPlay);
            timer1.Enabled = true;
            timer1.Start(); //bat dau su kien timer
            InitData();
            KTraThGianLamMotCauHoi();
            InitLuotChoi();
            InitCoin();
            InitTimer();
            InitIdea();
            InitSttQuestion();
            InitQuestion();
            PhatSinhTxtDapAn();
            PhatSinhBtGoiY();
            PhatSinhTextBtGoiY();
        }

        //Sự kiện đóng game
        private void WordFillGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (luotChoi <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to close game?", "News", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } 
        #endregion
    }
}
