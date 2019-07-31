using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverwriteDeleteFiles
{
    public partial class ProgressBox : UserControl
    {
        public ProgressBox(int MaxFiles, int MaxOverwrites)
        {
            InitializeComponent();

            Filepb.Maximum = MaxFiles;
            OverwriteProgresspb.Maximum = MaxOverwrites;
            FileOverwriteProgresspb.Maximum = 100;
        }

        /// <summary>
        /// Updates the Progressbars 
        /// </summary>
        /// <param name="Filecount">Number of the File in progress</param>
        /// <param name="Overwritecount">Number of the current overwrite round</param>
        /// <param name="Fileprogress">Overwrite Progress of the current File</param>
        public void UpdateBars(int Filecount = -1, int Overwritecount = -1, int Fileprogress = -1)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                if (Filecount != -1)
                {
                    Filepb.Value = Filecount;
                }

                if (Overwritecount != -1)
                {
                    OverwriteProgresspb.Value = Overwritecount;
                }

                if (Fileprogress != -1)
                {
                    FileOverwriteProgresspb.Value = Fileprogress;
                }
            });
        }
    }
}
