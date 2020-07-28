using NAudio.Mixer;
using NAudio.Wave;
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

namespace MicrophoneMuter
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      _muter = new MicrophoneMuter();
      _muter.ErrorChanged += OnErrorChanged;
      _muter.MutedChanged += OMuteChanged;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.Hide();
      _muter.Start();

      notifyIcon1.MouseDown += NotifyIcon1_MouseDown;
    }

    private void OMuteChanged(object sender, bool? e)
    {
      if (e.HasValue)
      {
        notifyIcon1.Icon = e.Value ? _redIco : _greenIco;
      }
      else
      {
        notifyIcon1.Icon = _errorIco;
      }
    }

    private void OnErrorChanged(object sender, string errorMessage)
    {
      notifyIcon1.ShowBalloonTip(1000, "Ошибка", errorMessage, ToolTipIcon.Error);
    }


    private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      _muter.ChangeToOpposite();
      выходToolStripMenuItem.Text = GetRandomText();
    }


    private static string GetPathToIco(string icoName)
    {
      return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, icoName);
    }


    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private string GetRandomText()
    {
      var r = new Random();
      switch (r.Next(0, 5))
      {
        case 0: return "Выход";
        case 1: return "Закрыть";
        case 2: return "Ивешвара - молодец!";
        case 3: return "Ты сегодня внимательно медитировал?";
        case 4: return "Крепче повторяй Харе Кришна!";
        default: return "Досвидания";
      }
    }

    private readonly MicrophoneMuter _muter;

    private const string RedIcoName = "red32.ico";
    private const string GreenIcoName = "green32.ico";
    private const string ErrorIcoName = "error.ico";

    private readonly Icon _redIco = Icon.ExtractAssociatedIcon(GetPathToIco(RedIcoName));
    private readonly Icon _greenIco = Icon.ExtractAssociatedIcon(GetPathToIco(GreenIcoName));
    private readonly Icon _errorIco = Icon.ExtractAssociatedIcon(GetPathToIco(ErrorIcoName));


  }
}
