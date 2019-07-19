using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace OverwriteDeleteFiles
{
    class Program
    {
        private static UtilityLibrary.UtilityLibrary ul;
        private static Random rnd = new Random();

        [STAThread]
        static void Main(string[] args)
        {
            ul = new UtilityLibrary.UtilityLibrary();
            ul.startlooking(Keys.Delete);
            ul.KeyPressedEvent += Ul_KeyPressedEvent;

            while (true)
                Thread.Sleep(1000);
        }

        private static void Ul_KeyPressedEvent()
        {
            Thread t = new Thread(() =>
            {
                InputSimulator isim = new InputSimulator();
                isim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);

                List<string> Filestodelete = new List<string>();
                StringCollection files = Clipboard.GetFileDropList();
                foreach (string item in files)
                {
                    if (File.Exists(item))
                    {
                        Filestodelete.Add(item);
                    }
                }

                DialogResult result = MessageBox.Show("Do you really want to overwrite and delete these " + Filestodelete.Count + " Files?", "Delete and Overwrite", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                foreach (string file in Filestodelete)
                {
                    long filesize = new FileInfo(file).Length;
                    Stream fs = File.Open(file, FileMode.Open);
                    for (int i2 = 0; i2 < 5; i2++)
                    {
                        fs.Position = 0;
                        for (int i = 0; i < filesize; i++)
                        {
                            Byte[] b = new Byte[10];
                            rnd.NextBytes(b);
                            fs.WriteByte(b[rnd.Next(0, 10)]);
                        }
                    }
                    fs.Close();
                    File.Delete(file);
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}
