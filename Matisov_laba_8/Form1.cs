using System.Security.Cryptography;
using System.Text;

namespace Matisov_laba_8
{
    public partial class Form1 : Form
    {
        CipherRijndael rij; // Шифр Rijndael
        string keyUri;      // URI файла с ключом
        string ivUri;       // URI файла с IV

        public Form1()
        {
            InitializeComponent();
            rij = new CipherRijndael();
            keyUri = @"C:\Users\mripo\Documents\CryptoKey\key.txt";
            ivUri = @"C:\Users\mripo\Documents\CryptoKey\iv.txt";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Работа с симметричным алгоритмом шифрования Rijndael";
            textBoxKey.Enabled = false;
            textBoxKey.Text = rij.Key;
            textBoxIV.Enabled = false;
            textBoxIV.Text = rij.IV;
            textBoxText.ScrollBars = ScrollBars.Vertical;
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        }

        // Метод-обработчик события "Нажатие на пункт 'Открыть' главного меню"
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
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод-обработчик события "Нажатие на пункт 'Сохранить как' главного меню"
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
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Метод-обработчик события "Нажатие на пункт 'Выход' главного меню"
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Метод-обработчик события "Нажатие на пункт 'Зашифровать' главного меню"
        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxText.Text = rij.Encrypt(textBoxText.Text);
        }

        // Метод-обработчик события "Нажатие на пункт 'Расшифровать' главного меню"
        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxText.Text = rij.Decrypt(textBoxText.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод-обработчик события "Нажатие на пункт 'Сгенерировать ключ и IV' главного меню"
        private void generKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.GenerKey();
            rij.GenerIV();
            textBoxKey.Text = rij.Key;
            textBoxIV.Text = rij.IV;
        }

        // Метод-обработчик события "Нажатие на пункт 'Сохранить ключ и IV' главного меню"
        private void saveKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.SaveKey(keyUri);
            rij.SaveIV(ivUri);
        }

        // Метод-обработчик события "Нажатие на пункт 'Загрузить ключ и IV' главного меню"
        private void loadKeyIvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rij.LoadKey(keyUri);
            rij.LoadIV(ivUri);
            textBoxKey.Text = rij.Key;
            textBoxIV.Text = rij.IV;
        }
    }

    /// <summary>
    /// Представляет шифр Rijndael
    /// </summary>
    public class CipherRijndael
    {
        Rijndael rij; // Алгоритм Rijndael
        byte[] key;   // Ключ
        byte[] iv;    // Вектор инициализации
        CipherMode cMode;  // Режим шифрования
        PaddingMode pMode; // Тип заполнения блоков

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CipherRijndael()
        {
            rij = Rijndael.Create();
            // Генерирование ключа и вектора инициализации
            rij.GenerateKey();
            rij.GenerateIV();
            // Сохоагегте ключа и вектора инициализации
            key = rij.Key;
            iv = rij.IV;
            cMode = CipherMode.CFB;
            pMode = PaddingMode.PKCS7;
            rij.Mode = cMode;
            rij.Padding = pMode;
        }

        /// <summary>
        /// Возвращает ключ в виде строки
        /// </summary>
        public string Key
        {
            get
            {
                // Строка для записи байтов в HEX-формате
                string hex = "";
                foreach (byte b in key)
                {
                    hex += string.Format("{0:X2} ", b);
                }
                return hex;
            }
        }

        /// <summary>
        /// Возвращает вектор инициализации в виде строки
        /// </summary>
        public string IV
        {
            get
            {
                // СТрока для записи байтов в HEX-формате
                string hex = "";
                foreach (byte b in iv)
                {
                    hex += string.Format("{0:X2} ", b);
                }
                return hex;
            }
        }

        /// <summary>
        /// Генирирует и сохраняет ключ
        /// </summary>
        public void GenerKey()
        {
            rij.GenerateKey();
            key = rij.Key;
        }

        /// <summary>
        /// Гененрирует и сохраняет вектор инициализации
        /// </summary>
        public void GenerIV()
        {
            rij.GenerateIV();
            iv = rij.IV;
        }

        /// <summary>
        /// Шифровать с помощью алгоритма Rijndael
        /// </summary>
        /// <param name="plainText">Откртый текст</param>
        /// <returns>Шифротекст</returns>
        public string Encrypt(string plainText)
        {
            // Получение массива байтов из открытого тектса
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Поток входных данных
            MemoryStream msIn = new MemoryStream();
            // Поток данных для шифрования
            CryptoStream csIn = new CryptoStream(msIn, rij.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            // Записать откртые данные в поток для шифрования
            csIn.Write(plainBytes, 0, plainBytes.Length);
            csIn.Close(); // Закрыть поток для шифрования
            // Получение строки шифротекста из массива байт
            string cipherText = Convert.ToBase64String(msIn.ToArray());
            msIn.Close(); // Закрыть поток входных данных

            return cipherText;
        }

        /// <summary>
        /// Расшифровать с помощью алгоритма Rijndael
        /// </summary>
        /// <param name="cipherText">Шифротекст</param>
        /// <returns>Открытый текст</returns>
        public string Decrypt(string cipherText)
        {
            // Получение массива байтов из шифротекста
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            // Поток входных данных
            MemoryStream msOut = new MemoryStream();
            // Поток данных для расшифрования
            CryptoStream csOut = new CryptoStream(msOut, rij.CreateDecryptor(key, iv), CryptoStreamMode.Read);
            // Считать поток для расшифрования
            StreamReader sr = new StreamReader(csOut);
            // Получить строки открытого текста
            string plainText = sr.ReadToEnd();

            return plainText;
        }

        /// <summary>
        /// Сохраняет ключ в текстовом файле
        /// </summary>
        /// <param name="uri">URI файла</param>
        public void SaveKey(string uri)
        {
            StreamWriter sw = new StreamWriter(uri);
            sw.Write(Convert.ToBase64String(key));
            sw.Close();
        }

        /// <summary>
        /// Сохраняет IV в текстовом файле
        /// </summary>
        /// <param name="uri">URI файла</param>
        public void SaveIV(string uri)
        {
            StreamWriter sw = new StreamWriter(uri);
            sw.Write(Convert.ToBase64String(iv));
            sw.Close();
        }

        /// <summary>
        /// Загружают ключ из текстового файла
        /// </summary>
        /// <param name="uri">URI файла</param>
        public void LoadKey(string uri)
        {
            StreamReader sr = new StreamReader(uri);
            key = Convert.FromBase64String(sr.ReadToEnd());
            sr.Close();
        }

        /// <summary>
        /// Загружает IV из текстового файла
        /// </summary>
        /// <param name="uri">URI файла</param>
        public void LoadIV(string uri)
        {
            StreamReader sr = new StreamReader(uri);
            iv = Convert.FromBase64String(sr.ReadToEnd());
            sr.Close();
        }
    }

}
