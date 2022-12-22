using DocumentFormat.OpenXml.Drawing;
using Futech.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmLoading : Form
    {
        #region: Properties
        private readonly ProgressBarWithText _progressBarWithText;
        private static Regex regexCheckNumber = new Regex("^[0-9]+$");
        Dictionary<string, Action> loadingWorks = new Dictionary<string, Action>();
        #endregion: End Properties

        #region: Forms
        public frmLoading()
        {
            InitializeComponent();
            _progressBarWithText = new ProgressBarWithText();
            _progressBarWithText.Minimum = 0;
            _progressBarWithText.Value = 0;
            _progressBarWithText.Dock = DockStyle.Bottom;
            Controls.Add(_progressBarWithText);
            Controls.SetChildIndex(_progressBarWithText, 0);

            loadingWorks.Add("Work1...", new Action(() => Work1()));
            _progressBarWithText.Maximum = loadingWorks.Count;
        }
        private async void frmLoading_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Action> actions in loadingWorks)
            {
                MultipleThreadTool.InvokeControl(_progressBarWithText, () => UpdateCurrentProgressStatus(actions.Key));
                actions.Value();
                await Task.Delay(1);
            }
            this.DialogResult = DialogResult.OK;
        }
        #endregion: End Forms

        #region: Controls In Form
        #endregion: End Controls In Form

        #region: Private Function
        private void Work1() {
            Thread.Sleep(10000);
        }

        private void UpdateCurrentProgressStatus(string data)
        {
            _progressBarWithText.Value++;
            _progressBarWithText.CustomText = data;
        }
        #endregion: End Private Function

        #region: Public Function
        #endregion: End Public Function


    }
}
