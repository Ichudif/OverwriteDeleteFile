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
        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private static UtilityLibrary.UtilityLibrary ul;
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            ul = new UtilityLibrary.UtilityLibrary();
            ul.startlooking(Keys.Delete);                   //starting the keyPressed Listener
            ul.KeyPressedEvent += Ul_KeyPressedEvent;       //adding the KeyPressed Event Handler

            //The Programm does not have a console, it would just end, so wait ...
            while (true)
                Thread.Sleep(1000);
        }

        private static void Ul_KeyPressedEvent()
        {
            //clearing the clipboard
            Thread EmptyClipboardTH = new Thread(() =>
            {
                EmptyClipboard();
            });
            EmptyClipboardTH.SetApartmentState(ApartmentState.STA);
            EmptyClipboardTH.Start();
            EmptyClipboardTH.Join();

            Thread.Sleep(1000); //wait a bit, clipboard needs time ...

            //making a new Thread, because it has to be a STA Thread, who accesses the Clipboard
            Thread t = new Thread(() =>
            {
                //Creating the ctrl + C simulator, so that the selected files are being copied to the clipboard
                InputSimulator isim = new InputSimulator();
                isim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);   //simulating ctrl + C

                List<string> Filestodelete = new List<string>();
                List<string> Folderstodelete = new List<string>();
                StringCollection files = Clipboard.GetFileDropList();   //Getting the copied Files from the clipboard
                foreach (string item in files)
                {
                    if (File.Exists(item))
                    {
                        Filestodelete.Add(item);
                    }
                    else if (Directory.Exists(item))  //checking if these Files/Folders do exist
                    {
                        GFRreturn gF = GetFilesRecursive(item);

                        Filestodelete.AddRange(gF.FileList.Where(item2 => !Filestodelete.Contains(item2)));
                        Folderstodelete.AddRange(gF.FolderList.Where(item2 => !Folderstodelete.Contains(item2)));
                    }
                }

                if (Filestodelete.Count == 0 && Folderstodelete.Count == 0)
                {
                    Thread.CurrentThread.Abort();
                }

                //Ask if the user really wants to delete the selected Files, they will be completely destroyed
                Form Dialog = new Form();
                Dialog.TopMost = true;
                SetForegroundWindow(Dialog.Handle);     //Setting dialog to foreground
                DialogResult result = MessageBox.Show(Dialog, "Do you really want to overwrite and delete " + Filestodelete.Count + " File" + ((Filestodelete.Count == 1) ? "" : "s") + " and " + Folderstodelete.Count + " Folder" + ((Folderstodelete.Count == 1) ? "" : "s") + "?", "Delete and Overwrite", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    //user doesnt want, quitting ...
                    Thread.CurrentThread.Abort();
                }

                //deleting all aubfolders, as they will be deleted anyways, if the root folder is removed
                for (int i = 0; i < Folderstodelete.Count; i++)
                {
                    Folderstodelete.Sort();                     //sorting - getting the shortest path first
                    string selected = Folderstodelete[i];
                    Folderstodelete.RemoveAll(item => item.Contains(selected + "\\"));     //removing all Paths, which contain the shortest path
                }

                //iterating over every File
                foreach (string file in Filestodelete)
                {
                    long filesize = new FileInfo(file).Length;  //getting the filesize in byte
                    System.IO.Stream fs = File.Open(file, FileMode.Open); //opening the file in write mode
                    for (int i2 = 0; i2 < 5; i2++)              //Overwrite the File 5 Times, 
                    {
                        fs.Position = 0;                        //Going to the beginning of the File
                        for (int i = 0; i < filesize; i++)
                        {
                            Byte[] b = new Byte[10];
                            rnd.NextBytes(b);                   //Creating 10 random Bytes
                            fs.WriteByte(b[rnd.Next(0, 10)]);   //Take a random one of them and overwrite the existing
                        }
                    }
                    fs.Close();         //Close File
                    File.Delete(file);  //Delete File
                }

                Folderstodelete.ForEach(item => Directory.Delete(item, true));        //Deleting the Folders
                MessageBox.Show(new Form { TopMost = true }, "Finished");

                EmptyClipboard();      //Finally, clearing the Clipboard
            });

            t.SetApartmentState(ApartmentState.STA);    //Setting ApartmentState to STA => Clipboard
            t.Start();
        }

        /// <summary>
        /// Return object of the GetFilesRecursive Method
        /// </summary>
        public struct GFRreturn
        {
            public List<string> FileList;
            public List<string> FolderList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FolderPath">The Folder to search in</param>
        /// <returns>An object, which contains a List of Files and a List of Folders inside the Folder, specified in FolderPath</returns>
        public static GFRreturn GetFilesRecursive(string FolderPath)
        {
            List<string> FileList = new List<string>();
            List<string> FolderList = new List<string>();
            FolderList.Add(FolderPath);
            try
            {
                foreach (string item in Directory.GetDirectories(FolderPath + "\\"))
                {
                    GFRreturn h = GetFilesRecursive(item);
                    FileList.AddRange(h.FileList);
                    FolderList.AddRange(h.FolderList);
                }
            }
            catch
            {

            }

            foreach (string item in Directory.GetFiles(FolderPath))
            {
                FileList.Add(item);
            }


            GFRreturn returnme = new GFRreturn();
            returnme.FileList = FileList;
            returnme.FolderList = FolderList;

            return returnme;
        }
    }
}
