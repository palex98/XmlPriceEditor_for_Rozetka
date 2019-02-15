using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XML
{
    public partial class Form1 : Form
    {
        static Yml_catalog catalog;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "XML (*.xml) | *.xml";
            saveFileDialog1.Filter = "XML (*.xml) | *.xml";
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filePatch = openFileDialog1.FileName;

            comboBox1.Items.Clear();

            using (var stream = new StreamReader(filePatch))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Yml_catalog));

                try
                {
                    catalog = (Yml_catalog)serializer.Deserialize(stream);
                }
                catch
                {
                    MessageBox.Show("Ошибка!\nНеверная структура файла.");
                    return;
                }
            }    
            
            foreach(var i in catalog.Shop.Categories.Category)
            {
                comboBox1.Items.Add(i.Text);
            }

            label2.Text = filePatch;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedItemText = comboBox1.SelectedItem.ToString();

            var selectedItemId = catalog.Shop.Categories.Category.Where(i => i.Text == selectedItemText).FirstOrDefault().Id;

            var itemsToChange = catalog.Shop.Offers.Offer.Where(i => i.CategoryId == selectedItemId);

            foreach (var item in itemsToChange)
            {
                double price;

                double percentValue;

                try
                {
                    double.TryParse(item.Price.Replace('.', ','), out price);

                    double.TryParse(textBox1.Text, out percentValue);

                    int newPrice = (int)price + (int)(price * (percentValue / 100));

                    item.Price = newPrice.ToString() + ".00";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            }

            MessageBox.Show("Наценка применена");

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string saveFilePatch = saveFileDialog1.FileName;

            XmlSerializer formatter = new XmlSerializer(typeof(Yml_catalog));

            string xml;

            using (StringWriter textWriter = new StringWriter())
            {
                formatter.Serialize(textWriter, catalog);

                xml = textWriter.ToString();
            }

            xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml = xml.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            xml = xml.Replace("<sales_notes />", "<sales_notes/>Возможна покупка менее 4 шт по согласованию с менеджером. Гарантия производителя");

            using (StreamWriter sw = new StreamWriter(saveFilePatch, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(xml);
            }

            MessageBox.Show("Файл успешно сохранен!\n\n" + saveFilePatch);
            GC.Collect(2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
