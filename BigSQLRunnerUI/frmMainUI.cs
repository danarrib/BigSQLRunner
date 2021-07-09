using Microsoft.Win32;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BigSQLRunnerUI
{
    public partial class frmMainUI : Form
    {
        private bool AllowToRun;
        private string CurrentFile;
        private bool StopOnError;
        private bool LogErrors;

        Stopwatch swTotalTime;

        public frmMainUI()
        {
            InitializeComponent();
        }

        private void btnTestConnectionString_Click(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("Connection String must be informed.", "No connection string!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (TestConnectionString(connectionString))
                    MessageBox.Show("Connection string is working fine!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBrowseScriptFile_Click(object sender, EventArgs e)
        {
            BrowseScriptFile();
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            swTotalTime = Stopwatch.StartNew();

            string strConnectionString = txtConnectionString.Text;
            string strLinesPerBatch = txtLinesPerBatch.Text;
            string strStartingLine = txtStartingLine.Text;

            if (string.IsNullOrWhiteSpace(strConnectionString))
            {
                MessageBox.Show("Connection String must be informed.", "No connection string!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!TestConnectionString(strConnectionString))
                return;

            long sLinesPerBatch = 0;
            long lStartingLine = 0;

            if (!long.TryParse(strLinesPerBatch, out sLinesPerBatch))
            {
                MessageBox.Show("Invalid value on the lines per batch field!", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (sLinesPerBatch < 0)
            {
                MessageBox.Show("Invalid value on the lines per batch field! Value must be positive!", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (sLinesPerBatch > 500000)
            {
                MessageBox.Show("Invalid value on the lines per batch field! Value is limited to 500000.", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!long.TryParse(strStartingLine, out lStartingLine))
            {
                MessageBox.Show("Invalid value on the starting line field!", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lStartingLine < 0)
            {
                MessageBox.Show("Invalid value on the starting line field! Value must be positive.", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Everything's fine. Block screen and start running the script
            ControlScreen(false);

            AllowToRun = true;
            StopOnError = chkStopOnError.Checked;
            LogErrors = chkLogErrors.Checked;

            foreach (var item in lstFiles.Items)
            {
                string strScriptPath = item.ToString();

                if (string.IsNullOrWhiteSpace(strScriptPath))
                {
                    MessageBox.Show("Script file must be informed.", "No script!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!File.Exists(strScriptPath))
                {
                    MessageBox.Show("Script file does not exists!", "No script!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                CurrentFile = strScriptPath;

                if (!RunScript(strScriptPath, strConnectionString, sLinesPerBatch, lStartingLine))
                    break;

            }

            ControlScreen(true);
            System.Media.SystemSounds.Beep.Play();
        }

        private void frmMainUI_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = GetConnectionStringFromRegistry();
            pbScriptProgress.Minimum = 0;
            pbScriptProgress.Maximum = 100;
            pbScriptProgress.Value = 0;

        }

        private void frmMainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllowToRun = false;
        }

        private bool TestConnectionString(string connectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                SaveConnectionStringToRegistry(connectionString);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = "Error trying to connect to the database using the provided connection string. The error message is: " + ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveConnectionStringToRegistry(string strConnectionString)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

                key.CreateSubKey("BigSQLRunnerUI");
                key = key.OpenSubKey("BigSQLRunnerUI", true);

                key.SetValue("LastConnectionString", strConnectionString);
            }
            catch (Exception ex)
            {

            }
        }

        private string GetConnectionStringFromRegistry()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key = key.OpenSubKey("BigSQLRunnerUI", true);

                return key.GetValue("LastConnectionString").ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void BrowseScriptFile()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Script File";
            theDialog.Filter = "SQL files|*.sql|TXT files|*.txt|All files|*.*";
            theDialog.Multiselect = true;

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ArrayList q = new ArrayList();

                    foreach (string item in theDialog.FileNames)
                        q.Add(item);

                    q.Sort();

                    lstFiles.Items.Clear();
                    foreach (string item in q)
                        lstFiles.Items.Add(item);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void ControlScreen(bool bEnable)
        {
            btnBrowseScriptFile.Enabled = bEnable;
            btnRunScript.Enabled = bEnable;
            btnTestConnectionString.Enabled = bEnable;
            txtConnectionString.Enabled = bEnable;
            lstFiles.Enabled = bEnable;
            txtLinesPerBatch.Enabled = bEnable;
            txtStartingLine.Enabled = bEnable;
            chkStopOnError.Enabled = bEnable;
            btnStop.Enabled = !bEnable;
            chkLogErrors.Enabled = bEnable;
            Cursor.Current = bEnable ? Cursors.Default : Cursors.WaitCursor;
            this.UseWaitCursor = !bEnable;
        }

        public void UpdateStatus(string status)
        {
            string firstLine = "Processing file " + CurrentFile + " - Total elapsed time: " + swTotalTime.Elapsed.ToReadableShortString();
            lblStatus.Text = firstLine + "\n" + status;
            lblStatus.Invalidate();
            this.Refresh();
            Application.DoEvents();
        }

        public void UpdateProgressBar(int percent)
        {
            if (pbScriptProgress.Value != percent)
            {
                pbScriptProgress.Value = percent;
                pbScriptProgress.Invalidate();
            }
        }

        private bool RunScript(string sourceScript, string connectionString, long qtyMaxLines, long startLine)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Config
            string line;
            string errorFile = sourceScript + ".[linenumber].error";
            long qtyErrorLines = 0;
            long qtyLines = 0;
            long control = 0;
            Stopwatch watchtotal = Stopwatch.StartNew();

            long totalLines = CountLines(sourceScript);

            if (startLine > 0)
                UpdateStatus("Starting at line " + startLine.ToString() + ".");

            Stopwatch watch = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();

            StreamReader file = new StreamReader(sourceScript);
            while ((line = file.ReadLine()) != null)
            {
                qtyLines++;
                if (startLine > qtyLines)
                    continue;

                if (!AllowToRun)
                    break;

                bool isGO = false;

                if (line.Trim().ToUpper().StartsWith("GO"))
                {
                    isGO = true;
                }
                else
                {
                    control++;
                    sb.AppendLine(line);
                }

                if ((control >= qtyMaxLines && qtyMaxLines > 0) || isGO)
                {
                    if (sb.Length > 0)
                    {
                        using (SqlCommand comm = new SqlCommand(sb.ToString(), conn))
                        {
                            comm.CommandTimeout = 3600; // 1 hour
                            try
                            {
                                comm.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                if (LogErrors)
                                {
                                    string errormsg = "/* The error was: \n" + ex.Message + "\n*/";
                                    // Save the chuncks that could not be processed
                                    File.AppendAllText(errorFile.Replace("[linenumber]", qtyLines.ToString()), sb.ToString() + Environment.NewLine);
                                    File.AppendAllText(errorFile.Replace("[linenumber]", qtyLines.ToString()), errormsg + Environment.NewLine);
                                }
                                qtyErrorLines++;
                                if (StopOnError)
                                    AllowToRun = false;
                            }
                            control = 0;
                            sb.Clear();
                        }
                    }

                    // Update screen
                    double percentComplete = (qtyLines.ToDouble() / totalLines.ToDouble()) * 100.0;
                    long ticksLeft = Convert.ToInt64((totalLines.ToDouble() - qtyLines.ToDouble()) * (watch.ElapsedTicks / qtyLines.ToDouble()));
                    TimeSpan timeLeft = TimeSpan.FromTicks(ticksLeft);

                    UpdateProgressBar(percentComplete.ToInt());

                    UpdateStatus(string.Format("{0} lines processed ({4} errors). {1:0.00}% complete. {2} remaining. {3} elapsed.",
                        qtyLines,
                        percentComplete,
                        timeLeft.ToReadableShortString(),
                        watchtotal.Elapsed.ToReadableShortString(),
                        qtyErrorLines));

                }

            }

            // Finished reading file. Check if there's still lines to run
            if (control > 0 && AllowToRun && sb.Length > 0)
            {
                using (SqlCommand comm = new SqlCommand(sb.ToString(), conn))
                {
                    comm.CommandTimeout = 3600; // 1 hour
                    try
                    {
                        comm.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        if (LogErrors)
                        {
                            string errormsg = "/* The error was: \n" + ex.Message + "\n*/";
                            // Save the chuncks that could not be processed
                            File.AppendAllText(errorFile.Replace("[linenumber]", qtyLines.ToString()), sb.ToString() + Environment.NewLine);
                            File.AppendAllText(errorFile.Replace("[linenumber]", qtyLines.ToString()), errormsg + Environment.NewLine);
                        }
                        qtyErrorLines++;
                        if (StopOnError)
                            AllowToRun = false;
                    }
                    control = 0;
                    sb.Clear();
                }
            }
            watchtotal.Stop();
            UpdateProgressBar(100);
            UpdateStatus(string.Format("{0} lines processed ({2} errors). Finished in {1} !",
                qtyLines,
                watchtotal.Elapsed.ToReadableShortString(),
                qtyErrorLines));
            file.Close();

            if (qtyErrorLines > 0 && AllowToRun)
            {
                string errorMessage = string.Format("{0} lines were not loaded. Please check the error files {1}", qtyErrorLines, errorFile);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            conn.Close();
            conn.Dispose();

            return qtyErrorLines == 0;

        }

        private long CountLines(string inputFileFullPath)
        {
            long lineCount = 0;
            Stopwatch sw = Stopwatch.StartNew();

            using (var reader = File.OpenText(inputFileFullPath))
            {
                while (reader.ReadLine() != null)
                {
                    if (!AllowToRun)
                        break;

                    lineCount++;
                    if (sw.ElapsedMilliseconds >= 200)
                    {
                        UpdateStatus("Counting input file lines... " + lineCount.ToString("#,0"));
                        sw = Stopwatch.StartNew();
                    }
                }
            }

            return lineCount;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AllowToRun = false;
        }
    }
}
