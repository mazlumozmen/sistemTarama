using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.IO;

namespace sistemTarama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] ekranKartiq = new string[2];
        public string pcAdiq, kulAdiq, ipq, macq, islemciq, osq, ramq, hddq, anakartq, yaziciq;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pcAdiq = Dns.GetHostName();
            kulAdiq = System.Windows.Forms.SystemInformation.UserName;
            listBox1.Items.Add("Bilgisayar Adı: " + Dns.GetHostName());
            listBox1.Items.Add("Kullanıcı Adı: " + System.Windows.Forms.SystemInformation.UserName);
            Ip();
            Mac();
            Islemci();
            IsletimSistemi();
            Anakart();
            Hdd();
            Ram();
            EkranKarti();
            Yazici();
            
        }

        public static int kayit = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        public void Mac()
        {
            try
            {
                String macadress = string.Empty;
                string mac = null;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    OperationalStatus ot = nic.OperationalStatus;
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macadress = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                for (int i = 0; i <= macadress.Length - 1; i++)
                {
                    mac = mac + ":" + macadress.Substring(i, 2);
                    // mac adresini alırken parça parça aldığından 
                    //aralarına : işaretini biz atıyoruz.
                    i++;
                }
                mac = mac.Remove(0, 1);
                // en sonda kalan fazladan : işaretini siliyoruz.
                macq = mac;
                listBox1.Items.Add("MAC: " + mac);
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb");
            baglan.Open();
            OleDbCommand ekle = new OleDbCommand("insert into bilgisayarOzellikleri(pcAdi,kulAdi,ip,mac,islemci,os,ram,ekranKarti,ekranKarti2,hdd,anakart,yazici) values('" + pcAdiq + "','" + kulAdiq + "','" + ipq + "','" + macq + "','" + islemciq + "','" + osq + "','" + ramq + "','" + ekranKartiq[0] + "','" + ekranKartiq[1] + "','" + hddq + "','"+anakartq+"','"+yaziciq+"')", baglan);
            ekle.ExecuteNonQuery();

            OleDbCommand komut = new OleDbCommand("select * from bilgisayarOzellikleri", baglan);
            OleDbDataReader dr = komut.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["pcAdi"].ToString());
                item.SubItems.Add(dr["kulAdi"].ToString());
                item.SubItems.Add(dr["ip"].ToString());
                item.SubItems.Add(dr["mac"].ToString());
                item.SubItems.Add(dr["anakart"].ToString());
                item.SubItems.Add(dr["islemci"].ToString());
                item.SubItems.Add(dr["os"].ToString());
                item.SubItems.Add(dr["ram"].ToString());
                item.SubItems.Add(dr["ekranKarti"].ToString());
                item.SubItems.Add(dr["ekranKarti2"].ToString());
                item.SubItems.Add(dr["hdd"].ToString());
                item.SubItems.Add(dr["yazici"].ToString());
                listView1.Items.Add(item);
                
            }
            kayit = kayit + 1;
            label2.Text = kayit.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yazdir ac = new Yazdir();
            ac.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kullanici = System.Windows.Forms.SystemInformation.UserName;
            //E:\Text_Write_And_Read.txt belirtilen yol ve isimde .txt uzantılı dosya oluşturuluyor

            StreamWriter sw = new StreamWriter(@"C:\Users\" + kullanici + "/Desktop/sistemBilgisi.txt", true);
            StreamWriter sw2 = new StreamWriter(Dns.GetHostAddresses(Dns.GetHostName())[1].ToString()+"_"+ System.Windows.Forms.SystemInformation.UserName + "_SistemBilgisi.txt", true);
            StreamWriter sw3 = new StreamWriter("SistemBilgisi.txt", true);

            sw.WriteLine("");
            sw.WriteLine("***************************************************************");
            sw.WriteLine("");
            sw2.WriteLine("");
            sw2.WriteLine("***************************************************************");
            sw2.WriteLine("");
            sw3.WriteLine("");
            sw3.WriteLine("***************************************************************");
            sw3.WriteLine("");

            try
            {
                //sw.WriteLine ile değer .txt içeriğine yazılmak üzere tutuluyor
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sw.WriteLine(listBox1.Items[i]);
                    sw2.WriteLine(listBox1.Items[i]);
                    sw3.WriteLine(listBox1.Items[i]);



                }
                MessageBox.Show("Kayıt başarılı");

            }
            catch (Exception ex)
            {
                MessageBox.Show("sanırım bir sorun var " + ex);
            }
            finally
            {
                //sw.Flush ile içerik Ram da tutulan değer .txt içerğine yazılyor
                sw.Flush();
                sw.Close();
                sw2.Flush();
                sw2.Close();
                sw3.Flush();
                sw3.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb");
            baglan.Open();

            OleDbCommand komut = new OleDbCommand("select * from bilgisayarOzellikleri", baglan);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["pcAdi"].ToString());
                item.SubItems.Add(dr["kulAdi"].ToString());
                item.SubItems.Add(dr["ip"].ToString());
                item.SubItems.Add(dr["mac"].ToString());
                item.SubItems.Add(dr["anakart"].ToString());
                item.SubItems.Add(dr["islemci"].ToString());
                item.SubItems.Add(dr["os"].ToString());
                item.SubItems.Add(dr["ram"].ToString());
                item.SubItems.Add(dr["ekranKarti"].ToString());
                item.SubItems.Add(dr["ekranKarti2"].ToString());
                item.SubItems.Add(dr["hdd"].ToString());
                item.SubItems.Add(dr["yazici"].ToString());
                listView1.Items.Add(item);
                kayit++;
                label2.Text = kayit.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            StreamReader oku;
            oku = File.OpenText("sistemBilgisi.txt");
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                // Listbox'ı .txt içeriği ile doldur.
                listBox2.Items.Add(yazi.ToString());
            }

            // Okumayı kapat.
            oku.Close();
        }

        public void Ip()
        {
            ipq = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
            listBox1.Items.Add("IPv4: " + Dns.GetHostAddresses(Dns.GetHostName())[1]);


            /* string host = Dns.GetHostName();
             IPHostEntry ip = Dns.GetHostByName(host);
             listBox1.Items.Add("IP: "+ ip.AddressList[0].ToString());*/

        }
        public void Ram()
        {
            int boyut = Environment.SystemPageSize / 1024;
            listBox1.Items.Add("RAM BOYUTU: " + boyut.ToString() + " GB");
            ramq = boyut.ToString();
            /* ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
             foreach (ManagementObject Mobject in Search.Get())
             {
                 string type="";
                 type = RamInfo.RamType;
                 string deger = Mobject["Capacity"].ToString();
                 double sayi = Convert.ToInt64(deger) / 1073741824;
                 ramq = sayi + " GB " + Mobject["Speed"] + " Mhz " + type;
                 listBox1.Items.Add(sayi + " GB "+Mobject["Speed"]+" Mhz "+ type);
             }*/





            /*foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                double ramgb = Ram_Bytes / 1073741824;
                double islem = Math.Ceiling(ramgb);
                listBox1.Items.Add(islem.ToString() + " GB  RAM "+Mobject["Speed"]);
            }*/
        }

        public void EkranKarti()
        {
            ManagementObjectSearcher ekran = new ManagementObjectSearcher("Select * From Win32_VideoController");
            int i = 0;
            foreach (ManagementObject Mobject in ekran.Get())
            {
                /*string deger = Mobject["AdapterRam"].ToString();
                double sayi = Convert.ToInt64(deger) / 1024 / 1024 / 1024;

                ekranKartiq[i] = Mobject["name"].ToString() + " " + sayi + " GB";
                i++;
                listBox1.Items.Add(Mobject["name"].ToString() + " " + sayi + " GB");*/

                ekranKartiq[i] = Mobject["name"].ToString();
                i++;
                listBox1.Items.Add("Ekran kartı: "+Mobject["name"].ToString());

            }


        }

        public void IsletimSistemi()
        {
            string isletim = "";

            ManagementObjectSearcher os_searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject bilgi in os_searcher.Get())
            {

                //İşletim sistemi ismi
                isletim = bilgi.Properties["Caption"].Value.ToString().Trim();
                //Versiyon Bilgisi
                // isletim=isletim+"   "+ "Version " + bilgi.Properties["Version"].Value.ToString() + " SP " + bilgi.Properties["ServicePackMajorVersion"].Value.ToString() + "." + bilgi.Properties["ServicePackMinorVersion"].Value.ToString();
            }//
             // Sistem Türü 32-64-bit.

            string sistem_turu = "SELECT * FROM Win32_Processor";
            ManagementObjectSearcher proc_searcher =
                new ManagementObjectSearcher(sistem_turu);
            foreach (ManagementObject bilgi in proc_searcher.Get())
            {
                osq = isletim + " " + bilgi.Properties["AddressWidth"].Value.ToString() + "-bit";
                listBox1.Items.Add(isletim + " " + bilgi.Properties["AddressWidth"].Value.ToString() + "-bit");
            }

        }

        public void Islemci()
        {
            RegistryKey Rkey1 = Registry.LocalMachine;
            Rkey1 = Rkey1.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            islemciq = (string)Rkey1.GetValue("ProcessorNameString").ToString();
            listBox1.Items.Add((string)Rkey1.GetValue("ProcessorNameString").ToString());

        }

        public class HardDrive
        {
            public string Model { get; set; }
            public string InterfaceType { get; set; }
            public string Caption { get; set; }
            public string SerialNo { get; set; }
        }

        public void Hdd()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject disk in searcher.Get())
            {
                string deger = disk["size"].ToString();
                double sayi = Convert.ToInt64(deger) / 1024 / 1024 / 1024;
                if (sayi>50)
                {
                    hddq = sayi + " GB ";
                    listBox1.Items.Add(sayi + " GB ");
                }
                
            }





            /*var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();
                listBox1.Items.Add( hd.SerialNo);
            }*/
        }

        public void Anakart()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject motherBoard in searcher.Get())
            {
                listBox1.Items.Add("Anakart: "+motherBoard["Product"].ToString());
                anakartq = motherBoard["Product"].ToString();


            }
        }

       public void Yazici()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            foreach (ManagementObject yazici in searcher.Get())
            {
                yaziciq = yazici["Name"].ToString() + " - " + yaziciq;
            }
            listBox1.Items.Add("Yazıcılar: " + yaziciq);

        }

    }
}
