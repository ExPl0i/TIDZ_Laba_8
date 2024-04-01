using System.Security.Cryptography;
using System.Text;

namespace Matisov_laba_8
{
    public partial class Form1 : Form
    {
        CipherRijndael rij; // ���� Rijndael
        string keyUri;      // URI ����� � ������
        string ivUri;       // URI ����� � IV

        public Form1()
        {
            InitializeComponent();
            rij = new CipherRijndael();
            keyUri = @"C:\Users\mripo\Documents\CryptoKey\key.txt";
            ivUri = @"C:\Users\mripo\Documents\CryptoKey\iv.txt";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "������ � ������������ ���������� ���������� Rijndael";
            textBoxKey.Enabled = false;
            textBoxKey.Text = rij.Key;
            textBoxIV.Enabled = false;
            textBoxIV.Text = rij.IV;
            textBoxText.ScrollBars = ScrollBars.Vertical;
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
            saveFileDialog1.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
        }

        // �����-���������� ������� "������� �� ����� '�������' �������� ����"
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null) return;
            try
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                textBoxText.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �����-���������� ������� "������� �� ����� '��������� ���' �������� ����"
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            StreamWriter sw;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding(1251));
                    sw.Write(textBoxText.Text);
                    sw.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // �����-���������� ������� "������� �� ����� '�����' �������� ����"
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // �����-���������� ������� "������� �� ����� '�����������' �������� ����"
        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxText.Text = rij.Encrypt(textBoxText.Text);
        }

        // �����-���������� ������� "������� �� ����� '������������' �������� ����"
        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxText.Text = rij.Decrypt(textBoxText.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �����-���������� ������� "������� �� ����� '������������� ���� � IV' �������� ����"
        private void generKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.GenerKey();
            rij.GenerIV();
            textBoxKey.Text = rij.Key;
            textBoxIV.Text = rij.IV;
        }

        // �����-���������� ������� "������� �� ����� '��������� ���� � IV' �������� ����"
        private void saveKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.SaveKey(keyUri);
            rij.SaveIV(ivUri);
        }

        // �����-���������� ������� "������� �� ����� '��������� ���� � IV' �������� ����"
        private void loadKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.LoadKey(keyUri);
            rij.LoadIV(ivUri);
            textBoxKey.Text = rij.Key;
            textBoxIV.Text = rij.IV;
        }
    }

    /// <summary>
    /// ������������ ���� Rijndael
    /// </summary>
    public class CipherRijndael
    {
        Rijndael rij; // �������� Rijndael
        byte[] key;   // ����
        byte[] iv;    // ������ �������������
        CipherMode cMode;  // ����� ����������
        PaddingMode pMode; // ��� ���������� ������

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public CipherRijndael()
        {
            rij = Rijndael.Create();
            // ������������� ����� � ������� �������������
            rij.GenerateKey();
            rij.GenerateIV();
            // ���������� ����� � ������� �������������
            key = rij.Key;
            iv = rij.IV;
            cMode = CipherMode.CFB;
            pMode = PaddingMode.PKCS7;
            rij.Mode = cMode;
            rij.Padding = pMode;
        }

        /// <summary>
        /// ���������� ���� � ���� ������
        /// </summary>
        public string Key
        {
            get
            {
                // ������ ��� ������ ������ � HEX-�������
                string hex = "";
                foreach (byte b in key)
                {
                    hex += string.Format("{0:X2} ", b);
                }
                return hex;
            }
        }

        /// <summary>
        /// ���������� ������ ������������� � ���� ������
        /// </summary>
        public string IV
        {
            get
            {
                // ������ ��� ������ ������ � HEX-�������
                string hex = "";
                foreach (byte b in iv)
                {
                    hex += string.Format("{0:X2} ", b);
                }
                return hex;
            }
        }

        /// <summary>
        /// ���������� � ��������� ����
        /// </summary>
        public void GenerKey()
        {
            rij.GenerateKey();
            key = rij.Key;
        }

        /// <summary>
        /// ����������� � ��������� ������ �������������
        /// </summary>
        public void GenerIV()
        {
            rij.GenerateIV();
            iv = rij.IV;
        }

        /// <summary>
        /// ��������� � ������� ��������� Rijndael
        /// </summary>
        /// <param name="plainText">������� �����</param>
        /// <returns>����������</returns>
        public string Encrypt(string plainText)
        {
            // ��������� ������� ������ �� ��������� ������
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // ����� ������� ������
            MemoryStream msIn = new MemoryStream();
            // ����� ������ ��� ����������
            CryptoStream csIn = new CryptoStream(msIn, rij.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            // �������� ������� ������ � ����� ��� ����������
            csIn.Write(plainBytes, 0, plainBytes.Length);
            csIn.Close(); // ������� ����� ��� ����������
            // ��������� ������ ����������� �� ������� ����
            string cipherText = Convert.ToBase64String(msIn.ToArray());
            msIn.Close(); // ������� ����� ������� ������

            return cipherText;
        }

        /// <summary>
        /// ������������ � ������� ��������� Rijndael
        /// </summary>
        /// <param name="cipherText">����������</param>
        /// <returns>�������� �����</returns>
        public string Decrypt(string cipherText)
        {
            // ��������� ������� ������ �� �����������
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            // ����� ������� ������
            MemoryStream msOut = new MemoryStream();
            // ����� ������ ��� �������������
            CryptoStream csOut = new CryptoStream(msOut, rij.CreateDecryptor(key, iv), CryptoStreamMode.Read);
            // ������� ����� ��� �������������
            StreamReader sr = new StreamReader(csOut);
            // �������� ������ ��������� ������
            string plainText = sr.ReadToEnd();

            return plainText;
        }

        /// <summary>
        /// ��������� ���� � ��������� �����
        /// </summary>
        /// <param name="uri">URI �����</param>
        public void SaveKey(string uri)
        {
            StreamWriter sw = new StreamWriter(uri);
            sw.Write(Convert.ToBase64String(key));
            sw.Close();
        }

        /// <summary>
        /// ��������� IV � ��������� �����
        /// </summary>
        /// <param name="uri">URI �����</param>
        public void SaveIV(string uri)
        {
            StreamWriter sw = new StreamWriter(uri);
            sw.Write(Convert.ToBase64String(iv));
            sw.Close();
        }

        /// <summary>
        /// ��������� ���� �� ���������� �����
        /// </summary>
        /// <param name="uri">URI �����</param>
        public void LoadKey(string uri)
        {
            StreamReader sr = new StreamReader(uri);
            key = Convert.FromBase64String(sr.ReadToEnd());
            sr.Close();
        }

        /// <summary>
        /// ��������� IV �� ���������� �����
        /// </summary>
        /// <param name="uri">URI �����</param>
        public void LoadIV(string uri)
        {
            StreamReader sr = new StreamReader(uri);
            iv = Convert.FromBase64String(sr.ReadToEnd());
            sr.Close();
        }
    }

}
