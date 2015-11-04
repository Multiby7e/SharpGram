using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;
namespace SharpGram //Coded by Multibyte - Hackforums.net
{
   
    public partial class FrmMain : Form
    {
        Thread MainThread = null;
        static string[] Clients;

        public FrmMain()
        {
            InitializeComponent();
            if (File.Exists(Application.StartupPath + "\\Data\\Comments.data"))
            {
                string[] Comments = File.ReadAllLines(Application.StartupPath + "\\Data\\Comments.data");
                listComments.Items.AddRange(Comments);
            }
            if (File.Exists(Application.StartupPath + "\\Data\\Tags.data"))
            {
                string[] Tags = File.ReadAllLines(Application.StartupPath + "\\Data\\Tags.data");
                listTags.Items.AddRange(Tags);
            }
			MessageBox.Show("Coded by Multibyte - Hackforums.net");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin FrmLogin = new FrmLogin();
            FrmLogin.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartThread();
        }

        public void Log(string text)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                txtLogs.Text = txtLogs.Text + "[ " + string.Format("{0:HH:mm:ss tt}", DateTime.Now) + "]: " + text + Environment.NewLine;
                txtLogs.SelectionStart = txtLogs.Text.Length;
                txtLogs.ScrollToCaret();
            }
            catch { }
        }
        public void StartThread()
        {
            try
            {
                MainThread = new Thread(new ThreadStart(MainMethod));        
                MainThread.IsBackground = true;
                MainThread.Start();
                btnStart.Text = "Stop";
            }
            catch { }
        }

        private void MainMethod()
        {
            foreach (object Item in listTags.Items)
                Bot.Tags.Add(Item as string);
            foreach (object Item in listComments.Items)
                Bot.Comments.Add(Item as string);
            Clients = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/Clients", "*.xml").Select(path => Path.GetFileName(path).Replace(".xml", "")).ToArray();
            foreach (string ClientName in Clients)
            {
                Client.LoadSettings(ClientName);
                Log("Authorizing client: " + Client.Info["Name"]);
                //Bot.Authorize();
                Client.Token[ClientName] = Bot.GetToken(Bot.Authorize());
            }
            while (true)
            {
                foreach (string ClientName in Clients)
                {
                    Client.LoadSettings(ClientName);
                    Log("Current client: " + ClientName);
                    foreach (string Tag in Bot.Tags)
                    {
                        Log("Gathering pages...");
                        string HTMLTag = Bot.GetHTML("https://instagram.com/explore/tags/" + Tag);
                        Log("Gathering photos...");
                        string[] PhotoIDs = Bot.GetPhotoIDs(HTMLTag);
                        Log("Gathering users...");
                        string[] UsersIDs = Bot.GetPhotoOwners(HTMLTag);
                        Log("Current tag: " + Tag);
                        for (int i = 0; i < PhotoIDs.Length && i < UsersIDs.Length; i++)
                        {
                            if (chkLike.Checked)
                            {
                                if (Bot.LikedIDs.Contains(PhotoIDs[i]))
                                    return;
                                switch (Bot.LikePhoto(PhotoIDs[i], UsersIDs[i]))
                                {
                                    case "OK":
                                        Bot.LikedIDs.Add(PhotoIDs[i]);
                                        Log("Liked photo: " + PhotoIDs[i] + "_" + UsersIDs[i] + " [ " + Bot.LikedIDs.Count.ToString() + " ]");
                                        break;
                                    case "Max":
                                        Log("Excedeed maximum requests.");
                                        goto SkipClient;
                                    case "Fail":
                                        Log("Failed to like photo: " + PhotoIDs[i]);
                                        break;
                                    default:
                                        Log("Unknown error.");
                                        break;
                                }
                            }

                            if (chkFollow.Checked)
                            {
                                if (Bot.FollowedIDs.Contains(UsersIDs[i]))
                                    return;
                                switch (Bot.FollowUser(UsersIDs[i]))
                                {
                                    case "OK":
                                        Bot.FollowedIDs.Add(UsersIDs[i]);
                                        Log("Followed user: " + UsersIDs[i] + " [ " + Bot.FollowedIDs.Count.ToString() + " ]");
                                        break;
                                    case "Max":
                                        Log("Excedeed maximum requests.");
                                        goto SkipClient;
                                    case "Fail":
                                        Log("Failed to follow user: " + UsersIDs[i]);
                                        break;
                                    default:
                                        Log("Unknown error.");
                                        break;
                                }
                            }

                            if (chkComment.Checked)
                            {
                                if (Bot.CommentedIDs.Contains(PhotoIDs[i]))
                                    return;
                                Random r = new Random();
                                switch (Bot.CommentPhoto(PhotoIDs[i], UsersIDs[i], Bot.Comments[r.Next(Bot.Comments.Count)]))
                                {
                                    case "OK":
                                        Bot.CommentedIDs.Add(PhotoIDs[i]);
                                        Log("Commented photo: " + PhotoIDs[i] + " [ " + Bot.CommentedIDs.Count.ToString() + " ]");
                                        break;
                                    case "Max":
                                        Log("Excedeed maximum requests.");
                                        goto SkipClient;
                                    case "NoSupport":
                                        break;
                                    case "Fail":
                                        Log("Failed to comment photo: " + PhotoIDs[i]);
                                        break;
                                    default:
                                        Log("Unknown error.");
                                        break;
                                }
                            }
                            Thread.Sleep(2000);
                        }
                    }
                SkipClient:
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            listTags.Items.Add(txtTag.Text);
            txtTag.Clear();
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            listTags.Items.RemoveAt(listTags.SelectedIndex);
        }

        private void listTags_DoubleClick(object sender, EventArgs e)
        {
            try {
                listTags.Items.RemoveAt(listTags.SelectedIndex);
            }catch{}
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            listComments.Items.Add(txtComment.Text);
            txtComment.Clear();
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            listComments.Items.RemoveAt(listComments.SelectedIndex);
        }

        private void listComments_DoubleClick(object sender, EventArgs e)
        {
            try { 
                listComments.Items.RemoveAt(listComments.SelectedIndex);
            }catch { }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter SaveComments = new StreamWriter(Application.StartupPath + "\\Data\\Comments.data");
            StreamWriter SaveTags = new StreamWriter(Application.StartupPath + "\\Data\\Tags.data");
            foreach (var Comment in listComments.Items)
                SaveComments.WriteLine(Comment.ToString());
            foreach (var Tag in listTags.Items)
                SaveTags.WriteLine(Tag.ToString());
            SaveComments.Close();
            SaveTags.Close();
        }

        private void txtTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTag.Text != string.Empty)
                    listTags.Items.Add(txtTag.Text);
                txtTag.Clear();
            }
        }

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtComment.Text != string.Empty)
                    listComments.Items.Add(txtComment.Text);
                txtComment.Clear();
            }
        }
    }
}